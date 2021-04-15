using CarRentalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Infrastructure.Data.Configurations
{
    public class OrderAdditionalServiceConfig : IEntityTypeConfiguration<OrderAdditionalService>
    {
        public void Configure(EntityTypeBuilder<OrderAdditionalService> builder)
        {
            builder
                .HasKey(orderService => new {orderService.AdditionalServiceId, orderService.OrderId});

            builder
                .HasOne(orderService => orderService.Order)
                .WithMany(order => order.OrderAdditionalServices)
                .HasForeignKey(orderService => orderService.OrderId);

            builder
                .HasOne(orderService => orderService.AdditionalService)
                .WithMany(service => service.OrderAdditionalServices)
                .HasForeignKey(orderService => orderService.AdditionalServiceId);
        }
    }
}