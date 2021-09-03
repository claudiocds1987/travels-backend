using backend_api.Models; // importamos todos los modelos que hay en carpeta Models
using Microsoft.EntityFrameworkCore; // Para que la clase pueda heredar de la clase DbContext
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api
{
    public class AplicationDbContext: DbContext
    {
        // DbContext es una clase de Entity Framework.
        // Lo que hace el DbContext es crear una instancia a nuestra base de datos para poder almacenar los datos,
        // Configurar modelo y relación, hacer las querys, crear nuestra base de datos a partir del modelo, etc.

        // aca se declaran los modelos (creados en carpeta Models) con Entity Framework.

        // DbSet son para poder mapear nuestro modelo por ej City
        // con la tabla que se va a llamar "Cities"

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<CountryCode> CountryCode { get; set; }

        // constructor
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definicion de claves compuestas en el modelo City
            // modelBuilder.Entity<City>()
            //.HasKey(o => new { o.CityId, o.CountryId });
            // relation entity City and Country where a City has one country or a country hasMany cities 
            modelBuilder.Entity<City>()
            .HasOne<Country>(s => s.Country)
            .WithMany(g => g.Cities)
            .HasForeignKey(s => s.CountryId);
            // relation entity Vehicle and Brand where a Vehicle has one brand or a brand hasMany vehicles
            modelBuilder.Entity<Vehicle>()
           .HasOne<Brand>(s => s.Brand)
           .WithMany(g => g.Vehicles)
           .HasForeignKey(s => s.BrandId);

            // a VehicleType can has to many vehicles 
            modelBuilder.Entity<VehicleType>()
            .HasMany<Vehicle>(g => g.Vehicles)
            .WithOne(s => s.VehicleType)
            .HasForeignKey(s => s.VehicleTypeId);
        }

    }

}
