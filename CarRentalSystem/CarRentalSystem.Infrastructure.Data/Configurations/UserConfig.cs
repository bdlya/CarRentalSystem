using CarRentalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Infrastructure.Data.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(user => user.Orders)
                .WithOne(order => order.CurrentCustomer)
                .HasForeignKey(order => order.CurrentCustomerId);

            builder
                .HasOne(user => user.RefreshToken)
                .WithOne(token => token.User)
                .HasForeignKey<User>(user => user.RefreshTokenId);
            
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}