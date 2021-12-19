﻿using System.Collections.Generic;
namespace PrimaGeo.Backend.Model.API
{
    public class GeoDBCities
    {
        public int id { get; set; }
        public string wikiDataId { get; set; }
        public string type { get; set; }
        public string city { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string region { get; set; }
        public string regionCode { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int population { get; set; }
        public double distance { get; set; }
    }
}