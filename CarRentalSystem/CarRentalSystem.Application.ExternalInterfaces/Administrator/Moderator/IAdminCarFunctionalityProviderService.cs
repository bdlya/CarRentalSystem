using CarRentalSystem.Application.Data.Models.Main;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.ExternalInterfaces.Administrator.Moderator
{
    public interface IAdminCarFunctionalityProviderService
    {
        Task AddCarAsync(CarModel addableCar);
        Task<CarModel> GetCarAsync(int id);
        Task DeleteCarAsync(int id);
        Task ModifyCarAsync(int id, CarModel modifiedCar);
    }
}