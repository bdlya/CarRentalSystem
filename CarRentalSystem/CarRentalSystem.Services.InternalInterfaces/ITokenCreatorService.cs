using CarRentalSystem.Domain.Entities;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface ITokenCreatorService
    {
        User CreateTokenFor(User user);
    }
}