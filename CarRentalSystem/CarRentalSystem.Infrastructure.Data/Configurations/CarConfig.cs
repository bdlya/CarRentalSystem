using CarRentalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Infrastructure.Data.Configurations
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasOne(car => car.PointOfRental)
                .WithMany(point => point.Cars)
                .HasForeignKey(car => car.PointOfRentalId);

            builder
                .HasOne(car => car.CurrentOrder)
                .WithOne(order => order.Car)
                .HasForeignKey<Order>(order => order.CarId);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}