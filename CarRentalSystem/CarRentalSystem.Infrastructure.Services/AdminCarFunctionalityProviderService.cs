using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;
using CarRentalSystem.View.ViewModels;

namespace CarRentalSystem.Infrastructure.Services
{
    public class AdminCarFunctionalityProviderService: IAdminCarFunctionalityProviderService
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public AdminCarFunctionalityProviderService(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        public async Task AddCarAsync(CarViewModel addableCar)
        {
            await _carService.AddCarAsync(_mapper.Map<CarModel>(addableCar));
        }

        public async Task<CarViewModel> GetCarAsync(int id)
        {
            CarModel car = await _carService.GetCarAsync(id);

            return _mapper.Map<CarViewModel>(car);
        }

        public async Task DeleteCarAsync(int id)
        {
            await _carService.DeleteCarAsync(id);
        }

        public async Task ModifyCarAsync(int id, CarViewModel modifiedCar)
        {
            await _carService.ModifyCarAsync(id, _mapper.Map<CarModel>(modifiedCar));
        }
    }
}