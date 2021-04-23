using CarRentalSystem.Infrastructure.InternalServices;
using CarRentalSystem.Infrastructure.Services;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Helpers
{
    public static class ServiceConfigurator
    {
        public static void ConfigureProjectServices(IServiceCollection services)
        {
            services.AddScoped<IAdminCarFunctionalityProviderService, AdminCarFunctionalityProviderService>();
            services.AddScoped<ICarService, CarService>();

            services.AddScoped<IAdminPointFunctionalityProviderService, AdminPointFunctionalityProviderService>();
            services.AddScoped<IPointService, PointService>();

            services.AddScoped<IServiceOrderService, ServiceOrderService>();
            services.AddScoped<IServiceOrderProviderService, ServiceOrderProviderService>();

            services.AddScoped<IUserProviderService, UserProviderService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}