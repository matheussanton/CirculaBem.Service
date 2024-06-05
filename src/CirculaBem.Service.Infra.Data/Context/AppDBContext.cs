using CirculaBem.Service.Domain.Entities;
using CirculaBem.Service.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CirculaBem.Service.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetSection("Settings")["PostgreSQLConnectionString"]);
        }

        public DbSet<UserEntityDomain> Users { get; set; }

        public DbSet<AddressEntityDomain> Adresses { get; set; }

        public DbSet<CategoryEntityDomain> Categories { get; set; }

        public DbSet<ProductEntityDomain> Products { get; set; }
        public DbSet<ProductImageEntityDomain> ProductImages { get; set; }
        public DbSet<ProductAvailabilityEntityDomain> ProductAvailabilities { get; set; }

        public DbSet<RentEntityDomain> Rents { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User
            modelBuilder.ModelUser();
            // modelBuilder.SeedDefaultUser();

            modelBuilder.ModeAddress();

            modelBuilder.ModelProduct();

            modelBuilder.ModelCategory();

            modelBuilder.ModelRent();
        }

    }
}
