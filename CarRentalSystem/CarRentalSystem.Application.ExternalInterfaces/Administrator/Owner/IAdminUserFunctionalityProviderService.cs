using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.ExternalInterfaces.Administrator.Owner
{
    public interface IAdminUserFunctionalityProviderService
    {
        Task CreateAdminAsync(RegistrationModel admin);
        Task DeleteAdminAsync(int id);
        Task<IQueryable<UserModel>> GetAllAdminsAsync();
    }
}