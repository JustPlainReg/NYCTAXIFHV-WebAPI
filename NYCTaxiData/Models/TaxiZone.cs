using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NYCTaxiFHVData.Models
{
    public class TaxiZone
    {
        public int LocationId { get; set; }
        public string Borough { get; set; }
        public string Zone { get; set; }
        public string ServiceZone { get; set; }
        public decimal Lat { get; set; }
        public decimal Lag { get; set; }
    }
}