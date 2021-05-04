using System.Threading.Tasks;
using CarRentalSystem.Application.Data.Models.Main;

namespace CarRentalSystem.Application.InternalInterfaces.Support
{
    public interface ITokenCreatorService
    {
        Task<UserModel> CreateTokensForUserAsync(UserModel user);
    }
}