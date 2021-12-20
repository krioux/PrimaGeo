using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimaGeo.Backend.Model.API
{
    [Table("Cities")]
    public class GeoDBCities
    {
        [Key]
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