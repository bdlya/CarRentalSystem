using System;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data;
using CarRentalSystem.Infrastructure.InternalServices;
using CarRentalSystem.Infrastructure.Services;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalSystem.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCarRentalSystemServices(this IServiceCollection collection)
        {
            return collection
                .AddCarService()
                .AddCarIdService()
                .AddCarRentalSystemRepository();
        }
        public static IServiceCollection AddCarService(this IServiceCollection collection)
        {
            return collection.AddScoped<ICarService, CarService>();
        }

        public static IServiceCollection AddCarIdService(this IServiceCollection collection)
        {
            return collection.AddScoped<ICarIdService, CarIdService>();
        }

        public static IServiceCollection AddCarRentalSystemRepository(this IServiceCollection collection)
        {
            return collection.AddScoped<IRentalRepository<Car>, CarRentalSystemGenericRepository<Car>>();
        }
    }
}
