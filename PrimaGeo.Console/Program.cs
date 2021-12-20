using System.Collections.Generic;
using System.Data.Entity;
using PrimaGeo.Backend;
using PrimaGeo.Backend.Model.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using PrimaGeo.Backend.Model.API;


namespace PrimaGeo.Console
{
    class Program
    {

        static void Main(string[] args)
        {
            var geoDB = new GeoDB();
            List<GeoDBCities> dbCities = geoDB.CitiesContext.Cities.ToList(); //Read and update sqlite database
            geoDB.CitiesContext.Cities.AddOrUpdate(c=>c.wikiDataId,geoDB.CitiesRest.ToArray());
            geoDB.CitiesContext.SaveChanges();
        }



        
    }
}
