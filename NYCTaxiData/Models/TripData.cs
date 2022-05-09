using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NYCTaxiFHVData.Models
{
    [Serializable]
    public class TripData:BaseEntity
    {
        public int TripId { get; set; }
        public int VendorId { get; set; }
        public DateTime PickupDatetime { get; set; }
        public DateTime DropoffDatetime { get; set; }
        public string StoreFlag { get; set; }
        public int RatecodeId { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropoffLocationId { get; set; }
        public int PassengerCount { get; set; }
        public float TripDistance { get; set; }
        public float FareAmount { get; set; }
        public float Extra { get; set; }
        public float MTAtax { get; set; }
        public float TipAmount { get; set; }
        public float TollsAmount { get; set; }
        public float ImprovementSurcharge { get; set; }
        public float TotalAmount { get; set; }
        public int PaymentType { get; set; }
        public int TripType { get; set; }
        public char Taxitype { get; set; }

        public int? TripCount { get; set; }
    }
}