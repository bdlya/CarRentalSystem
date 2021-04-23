using System.Threading.Tasks;
using CarRentalSystem.Domain.Entities;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface ITokenCreatorService
    {
        Task<User> CreateTokensForUser(User user);
    }
}