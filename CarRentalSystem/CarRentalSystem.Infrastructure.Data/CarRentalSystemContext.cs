using CarRentalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;

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

            modelBuilder.Entity<PointOfRental>().HasData(new List<PointOfRental>
            {
                firstPoint
            });

            modelBuilder.Entity<Car>().HasData(new List<Car>
            {
                nissan,
                toyota
            });

            modelBuilder.Entity<AdditionalService>().HasData(new List<AdditionalService>
            {
                babyChair,
                fullTank
            });

        }
    }
}
