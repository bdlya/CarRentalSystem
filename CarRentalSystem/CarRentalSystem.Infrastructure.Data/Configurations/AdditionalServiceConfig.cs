using CarRentalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Infrastructure.Data.Configurations
{
    public class AdditionalServiceConfig : IEntityTypeConfiguration<AdditionalService>
    {
        public void Configure(EntityTypeBuilder<AdditionalService> builder)
        {
            builder
                .HasMany(service => service.OrderAdditionalServices)
                .WithOne(orderService => orderService.AdditionalService)
                .HasForeignKey(orderService => orderService.AdditionalServiceId);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}