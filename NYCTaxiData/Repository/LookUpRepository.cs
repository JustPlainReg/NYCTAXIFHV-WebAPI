using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using Dapper;
using NYCTaxiFHVData.Models;

namespace NYCTaxiFHVData.Repository
{
    public class LookUpRepository : ILookUpRepository
    {
        private readonly IRepository _repository;
        public LookUpRepository(IRepository repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<TaxiZone> GetZones()
        {
            return _repository.SqlQuery<TaxiZone>("select * from taxi_zones");

        }

        
        public TaxiZone GetLocation(int locationId)
        {
            return _repository.SqlQuery<TaxiZone>("select * from taxi_zones where locationID =" + locationId).FirstOrDefault();

        }
        
        public void UpdateLocation(int locationId, float lat, float lng)
        {
            var query = "Update taxi_zones set latitude=@lat,longitude=(@lng) where locationID=@locationId";
            var parameters = new Dictionary<string, object>
                                 {
                                     { "@locationID",locationId },
                                     { "@latitude", lat },
                                     { "@longitude", lng }
                                 };
            _repository.Execute(query,parameters);
        }

    }
}