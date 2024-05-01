using CirculaBem.Service.Domain.Settings;
using CirculaBem.Service.Domain.User.Interfaces;
using CirculaBem.Service.Infra.Data.Context;
using CirculaBem.Service.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CirculaBem.Service.Dependencies.Extensions
{
    public static class InfraDependenciesExtensions
    {
        /// <summary>
        /// Register Data Layer Dependencies, including PostgreSQL and EFCore.
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection RegisterDataLayerDependencies(this IServiceCollection services, AppSettings appSettings, IConfiguration configuration)
        {
            return services.RegisterPostgreSQL(appSettings);
        }

        public static IServiceCollection RegisterPostgreSQL(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContext<AppDbContext>(ServiceLifetime.Transient);

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
