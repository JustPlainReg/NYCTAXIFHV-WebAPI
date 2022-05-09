using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NYCTaxiFHVData.Models;

namespace NYCTaxiFHVData.Repository
{
    public interface ITripDataRepository
    {
        IEnumerable<TripData> FindAll();
        TripData FindById(int id);
        IEnumerable<TripData> FindBySearch(Search search);
        dynamic GetDashBoardData(Search search);

        dynamic GetLocationDetail(Search search);
        dynamic GetBarChartData(JObject obj);
    }
}
