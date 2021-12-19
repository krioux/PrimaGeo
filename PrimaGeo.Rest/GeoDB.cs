using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using Newtonsoft.Json;
using PrimaGeo.Backend.Model.API;
using PrimaGeo.Backend.Model.Entity;
using RestSharp;

namespace PrimaGeo.Rest
{
    public class GeoDB
    {
        public IEnumerable<GeoDBCities> Cities => _cities;

        const string MontrealLocation = "45.508888-73.561668";
        readonly RestClient _client = new RestClient("https://wft-geo-db.p.rapidapi.com/v1");
        readonly RestRequest _request = new RestRequest($"/geo/locations/{MontrealLocation}/nearbyCities?limit=10", Method.GET);
        readonly List<GeoDBCities> _cities;

        public GeoDB()
        {
            _request.AddHeader("x-rapidapi-key", "6f15444488msh1ef1a71f1cb978bp13e0d8jsn341e9eada5db");
            var queryResult = _client.Execute(_request);
            var result = JsonConvert.DeserializeObject<GeoDBJsonAnswer>(queryResult.Content);
            _cities = result.data;

            using (var context = new CitiesContext())
            {
                context.Cities.AddRange(_cities);
                context.SaveChanges();
            }
        }
    }
}
