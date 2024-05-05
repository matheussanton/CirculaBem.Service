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
        }

    }
}
