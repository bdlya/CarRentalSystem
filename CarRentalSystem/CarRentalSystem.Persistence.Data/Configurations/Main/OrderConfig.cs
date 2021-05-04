using CarRentalSystem.Domain.Entities.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Persistence.Data.Configurations.Main
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
                .HasMany(order => order.OrderAdditionalWorks)
                .WithOne(orderService => orderService.Order)
                .HasForeignKey(orderService => orderService.OrderId);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}