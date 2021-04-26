using CarRentalSystem.Infrastructure.Data.Models;
using System.Threading.Tasks;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface ITokenCreatorService
    {
        Task<UserModel> CreateTokensForUserAsync(UserModel user);
    }
}