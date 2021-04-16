using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface ICarService
    {
        CarModel GetCar(int id);
        bool AddCar(CarModel addedCar);
    }
}
