using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Gets called by a runtime. Adds services to the container and configures any options related to those services.
        /// </summary>
        /// <param name="services">container of services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Adds services for controllers
            services.AddControllers();
        }

        /// <summary>
        /// Gets called by a runtime. Configures the HTTP request pipeline.
        /// </summary>
        /// <param name="app">configures the request pipeline by adding middleware to it</param>
        /// <param name="env">provides information about the environment that the application is currently running in.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Checks if the current host environment name is "Development".
            if (env.IsDevelopment())
            {
                // if so adds middleware that enables detailed error messages to be rendered to the browser if the application raises exceptions when it is running.
                app.UseDeveloperExceptionPage();
            }

            // Adds middleware that redirects http requests to http.
            app.UseHttpsRedirection();

            // Adds middleware that enables routing (route matching). Middleware looks at the set of endpoints defined in the app and selects the best match based on request.
            app.UseRouting();

            // Adds middleware that enables authorization capabilities.
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
