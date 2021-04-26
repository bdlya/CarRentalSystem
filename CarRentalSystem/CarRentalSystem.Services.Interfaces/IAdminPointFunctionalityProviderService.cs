using CarRentalSystem.Infrastructure.Data.Models;
using System.Threading.Tasks;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IAdminPointFunctionalityProviderService
    {
        Task AddPointAsync(PointOfRentalModel addablePoint);
        Task<PointOfRentalModel> GetPointAsync(int id);
        Task ModifyPointAsync(int id, PointOfRentalModel modifiedPoint);
    }
}