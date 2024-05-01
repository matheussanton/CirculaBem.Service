using CirculaBem.Service.Dependencies.Extensions;
using Microsoft.OpenApi.Models;

namespace CirculaBem.Service.Host
{
    public class Startup(IConfiguration configuration, IHostEnvironment env)
    {

        public IConfiguration Configuration { get; } = configuration;
        public IHostEnvironment CurrentEnvironment { get; } = env;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            var appSettings = services.RegisterAppSettings(Configuration);

            Console.WriteLine($"AppSettings.ConnString: {appSettings.PostgreSQLConnectionString}");

            services.RegisterAuthentication(appSettings.JwtSecretKey);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CirculaBem Service", Description = "Service for CirculaBem.", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert a JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            services.RegisterDataLayerDependencies(appSettings, Configuration);
            services.RegisterDomainDependencies();

            services.AddLogging();

            services.AddSignalR();
        }

        public void Configure(WebApplication app, IHostEnvironment env)
        {
            if (CurrentEnvironment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder =>
                builder
                .WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                );

            //app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            // app.MapHub<NotificationHub>("/notifications");

            // using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
            // {
            //     var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
            //     context.Database.Migrate();
            // }
        }


    }
}
