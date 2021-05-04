using CarRentalSystem.Application.ExternalServices.Implementation.Administrator.Common;
using CarRentalSystem.Application.ExternalServices.Implementation.Administrator.Moderator;
using CarRentalSystem.Application.ExternalServices.Implementation.Administrator.Owner;
using CarRentalSystem.Application.ExternalServices.Implementation.Common;
using CarRentalSystem.Application.ExternalServices.Implementation.User;
using CarRentalSystem.Application.ExternalServices.Interfaces.Administrator.Common;
using CarRentalSystem.Application.ExternalServices.Interfaces.Administrator.Moderator;
using CarRentalSystem.Application.ExternalServices.Interfaces.Administrator.Owner;
using CarRentalSystem.Application.ExternalServices.Interfaces.Common;
using CarRentalSystem.Application.ExternalServices.Interfaces.User;
using CarRentalSystem.Application.InternalServices.Implementation.Main;
using CarRentalSystem.Application.InternalServices.Implementation.Support;
using CarRentalSystem.Application.InternalServices.Interfaces.Main;
using CarRentalSystem.Application.InternalServices.Interfaces.Support;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalSystem.Presentation.API.Helpers
{
    public static class ServiceConfigurator
    {
        public static void ConfigureProjectServices(IServiceCollection services)
        {
            services.AddScoped<IAdminCarFunctionalityProviderService, AdminCarFunctionalityProviderService>();
            services.AddScoped<ICarService, CarService>();

            services.AddScoped<IAdminPointFunctionalityProviderService, AdminPointFunctionalityProviderService>();
            services.AddScoped<IPointService, PointService>();

            services.AddScoped<IAdminServiceFunctionalityProviderService, AdminWorkFunctionalityProviderService>();
            services.AddScoped<IAdditionalWorkService, AdditionalWorkService>();

            services.AddScoped<IUserProviderService, UserProviderService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ISearchProviderService, SearchProviderService>();

            services.AddScoped<IBookingProviderService, BookingProviderService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderAdditionalWorkService, OrderAdditionalWorkService>();

            services.AddScoped<IUserProfileProviderService, UserProfileProviderService>();

            services.AddScoped<IAdminUserFunctionalityProviderService, AdminUserFunctionalityProviderService>();
        }
    }
}