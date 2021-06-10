using System;
using System.Collections.Generic;
using System.Text;

namespace CheapAwesome.Core.Entities
{
    public class Availability
    {
        public Hotel hotel { get; set; }
        public Rate[] rates { get; set; }
    }

    public class Hotel
    {
        public int propertyID { get; set; }
        public string name { get; set; }
        public int geoId { get; set; }
        public int rating { get; set; }
    }

    public class Rate
    {
        public string rateType { get; set; }
        public string boardType { get; set; }
        public float value { get; set; }
    }
}
