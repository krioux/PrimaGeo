using System.Collections.Generic;

namespace PrimaGeo.Backend.Model.API
{
    public class GeoDBJsonAnswer
    {
        public List<GeoDBCities> data { get; set; }
        public List<GeoDBLink> links { get; set; }
        public GeoDBMetadata metadata { get; set; }
    }
}