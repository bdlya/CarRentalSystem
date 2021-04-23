using System.Threading.Tasks;
using CarRentalSystem.View.ViewModels;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IAdminPointFunctionalityProviderService
    {
        Task AddPointAsync(PointOfRentalViewModel addablePoint);
        Task<PointOfRentalViewModel> GetPointAsync(int id);
        Task ModifyPointAsync(int id, PointOfRentalViewModel modifiedPoint);
    }
}