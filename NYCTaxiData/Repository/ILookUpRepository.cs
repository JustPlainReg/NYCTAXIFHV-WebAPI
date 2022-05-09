using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NYCTaxiFHVData.Models;

namespace NYCTaxiFHVData.Repository
{
    public interface ILookUpRepository
    {
        IEnumerable<TaxiZone> GetZones();
        TaxiZone GetLocation(int locationID);
        void UpdateLocation(int locationID, float lat, float lng);
    }
}
