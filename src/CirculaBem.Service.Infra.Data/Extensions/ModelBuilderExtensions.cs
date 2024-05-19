using CirculaBem.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CirculaBem.Service.Infra.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ModelUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntityDomain>()
                        .HasKey(x => x.Id);
        }

        public static void ModelProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntityDomain>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<ProductEntityDomain>()
                        .HasOne(x => x.Category)
                        .WithMany(x => x.Products)
                        .HasForeignKey(x => x.CategoryId);
        }

        public static void ModelCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntityDomain>()
                        .HasKey(x => x.Id);
        }

        public static void ModelRent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentEntityDomain>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<RentEntityDomain>()
                        .HasKey(x => new { x.UserId, x.ProductId, x.StartDate, x.EndDate });

            modelBuilder.Entity<RentEntityDomain>()
                        .HasOne(rent => rent.Product)                       // RentEntityDomain has one Product
                        .WithMany()                                         // Product has many RentEntityDomain
                        .HasForeignKey(rent => rent.ProductId)             // Foreign key property in RentEntityDomain
                        .HasPrincipalKey(product => product.Id);            // Principal key property in Product

            modelBuilder.Entity<RentEntityDomain>()
                        .HasOne(rent => rent.User)                                      // RentEntityDomain has one User
                        .WithMany()                                                     // User has many RentEntityDomain
                        .HasForeignKey(rent => rent.UserId)             // Foreign key property in RentEntityDomain
                        .HasPrincipalKey(user => user.RegistrationNumber);            // Principal key property in User
        }

    }
}
