using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalSystem.View.ViewModels;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IAdminCarFunctionalityProviderService
    {
        Task AddCarAsync(CarViewModel addableCar);
        Task<CarViewModel> GetCarAsync(int id);
        Task DeleteCarAsync(int id);
        Task ModifyCarAsync(int id, CarViewModel modifiedCar);
    }
}