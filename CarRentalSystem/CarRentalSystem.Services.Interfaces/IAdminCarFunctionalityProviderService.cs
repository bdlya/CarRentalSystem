using CarRentalSystem.Infrastructure.Data.Models;
using System.Threading.Tasks;

namespace CarRentalSystem.Services.Interfaces
{
    public interface IAdminCarFunctionalityProviderService
    {
        Task AddCarAsync(CarModel addableCar);
        Task<CarModel> GetCarAsync(int id);
        Task DeleteCarAsync(int id);
        Task ModifyCarAsync(int id, CarModel modifiedCar);
    }
}