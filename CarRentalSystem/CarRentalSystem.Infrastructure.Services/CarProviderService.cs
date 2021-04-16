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

        public string GetCar(int id)
        {
            CarViewModel car = _mapper.Map<CarViewModel>(_carService.GetCar(id));
            return $"Car brand with id - {id}: {car.Brand} in point of rental {car.PointOfRental.Name}";
        }

        public void AddCar(CarViewModel addedCar)
        {
            _carService.AddCar(_mapper.Map<CarModel>(addedCar));
        }
    }

   
}
