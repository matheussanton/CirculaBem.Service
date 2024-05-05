using CirculaBem.Service.Domain.User.Commands.Handler;
using CirculaBem.Service.Domain.Responses;
using Microsoft.Extensions.DependencyInjection;
using CirculaBem.Service.Domain.Product.Commands.Handler;
using CirculaBem.Service.Domain.Product.Queries;

namespace CirculaBem.Service.Dependencies.Extensions
{
    public static class DomainDependenciesExtensions
    {
        public static void RegisterDomainDependencies(this IServiceCollection services)
        {
            RegisterHandlers(services);
            RegisterResponses(services);
            RegisterQueries(services);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }

        private static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddScoped<UserHandler>();
            services.AddScoped<ProductHandler>();
        }

        private static void RegisterQueries(this IServiceCollection services)
        {
            services.AddScoped<ProductQueryHandler>();
        }

        private static void RegisterResponses(this IServiceCollection services)
        {
            services.AddScoped<Response>();
            services.AddScoped(typeof(Response<>));

            services.AddScoped<Response>();
        }
    }
}
