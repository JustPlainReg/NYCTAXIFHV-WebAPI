using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NYCTaxiFHVData.Models;
using NYCTaxiFHVData.Service;

namespace NYCTaxiFHVData.Controllers
{
    [RoutePrefix("api/LookUp")]
    public class LookUpController : ApiController
    {
        private readonly ILookUpService _lookUpService;
        public LookUpController(ILookUpService lookUpService)
        {
            _lookUpService = lookUpService;
        }

        [HttpGet]
        [Route("GetZones")]
        public IEnumerable<TaxiZone> GetZones()
        {
            return _lookUpService.GetZones();
        }

        [HttpGet]
        [Route("GetLocation")]
        public TaxiZone GetLocation(int locationID)
        {
            return _lookUpService.GetLocation(locationID);
        }

        [HttpPost]
        public void UpdateLocation(int locationID, float lat, float lng)
        {
            _lookUpService.UpdateLocation(locationID, lat, lng);
        }
    }
}