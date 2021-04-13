using System;
using CarRentalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Infrastructure.Data
{
    public sealed class CarRentalSystemContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarRentalSystemContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarRentalSystemDatabase;Trusted_Connection=True;");
        }
    }
}
