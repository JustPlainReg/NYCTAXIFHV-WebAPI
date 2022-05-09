using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NYCTaxiFHVData.Models
{
    [Serializable]
    public class TripDataAvg:BaseEntity
    {
        public int TripCounts { get; set; }
        public int LocationId { get; set; }
        public float TripDistance { get; set; }
        public float TipAmount { get; set; }
        public float FareAmount { get; set; }
        public float TotalAmount { get; set; }
        public char Taxitype { get; set; }
    }
}