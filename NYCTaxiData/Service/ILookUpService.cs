using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NYCTaxiFHVData.Models;

namespace NYCTaxiFHVData.Service
{
    public interface ILookUpService
    {
        IEnumerable<TaxiZone> GetZones();
        TaxiZone GetLocation(int locationId);
        void UpdateLocation(int locationId, float lat, float lng);
    }
}
