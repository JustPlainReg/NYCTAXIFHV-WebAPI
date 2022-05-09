using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NYCTaxiFHVData.Models
{
    [Serializable]
    public class Search
    {
        public int  locationId { get; set; }
        public string taxiType { get; set; }
        public string locationType { get; set; }
        public int month { get; set; }
        public string countBy { get; set; }
    }
}