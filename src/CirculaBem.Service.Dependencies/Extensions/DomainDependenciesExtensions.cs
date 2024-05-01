using CirculaBem.Service.Domain.User.Commands.Handler;
using CirculaBem.Service.Domain.Responses;
using Microsoft.Extensions.DependencyInjection;

namespace CirculaBem.Service.Dependencies.Extensions
{
    public static class DomainDependenciesExtensions
    {
        public static void RegisterDomainDependencies(this IServiceCollection services)
        {
            RegisterHandlers(services);
            RegisterResponses(services);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }

        private static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddScoped<UserHandler>();
        }

        private static void RegisterResponses(this IServiceCollection services)
        {
            services.AddScoped<Response>();
            services.AddScoped(typeof(Response<>));

            services.AddScoped<Response>();
        }
    }
}
