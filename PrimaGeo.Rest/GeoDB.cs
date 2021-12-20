using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using Newtonsoft.Json;
using PrimaGeo.Backend.Model.API;
using PrimaGeo.Backend.Model.Entity;
using RestSharp;

namespace PrimaGeo.Backend
{
    public class GeoDB:IDisposable
    {
        public IEnumerable<GeoDBCities> CitiesRest => _cities;
        public IEnumerable<GeoDBCities> CitiesSqlite => _context.Cities;

        public CitiesContext CitiesContext => _context;

        readonly CitiesContext _context = new CitiesContext();
        //Since we might want to implement more of the API the client are defined here to be reusable.
        const string MontrealLocation = "45.508888-73.561668";
        readonly RestClient _client = new RestClient("https://wft-geo-db.p.rapidapi.com/v1");  
        readonly RestRequest _request = new RestRequest($"/geo/locations/{MontrealLocation}/nearbyCities?limit=10", Method.GET);
        readonly List<GeoDBCities> _cities;
        /// <summary>
        /// This constructor could be modified to add more functions, actually for a more complete
        /// class Each properties would have their specific query out od the constructor
        /// </summary>
        public GeoDB()
        {
            _request.AddHeader("x-rapidapi-key", "6f15444488msh1ef1a71f1cb978bp13e0d8jsn341e9eada5db"); //Demo API key 
            var queryResult = _client.Execute(_request);
            var result = JsonConvert.DeserializeObject<GeoDBJsonAnswer>(queryResult.Content);
            _cities = result.data;
            CitiesContext.Cities.AddOrUpdate(c => c.wikiDataId, CitiesRest.ToArray());
            CitiesContext.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
