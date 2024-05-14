using CirculaBem.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CirculaBem.Service.Infra.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ModelUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntityDomain>()
                        .HasKey(x => x.RegistrationNumber);
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

    }
}
