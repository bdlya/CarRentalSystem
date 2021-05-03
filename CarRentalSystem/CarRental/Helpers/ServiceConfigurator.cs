﻿using CarRentalSystem.Infrastructure.InternalServices;
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

            services.AddScoped<IAdminServiceFunctionalityProviderService, AdminServiceFunctionalityProviderService>();
            services.AddScoped<IAdditionalService, AdditionalServicesService>();

            services.AddScoped<IUserProviderService, UserProviderService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ISearchProviderService, SearchProviderService>();

            services.AddScoped<IBookingProviderService, BookingProviderService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderAdditionalService, OrderAdditionalServicesService>();

            services.AddScoped<IUserProfileProviderService, UserProfileProviderService>();

            services.AddScoped<IAdminUserFunctionalityProviderService, AdminUserFunctionalityProviderService>();
        }
    }
}