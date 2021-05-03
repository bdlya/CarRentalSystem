using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Infrastructure.Data.Models.Base;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IAdminUserFunctionalityProviderService
    {
        Task CreateAdminAsync(RegistrationModel admin);
        Task DeleteAdminAsync(int id);
        Task<IQueryable<UserModel>> GetAllAdminsAsync();
    }
}