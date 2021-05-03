using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Infrastructure.Data.Policies;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

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
            const string adminOwnerPassword = "HnEjhGC5";
            CreatePasswordHash(adminOwnerPassword, out byte[] passwordHash, out byte[] passwordSalt);

            User adminOwner = new User
            {
                Id = 1,
                Name = "Admin",
                SurName = "Owner",
                Login = "adminOwner",
                Role = Policy.AdministratorOwner,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            modelBuilder
                .Entity<User>()
                .HasData(adminOwner);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
