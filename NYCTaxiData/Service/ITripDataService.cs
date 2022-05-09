using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NYCTaxiFHVData.Models;

namespace NYCTaxiFHVData.Service
{
    public interface ITripDataService
    {
        IEnumerable<TripData> FindAll();
        TripData FindById(int id);
        IEnumerable<TripData> FindBySearch(Search search);
        dynamic GetDashBoardData(Search search);
        dynamic GetLocationDetail(Search search);
        dynamic GetBarChartData(JObject obj);
    }
}
