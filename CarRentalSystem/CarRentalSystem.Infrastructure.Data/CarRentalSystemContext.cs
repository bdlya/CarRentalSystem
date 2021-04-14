using System;
using System.Collections.Generic;
using CarRentalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Infrastructure.Data
{
    public sealed class CarRentalSystemContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarRentalSystemContext(DbContextOptions<CarRentalSystemContext> options)
            :base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(new List<Car>
            {
                new Car(1,"Toyota"),
                new Car(2,"Mercedes")
            });
           
        }
    }
}
