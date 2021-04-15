using CarRentalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Infrastructure.Data.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasOne(order => order.Car)
                .WithOne(car => car.CurrentOrder)
                .HasForeignKey<Car>(car => car.CurrentOrderId);

            builder
                .HasOne(order => order.CurrentCustomer)
                .WithMany(customer => customer.Orders)
                .HasForeignKey(order => order.CurrentCustomerId);

            builder
                .HasMany(order => order.OrderAdditionalServices)
                .WithOne(orderService => orderService.Order)
                .HasForeignKey(orderService => orderService.OrderId);

            builder
                .HasOne(order => order.PointOfRental)
                .WithMany(point => point.Orders)
                .HasForeignKey(order => order.PointOfRentalId);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}