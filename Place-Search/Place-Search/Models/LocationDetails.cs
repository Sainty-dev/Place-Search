using System;
namespace PlaceSearch.Models
{
	public class LocationDetails
	{
        public string Name { get; set; }
        public string FormattedAddress { get; set; }
        public string Vicinity { get; set; }
        public string Url { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int UtcOffset { get; set; }
    }
}

