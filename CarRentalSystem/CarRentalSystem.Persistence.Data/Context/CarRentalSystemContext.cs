using System.Collections.Generic;
using CarRentalSystem.Domain.Entities.Main;
using CarRentalSystem.Domain.Entities.Support;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace CarRentalSystem.Persistence.Data.Context
{
    public sealed class CarRentalSystemContext: DbContext
    {
        public DbSet<PointOfRental> PointOfRentals { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<AdditionalWork> AdditionalWorks { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderAdditionalWork> OrderAdditionalWorks { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public CarRentalSystemContext(DbContextOptions<CarRentalSystemContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            CreateInitialDataBase(modelBuilder);
        }

        private static void CreateInitialDataBase(ModelBuilder modelBuilder)
        {
            AddUsers(modelBuilder);
            AddPoints(modelBuilder);
            AddCars(modelBuilder);
        }

        private static void AddUsers(ModelBuilder modelBuilder)
        {
            const string adminOwnerPassword = "HnEjhGC5";
            CreatePasswordHash(adminOwnerPassword, out byte[] passwordHash, out byte[] passwordSalt);

            User adminOwner = new User
            {
                Id = 1,
                Name = "Admin",
                SurName = "Owner",
                Login = "adminOwner",
                Role = "AdministratorOwner",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            modelBuilder
                .Entity<User>()
                .HasData(adminOwner);
        }

        private static void AddPoints(ModelBuilder modelBuilder)
        {
            PointOfRental firstPoint = new PointOfRental
            {
                Id = 1,
                Name = "CFL",
                Country = "Belarus",
                City = "Minsk",
                Address = "Default address street one"
            };

            PointOfRental secondPoint = new PointOfRental
            {
                Id = 2,
                Name = "CFL",
                Country = "Belarus",
                City = "Hrodna",
                Address = "Default address street two"
            };

            PointOfRental thirdPoint = new PointOfRental
            {
                Id = 3,
                Name = "SpaceStation",
                Country = "Russia",
                City = "Moscow",
                Address = "Default address street three"
            };

            PointOfRental fourthPoint = new PointOfRental
            {
                Id = 4,
                Name = "Independence",
                Country = "Canada",
                City = "Montreal",
                Address = "Default address street four"
            };

            PointOfRental fifthPoint = new PointOfRental
            {
                Id = 5,
                Name = "NoTime",
                Country = "Canada",
                City = "Toronto",
                Address = "Default address street five"
            };

            PointOfRental sixthPoint = new PointOfRental
            {
                Id = 6,
                Name = "Expensive",
                Country = "Canada",
                City = "Toronto",
                Address = "Default address street six"
            };

            modelBuilder
                .Entity<PointOfRental>()
                .HasData(new List<PointOfRental>
                {
                    firstPoint,
                    secondPoint,
                    thirdPoint,
                    fourthPoint,
                    fifthPoint,
                    sixthPoint
                });
        }

        private static void AddCars(ModelBuilder modelBuilder)
        {
            Car firstCar = new Car() {Id = 1, Brand = "Audi", NumberOfSeats = 4, AverageFuelConsumption = 10, TransmissionType = "Mechanic", CostPerHour = 100, PointOfRentalId = 1};
            Car secondCar = new Car() {Id = 2, Brand = "Audi", NumberOfSeats = 2, AverageFuelConsumption = 20, TransmissionType = "Mechanic", CostPerHour = 200, PointOfRentalId = 1};
            Car thirdCar = new Car() {Id = 3, Brand = "Audi", NumberOfSeats = 6, AverageFuelConsumption = 30, TransmissionType = "Automatic", CostPerHour = 300, PointOfRentalId = 1};
            Car fourthCar = new Car() {Id = 4, Brand = "Toyota", NumberOfSeats = 4, AverageFuelConsumption = 15, TransmissionType = "Mechanic", CostPerHour = 150, PointOfRentalId = 1};
            Car fifthCar = new Car() {Id = 5, Brand = "Toyota", NumberOfSeats = 2, AverageFuelConsumption = 25, TransmissionType = "Automatic", CostPerHour = 250, PointOfRentalId = 1};
            Car sixthCar = new Car() {Id = 6, Brand = "Toyota", NumberOfSeats = 10, AverageFuelConsumption = 50, TransmissionType = "Mechanic", CostPerHour = 500, PointOfRentalId = 2};
            Car seventhCar = new Car() {Id = 7, Brand = "Mitsubishi", NumberOfSeats = 10, AverageFuelConsumption = 50, TransmissionType = "Mechanic", CostPerHour = 500, PointOfRentalId = 2};
            Car eighthCar = new Car() {Id = 8, Brand = "Mitsubishi", NumberOfSeats = 1, AverageFuelConsumption = 35, TransmissionType = "Mechanic", CostPerHour = 400, PointOfRentalId = 2};
            Car ninthCar = new Car() {Id = 9, Brand = "Mitsubishi", NumberOfSeats = 4, AverageFuelConsumption = 60, TransmissionType = "Automatic", CostPerHour = 1000, PointOfRentalId = 2};
            Car tenthCar = new Car() { Id = 10, Brand = "Nissan", NumberOfSeats = 4, AverageFuelConsumption = 10, TransmissionType = "Mechanic", CostPerHour = 100, PointOfRentalId = 3};
            Car eleventhCar = new Car() {Id = 11, Brand = "Nissan", NumberOfSeats = 3, AverageFuelConsumption = 100, TransmissionType = "Mechanic", CostPerHour = 900, PointOfRentalId = 3};
            Car twelfthCar = new Car() {Id = 12, Brand = "Nissan", NumberOfSeats = 4, AverageFuelConsumption = 10, TransmissionType = "Mechanic", CostPerHour = 100, PointOfRentalId = 3};
            Car thirteenthCar = new Car() {Id = 13, Brand = "BMV", NumberOfSeats = 5, AverageFuelConsumption = 90, TransmissionType = "Automatic", CostPerHour = 150, PointOfRentalId = 4};
            Car fourteenthCar = new Car() {Id = 14, Brand = "BMV", NumberOfSeats = 2, AverageFuelConsumption = 15, TransmissionType = "Automatic", CostPerHour = 400, PointOfRentalId = 4};
            Car fifteenthCar = new Car() {Id = 15, Brand = "BMV", NumberOfSeats = 4, AverageFuelConsumption = 80, TransmissionType = "Automatic", CostPerHour = 150, PointOfRentalId = 5};
            Car sixteenthCar = new Car() {Id = 16, Brand = "Mercedes", NumberOfSeats = 1, AverageFuelConsumption = 100, TransmissionType = "Mechanic", CostPerHour = 160, PointOfRentalId = 6};
            Car seventeenthCar = new Car() {Id = 17, Brand = "Mercedes", NumberOfSeats = 5, AverageFuelConsumption = 90, TransmissionType = "Automatic", CostPerHour = 150, PointOfRentalId = 6};
            Car eighteenthCar = new Car() {Id = 18, Brand = "Volvo", NumberOfSeats = 4, AverageFuelConsumption = 75, TransmissionType = "Mechanic", CostPerHour = 300, PointOfRentalId = 6};
            Car nineteenthCar = new Car() {Id = 19, Brand = "Volvo", NumberOfSeats = 3, AverageFuelConsumption = 60, TransmissionType = "Mechanic", CostPerHour = 300, PointOfRentalId = 6};
            Car twentiethCar = new Car() {Id = 20, Brand = "Volvo", NumberOfSeats = 2, AverageFuelConsumption = 200, TransmissionType = "Automatic", CostPerHour = 500, PointOfRentalId = 6};

            modelBuilder
                .Entity<Car>()
                .HasData(new List<Car>
                {
                    firstCar,
                    secondCar,
                    thirdCar,
                    fourthCar,
                    fifthCar,
                    sixthCar,
                    seventhCar,
                    eighthCar,
                    ninthCar,
                    tenthCar,
                    eleventhCar,
                    twelfthCar,
                    thirteenthCar,
                    fourteenthCar,
                    fifteenthCar,
                    sixteenthCar,
                    seventeenthCar,
                    eighteenthCar,
                    nineteenthCar,
                    twentiethCar
                });
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
