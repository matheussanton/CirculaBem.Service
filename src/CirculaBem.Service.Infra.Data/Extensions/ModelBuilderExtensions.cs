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

    }
}
