using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;
using System.Threading.Tasks;

namespace CarRentalSystem.Infrastructure.Services
{
    public class AdminCarFunctionalityProviderService: IAdminCarFunctionalityProviderService
    {
        private readonly ICarService _carService;

        public AdminCarFunctionalityProviderService(ICarService carService)
        {
            _carService = carService;
        }

        public async Task AddCarAsync(CarModel addableCar)
        {
            await _carService.AddCarAsync(addableCar);
        }

        public async Task<CarModel> GetCarAsync(int id)
        {
            return await _carService.GetCarAsync(id);
        }

        public async Task DeleteCarAsync(int id)
        {
            await _carService.DeleteCarAsync(id);
        }

        public async Task ModifyCarAsync(int id, CarModel modifiedCar)
        {
            await _carService.ModifyCarAsync(id, modifiedCar);
        }
    }
}