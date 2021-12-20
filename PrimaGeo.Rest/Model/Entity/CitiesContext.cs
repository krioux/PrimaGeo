using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using PrimaGeo.Backend.Model.API;
using System.Data.SQLite;

namespace PrimaGeo.Backend.Model.Entity
{
    public class CitiesContext:DbContext
    {
        static readonly SQLiteConnectionStringBuilder _builder = new SQLiteConnectionStringBuilder()
        {
            DataSource = "./sqlite.db",
            ForeignKeys = true,
            BrowsableConnectionString = true
        };

        public CitiesContext()
            : base(new SQLiteConnection() { ConnectionString = _builder.ToString() }, true)
        {
            //Create database always, even If exists
            Database.SetInitializer(new CreateDatabaseIfNotExists<CitiesContext>());
            Database.Initialize(true);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeoDBCities>().HasKey(p => p.id);
            modelBuilder.Entity<GeoDBCities>().Property(p => p.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);  //To prevent overwriting originals Id
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<GeoDBCities> Cities { get; set; }
   
    }
}
