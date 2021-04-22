using CarRentalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Infrastructure.Data.Configurations
{
    public class RefreshTokenConfig: IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder
                .HasOne(token => token.User)
                .WithOne(user => user.RefreshToken)
                .HasForeignKey<RefreshToken>(token => token.UserId);

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

        }
    }
}