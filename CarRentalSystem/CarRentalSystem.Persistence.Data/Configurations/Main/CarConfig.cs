using CarRentalSystem.Domain.Entities.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Persistence.Data.Configurations.Main
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