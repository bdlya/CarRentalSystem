using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface ICarService
    {
        Task<CarModel> GetCar(int id);
        Task AddCar(CarModel addedCar);
    }
}
