using CarRentalSystem.Domain.Entities.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Persistence.Data.Configurations.Main
{
    public class PointOfRentalConfig: IEntityTypeConfiguration<PointOfRental>
    {
        public void Configure(EntityTypeBuilder<PointOfRental> builder)
        {
            builder
                .HasMany(point => point.Cars)
                .WithOne(car => car.PointOfRental)
                .HasForeignKey(car => car.PointOfRentalId);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}