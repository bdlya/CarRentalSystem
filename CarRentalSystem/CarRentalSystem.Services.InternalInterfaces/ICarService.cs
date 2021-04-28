using System.Threading.Tasks;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface ICarService
    {
        Task AddCarAsync(CarModel addableCar);
        Task<CarModel> GetCarAsync(int id);
        Task DeleteCarAsync(int id);
        Task ModifyCarAsync(int id, CarModel modifiedCar);
        Task AddOrderAsync(int id, OrderModel order);
    }
}
