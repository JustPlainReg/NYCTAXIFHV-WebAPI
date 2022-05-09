using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NYCTaxiFHVData.Models;
using NYCTaxiFHVData.Repository;

namespace NYCTaxiFHVData.Service
{
    public class LookUpService:ILookUpService
    {
        private readonly ILookUpRepository _lookUpRepository;

        public LookUpService(ILookUpRepository lookUpRepository)
        {
            _lookUpRepository = lookUpRepository;
        }

        public IEnumerable<TaxiZone> GetZones()
        {
            return _lookUpRepository.GetZones();
        }
        public TaxiZone GetLocation(int locationId)
        {
            return _lookUpRepository.GetLocation(locationId);
        }
        public void UpdateLocation(int locationId, float lat, float lng)
        {
            _lookUpRepository.UpdateLocation(locationId, lat, lng);
        }
    }
}