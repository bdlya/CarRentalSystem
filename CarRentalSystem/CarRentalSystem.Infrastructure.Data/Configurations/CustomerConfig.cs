using CarRentalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Infrastructure.Data.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(customer => customer.Orders)
                .WithOne(order => order.CurrentCustomer)
                .HasForeignKey(order => order.CurrentCustomerId);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}