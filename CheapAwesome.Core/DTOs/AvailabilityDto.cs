
namespace CheapAwesome.Core.DTOs
{
    public class AvailabilityDto
    {
        public int propertyID { get; set; }
        public string name { get; set; }
        public int geoId { get; set; }
        public int rating { get; set; }
        public RateDto[] rates { get; set; }
    }

    public class RateDto
    {
        public string rateType { get; set; }
        public string boardType { get; set; }
        public float value { get; set; }
    }
}
