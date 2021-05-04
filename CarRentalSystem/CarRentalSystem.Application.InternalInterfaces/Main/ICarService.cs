using System.Threading.Tasks;
using CarRentalSystem.Application.Data.Models.Main;


namespace CarRentalSystem.Application.InternalInterfaces.Main
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
