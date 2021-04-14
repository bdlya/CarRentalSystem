using System;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;

namespace CarRentalSystem.Infrastructure.Services
{
    public class CarService : ICarService
    {
        private readonly ICarIdService _carService;

        public CarService(ICarIdService carService)
        {
            _carService = carService;
        }

        public string GetCar(int id)
        {
            return $"Car brand with id - {id}: {_carService.GetById(id)}";
        }
    }
}
