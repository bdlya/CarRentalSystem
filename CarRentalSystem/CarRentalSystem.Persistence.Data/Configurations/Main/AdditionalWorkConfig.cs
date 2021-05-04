using CarRentalSystem.Domain.Entities.Main;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Persistence.Data.Configurations.Main
{
    public class AdditionalWorkConfig : IEntityTypeConfiguration<AdditionalWork>
    {
        public void Configure(EntityTypeBuilder<AdditionalWork> builder)
        {
            builder
                .HasMany(service => service.OrderAdditionalWorks)
                .WithOne(orderService => orderService.AdditionalService)
                .HasForeignKey(orderService => orderService.AdditionalServiceId);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}