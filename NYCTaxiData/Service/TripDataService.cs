using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using NYCTaxiFHVData.Models;
using NYCTaxiFHVData.Repository;

namespace NYCTaxiFHVData.Service
{
    public class TripDataService:ITripDataService
    {
        private ITripDataRepository _tripDataRepository;

        public TripDataService(ITripDataRepository tripDataRepository)
        {
            _tripDataRepository = tripDataRepository;
        }
        public IEnumerable<TripData> FindAll()
        {
            return _tripDataRepository.FindAll();
        }

        public TripData FindById(int id)
        {
            return _tripDataRepository.FindById(id);
        }

        public IEnumerable<TripData> FindBySearch(Search search)
        {
            return _tripDataRepository.FindBySearch(search);
        }

        [HttpPost]
        public dynamic GetDashBoardData(Search search)
        {
            return _tripDataRepository.GetDashBoardData(search);
        }

        [HttpPost]
        public dynamic GetLocationDetail(Search search)
        {
            return _tripDataRepository.GetLocationDetail(search);
        }

        public dynamic GetBarChartData(JObject obj)
        {
            return _tripDataRepository.GetBarChartData(obj);
        }
    }
}