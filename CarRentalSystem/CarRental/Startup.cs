using CarRental.Helpers;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data;
using CarRentalSystem.Infrastructure.ExceptionHandling;
using CarRentalSystem.Infrastructure.Mapping.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental
{
    /// <summary>
    /// Configures services and the application's request pipeline.
    /// Specified when the application's host is built.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Performs application configuration using configuration provider.
        /// </summary>
        /// <param name="configuration">configuration provider, which contains configuration properties.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        /// <summary>
        /// Gets called by a runtime. Adds services to the container and configures any options related to those services.
        /// </summary>
        /// <param name="services">container of services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Adds services for controllers
            services.AddControllers();

            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(CarRentalSystemProfile));

            services.AddScoped<DbContext, CarRentalSystemContext>();
            services.AddDbContext<CarRentalSystemContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    migrationOptions => migrationOptions.MigrationsAssembly("CarRentalSystem.Infrastructure.Data")));

            services.AddScoped(typeof(IRentalRepository<>), typeof(CarRentalSystemGenericRepository<>));

            JwtConfigurator.Configure(Configuration, services);
            ServiceConfigurator.ConfigureProjectServices(services);
        }

        /// <summary>
        /// Gets called by a runtime. Configures the HTTP request pipeline.
        /// </summary>
        /// <param name="app">configures the request pipeline by adding middleware to it</param>
        /// <param name="env">provides information about the environment that the application is currently running in.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseSwagger();

            app.UseSwaggerUI(endpoint =>
            {
                endpoint.SwaggerEndpoint("/swagger/v1/swagger.json", "Car rental API");
            });

            // Adds middleware that redirects http requests to http.
            app.UseHttpsRedirection();

            // Adds middleware that enables routing (route matching). Middleware looks at the set of endpoints defined in the app and selects the best match based on request.
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // Adds middleware that enables routing (endpoint execution). Middleware runs the delegate associated with the selected endpoint.
            app.UseEndpoints(endpoints =>
            {
                // Adds endpoints for controller actions
                endpoints.MapControllers();
            });
        }
    }
}
