using CarRentalSystem.Domain.Entities.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Persistence.Data.Configurations.Support
{
    public class OrderAdditionalWorkConfig : IEntityTypeConfiguration<OrderAdditionalWork>
    {
        public void Configure(EntityTypeBuilder<OrderAdditionalWork> builder)
        {
            builder
                .HasKey(orderService => new {AdditionalWorkId = orderService.AdditionalServiceId, orderService.OrderId});

            builder
                .HasOne(orderService => orderService.Order)
                .WithMany(order => order.OrderAdditionalWorks)
                .HasForeignKey(orderService => orderService.OrderId);

            builder
                .HasOne(orderService => orderService.AdditionalService)
                .WithMany(service => service.OrderAdditionalWorks)
                .HasForeignKey(orderService => orderService.AdditionalServiceId);
        }
    }
}