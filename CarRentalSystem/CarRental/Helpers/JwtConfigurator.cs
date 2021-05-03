using System.Text;
using CarRentalSystem.Infrastructure.Data.Policies;
using CarRentalSystem.Infrastructure.InternalServices;
using CarRentalSystem.Services.InternalInterfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CarRental.Helpers
{
    public static class JwtConfigurator
    {
        public static void Configure(IConfiguration configuration, IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(configuration["SecretKey"]);

            services.AddAuthentication(options => 
            { 
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policy.Administrator, Policy.AdministratorPolicy());
                options.AddPolicy(Policy.Customer, Policy.CustomerPolicy());
                options.AddPolicy(Policy.AdministratorOwner, Policy.AdministratorOwnerPolicy());
                options.AddPolicy(Policy.OwnerOrAdministrator, Policy.OwnerOrAdministratorPolicy());
            });

            services.AddScoped<ITokenCreatorService, TokenCreatorService>();
        }

    }
}