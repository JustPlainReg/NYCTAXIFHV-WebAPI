using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;
using NYCTaxiFHVData.Models;
using NYCTaxiFHVData.Repository;
using NYCTaxiFHVData.Service;

namespace NYCTaxiFHVData.Controllers
{
    [RoutePrefix("api/TripData")]
    [AllowAnonymous]
    public class TripDataController : ApiController
    {
        private readonly ITripDataService _tripDataService;
        public TripDataController(ITripDataService tripDataService)
        {
            _tripDataService = tripDataService;
        }

        [HttpGet]
        public IEnumerable<TripData> GetAll()
        {
            return _tripDataService.FindAll();
        }

        [HttpPost]
        [Route("GetDashBoardData")]
        public dynamic GetDashBoardData(Search search)
        {
            return _tripDataService.GetDashBoardData(search);
        }

        [HttpPost]
        [Route("GetLocationDetail")]
        public dynamic GetLocationDetail(Search search)
        {
            var data = _tripDataService.GetLocationDetail(search);
            return data;
        }

        [HttpPost]
        public IEnumerable<TripData> Post(Search search)
        {
            return _tripDataService.FindBySearch(search);
        }

        [HttpPost]
        [Route("GetBarChartData")]
        public dynamic GetBarChartData(JObject obj)
        {
            return _tripDataService.GetBarChartData(obj);
        }
    }
}