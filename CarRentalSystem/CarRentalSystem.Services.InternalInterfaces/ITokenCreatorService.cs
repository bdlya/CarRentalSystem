using CarRentalSystem.Domain.Entities;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface ITokenCreatorService
    {
        User CreateTokensForUser(User user);
    }
}