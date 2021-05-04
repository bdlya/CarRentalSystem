using System.Threading.Tasks;
using CarRentalSystem.Application.Data.Models.Main;

namespace CarRentalSystem.Application.InternalServices.Interfaces.Support
{
    public interface ITokenCreatorService
    {
        Task<UserModel> CreateTokensForUserAsync(UserModel user);
    }
}