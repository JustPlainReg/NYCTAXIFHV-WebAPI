using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using NYCTaxiFHVData.Models;

namespace NYCTaxiFHVData.Repository
{
    public class TripDataRespository : ITripDataRepository
    {
        private readonly IRepository _repository;
      
        public TripDataRespository(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TripData> FindAll()
        {
            string query = @"SELECT CONCAT(a.borough,'/',a.zone,'/',a.service_zone) as location, 
                                    CONCAT(b.borough,'/',b.zone,'/',b.service_zone) as Dist,
                                    t.trips, 
                                    t.tips
                             FROM(SELECT locationID, doLocationID, SUM(tripCount) AS trips,
                                        SUM(tipPercentage) AS tips,
                                        taxiType
                                    FROM public.taxifhv_data_destinations_by_trips
                                    WHERE locationTYPE =@locationTYPE
                                    GROUP BY locationID, doLocationID, taxiType) t
                                INNER JOIN taxi_zones a ON a.locationID = t.locationID
                                INNER JOIN taxi_zones b ON b.locationID = t.doLocationID
                                ORDER BY trips desc";
            return _repository.SqlQuery<TripData>(query);

        }

        public dynamic GetDashBoardData(Search search)
        {
            string query = @"SELECT CONCAT (tz.borough,'/',tz.zone,'/',tz.service_zone) as location,
                                    a.*, tz.latitude, tz.longitude
                            FROM(SELECT locationID, SUM(tripCount) as trips,
                                        ROUND(CAST(AVG(tipPercentage) AS NUMERIC), 2) AS tips,
                                        ROUND(CAST(AVG(tripTotal) AS NUMERIC), 2) as tripTotal,
                                        taxiType";
            query += search.month > 0 ? ",month" : " ";
            query += @" from public.taxifhv_data_destinations_by_trips WHERE locationTYPE = @locationTYPE AND taxiType = @taxiType AND tripCount > 100";
            query += search.month > 0 ? " and month =" + search.month : " ";
            query += @" GROUP BY locationID, taxiType";
            query += search.month > 0 ? ",month" : "";
            query += @") a
                    INNER JOIN taxi_zones tz on tz.locationID = a.locationID
                    ORDER BY ";
            query += search.countBy != null ? search.countBy : "trips";
            query += @" DESC
                        FETCH FIRST 10 ROW ONLY";
            var parameters = new Dictionary<string, object>
                                 {
                                     { "@locationTYPE", search.locationType },
                                     { "@taxiType", search.taxiType }
                                 };
            return _repository.SqlQuery<dynamic>(query, parameters).ToList();

        }

        public dynamic GetLocationDetail(Search search)
        {
            string query =
               @"SELECT CONCAT(z.borough,'/',z.zone,'/',z.service_zone) as location,t.*,z.latitude,z.longitude           
            from( 
                      select doLocationID as locationId,SUM(tripCount) as trips,ROUND(CAST(AVG(tipPercentage) as numeric),2) as tips,ROUND(CAST(AVG(tripTotal) as numeric),2) as triptotal,taxiType";
            query += search.month > 0 ? ",month" : " ";
            query += @" from public.taxifhv_data_destinations_by_trips where locationID=@locationId and locationID!=doLocationID and locationTYPE=@locationType and taxiType=@taxitype";
            query += search.month > 0 ? " and month=" + search.month : " ";
            query += @" Group by doLocationID,taxiType";
            query += search.month > 0 ? ",month" : "";
            query += @") t
                        inner join taxi_zones z on z.locationID=t.locationID               
                  order by ";
            query += search.countBy != null ? search.countBy : "trips";
            query += @" desc
                  FETCH FIRST 3 ROW ONLY
                  ";
            var parameters = new Dictionary<string, object>
                                 {
                                     { "@locationId", search.locationId },
                                     { "@locationType", search.locationType },
                                     { "@taxitype", search.taxiType }
                                 };
            return _repository.SqlQuery<dynamic>(query, parameters).ToList();

        }
        public TripData FindById(int id)
        {
            //using (IDbConnection dbConnection = Connection)
            //{
            //    dbConnection.Open();
            //    return dbConnection.Query<TripData>("SELECT * FROM nyctaxitripdata2 WHERE id = @Id", new { Id = id }).FirstOrDefault();
            //}
            var query = @"SELECT * FROM tripData WHERE id = @tripID";
            var parameters = new Dictionary<string, object>
                                {
                                    { "@tripID", id }
                                };
            return _repository.SqlQuery<TripData>(query, parameters).FirstOrDefault();
        }
        public IEnumerable<TripData> FindBySearch(Search search)
        {
            
            var query = @"SELECT *  FROM tripData where  ";
            string locationIds = "1";
            if (search.locationId > 0)
                locationIds = search.locationId.ToString();
            query += " pickupLocationID in( @locationIds)";


            var parameters = new Dictionary<string, object>
            {
                {"@locationIds", locationIds}
            };
            //     using (IDbConnection dbConnection = Connection)
            //     {
            //         dbConnection.Open();
            //         return dbConnection.Query<TripData>(query).ToList();
            //     }
            return _repository.SqlQuery<TripData>(query, parameters);
        }

        public dynamic GetBarChartData(JObject obj)
        {
            string query = @"SELECT SUM(tripCount) as trips, 
                            ROUND(CAST(AVG(tipPercentage) AS NUMERIC), 2) AS tips, 
                            ROUND(CAST(AVG(tripTotal) AS NUMERIC), 2) AS tripTotal, 
                            taxiType, month
                        FROM public.taxifhv_data_destinations_by_trips
                        WHERE locationTYPE='Pickup'";

            if (obj != null)
            {
                foreach (JProperty property in obj.Properties())
                {
                    if (property.Name == "zones")
                    {
                        string zones = "";
                        foreach (var jToken in property.Value)
                        {
                            zones += zones == "" ? jToken.Value<string>() : "," + jToken.Value<string>();
                        }
                        if (zones != "")
                            query += "and locationID in(" + zones + ")";
                    }

                    if (property.Name == "months")
                    {
                        string months = "";
                        foreach (var jToken in property.Value)
                        {
                            months += months == "" ? jToken.Value<string>() : "," + jToken.Value<string>();
                        }
                        if (months != "")
                            query += " and month in(" + months + ")";
                    }
                }
            }

            query += " Group by taxiType, month";
            return _repository.SqlQuery<dynamic>(query).ToList();

        }



    }

}