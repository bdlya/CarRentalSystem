using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;
using CarRentalSystem.View.ViewModels;

namespace CarRentalSystem.Infrastructure.Services
{
    public class CarProviderService : ICarProviderService
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarProviderService(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        public async Task<string> GetCar(int id)
        {
            CarModel model = await Task.Run(() => _carService.GetCar(id));
            CarViewModel viewModel = _mapper.Map<CarViewModel>(model);
  
            return $"Car brand with id - {id}: {viewModel.Brand} in point of rental {viewModel.PointOfRental.Name}";
        }

        public async Task AddCar(CarViewModel addedCar)
        {
            await Task.Run(() => _carService.AddCar(_mapper.Map<CarModel>(addedCar)));
        }
    }
}
