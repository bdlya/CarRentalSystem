using System.Collections.Generic;
using CarRentalSystem.Domain.Entities.Main;
using CarRentalSystem.Domain.Entities.Support;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using CarRentalSystem.Persistence.Data.Helpers.Interfaces;

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
            SeedDatabase(modelBuilder);
        }

        private static void SeedDatabase(ModelBuilder modelBuilder)
        {
           
        }

        private static void SeedData<TEntity, TEntityCreator>(ModelBuilder modelBuilder)
            where TEntityCreator : IEntitiesCreator<TEntity>, new()
            where TEntity : class
        {
            IEnumerable<TEntity> entities = new TEntityCreator().CreateEntities();

            modelBuilder
                .Entity<TEntity>()
                .HasData(entities);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
