using System.Data.Entity;
using Microsoft.Data.Sqlite;
using PrimaGeo.Backend.Model.API;

namespace PrimaGeo.Backend.Model.Entity
{
    class CitiesContext:DbContext
    {
        static readonly SqliteConnectionStringBuilder connectionStringBuilder = new SqliteConnectionStringBuilder
        {
            DataSource = "./GeoDBCities.db",
            BrowsableConnectionString = true
        };
        public CitiesContext():base(connectionStringBuilder.ToString())
        {
        }
        public DbSet<GeoDBCities> Cities { get; set; }
   
    }
}
