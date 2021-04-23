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
            services.AddScoped<IAdminFunctionalityProviderService, AdminFunctionalityProviderService>();
            services.AddScoped<ICarService, CarService>();

            services.AddScoped<IServiceOrderService, ServiceOrderService>();
            services.AddScoped<IServiceOrderProviderService, ServiceOrderProviderService>();

            services.AddScoped<IUserProviderService, UserProviderService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}