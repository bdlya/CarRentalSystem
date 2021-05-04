using System.Threading.Tasks;
using CarRentalSystem.Application.Data.Models.Main;

namespace CarRentalSystem.Application.ExternalServices.Interfaces.Administrator.Common
{
    public interface IAdminPointFunctionalityProviderService
    {
        Task AddPointAsync(PointOfRentalModel addablePoint);
        Task<PointOfRentalModel> GetPointAsync(int id);
        Task ModifyPointAsync(int id, PointOfRentalModel modifiedPoint);
    }
}