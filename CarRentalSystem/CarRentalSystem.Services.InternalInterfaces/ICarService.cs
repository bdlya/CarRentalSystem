using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface ICarService
    {
        CarModel GetCar(int id);
        void AddCar(CarModel addedCar);
    }
}
