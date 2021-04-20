using System;
using System.Collections.Generic;
using System.Reflection;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Entities.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Infrastructure.Data
{
    public sealed class CarRentalSystemContext: DbContext
    {
        public DbSet<PointOfRental> PointOfRentals { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<AdditionalService> AdditionalServices { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderAdditionalService> OrderAdditionalServices { get; set; }

        public CarRentalSystemContext(DbContextOptions<CarRentalSystemContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            CreateTestDataBase(modelBuilder);
        }

        private void CreateTestDataBase(ModelBuilder modelBuilder)
        {
            PointOfRental firstPoint = new PointOfRental
            {
                Id = 1,
                Name = "First Point",
                Country = "Belarus",
                City = "Minsk",
                Address = "First Address"
            };

            Car nissan = new Car
            {
                Id = 1,
                Brand = "Nissan",
                NumberOfSeats = 2,
                AverageFuelConsumption = 100,
                CostPerHour = 1000,
                TransmissionType = "Mechanic",
                PointOfRentalId = 1,
                CurrentOrderId = 1
            };

            Car toyota = new Car
            {
                Id = 2,
                Brand = "Toyota",
                NumberOfSeats = 4,
                AverageFuelConsumption = 200,
                CostPerHour = 500,
                TransmissionType = "Automatic",
                PointOfRentalId = 1,
                CurrentOrderId = 2
            };

            User john = new User
            {
                Id = 1,
                Name = "John",
                SurName = "Mars",
                Login = "ReadDead@gmail.com",
                Password = "HnEjhGC5",
                Role = Role.Administrator,
            };

            User arthur = new User
            {
                Id = 2,
                Name = "Arthur",
                SurName = "Morgan",
                Login = "Redemption2@gmail.com",
                Password = "12345",
                Role = Role.Customer
            };

            AdditionalService babyChair = new AdditionalService
            {
                Id = 1,
                Name = "Baby chair",
                Cost = 20
            };

            AdditionalService fullTank = new AdditionalService
            {
                Id = 2,
                Name = "Fill a full tank",
                Cost = 100
            };

            Order firstOrder = new Order
            {
                Id = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.MaxValue,
                CurrentCustomerId = 1,
                CarId = 1,
                PointOfRentalId = 1,
                TotalCost = 0
            };

            Order secondOrder = new Order
            {
                Id = 2,
                StartDate = DateTime.Now,
                EndDate = DateTime.MaxValue,
                CurrentCustomerId = 1,
                CarId = 2,
                PointOfRentalId = 1,
                TotalCost = 0
            };

            OrderAdditionalService firstOrderService = new OrderAdditionalService()
            {
                Id = 1,
                OrderId = 1,
                AdditionalServiceId = 1
            };

            OrderAdditionalService secondOrderService = new OrderAdditionalService()
            {
                Id = 2,
                OrderId = 1,
                AdditionalServiceId = 2
            };

            OrderAdditionalService thirdOrderService = new OrderAdditionalService()
            {
                Id = 3,
                OrderId = 2,
                AdditionalServiceId = 1
            };

            modelBuilder.Entity<PointOfRental>().HasData(new List<PointOfRental>
            {
                firstPoint
            });

            modelBuilder.Entity<Car>().HasData(new List<Car>
            {
                nissan,
                toyota
            });

            modelBuilder.Entity<User>().HasData(new List<User>
            {
                john,
                arthur
            });

            modelBuilder.Entity<AdditionalService>().HasData(new List<AdditionalService>
            {
                babyChair,
                fullTank
            });

            modelBuilder.Entity<Order>().HasData(new List<Order>
            {
                firstOrder,
                secondOrder,
            });

            modelBuilder.Entity<OrderAdditionalService>().HasData(new List<OrderAdditionalService>
            {
                firstOrderService,
                secondOrderService,
                thirdOrderService
            });
        }
    }
}
