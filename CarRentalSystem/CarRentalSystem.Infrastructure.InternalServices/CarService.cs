using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.InternalInterfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.ExceptionHandling.Exceptions;

namespace CarRentalSystem.Infrastructure.InternalServices
{
    public class CarService : ICarService
    {
        private readonly IRentalRepository<Car> _repository;
        private readonly IMapper _mapper;

        public CarService(IRentalRepository<Car> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddCarAsync(CarModel addableCar)
        {
            await _repository.CreateAsync(_mapper.Map<Car>(addableCar));
        }

        public async Task<CarModel> GetCarAsync(int id)
        {
            CarModel car = _mapper.Map<CarModel>(await _repository
                .IncludeAsync(c => c.PointOfRental)
                .ContinueWith(cars => cars.Result
                    .FirstOrDefault(c => c.Id == id)));

            if (car == null)
            {
                throw new IdNotFoundException();
            }

            return car;
        }

        public async Task DeleteCarAsync(int id)
        {
            CarModel car = _mapper.Map<CarModel>(await _repository.FindByIdAsync(id));

            if (car == null)
            {
                throw new IdNotFoundException();
            }

            await _repository.RemoveAsync(_mapper.Map<Car>(car));
        }

        public async Task ModifyCarAsync(int id, CarModel modifiedCar)
        {
            CarModel car = _mapper.Map<CarModel>(await _repository.FindByIdAsync(id));

            if (car == null)
            {
                throw new IdNotFoundException();
            }

            car = UpdateCarProperties(car, modifiedCar);

            await _repository.UpdateAsync(_mapper.Map<Car>(car));
        }

        private CarModel UpdateCarProperties(CarModel car, CarModel modifiedCar)
        {
            car.Brand = modifiedCar.Brand;
            car.TransmissionType = modifiedCar.TransmissionType;
            car.AverageFuelConsumption = modifiedCar.AverageFuelConsumption;
            car.CostPerHour = modifiedCar.CostPerHour;
            car.PointOfRentalId = modifiedCar.PointOfRentalId;
            car.NumberOfSeats = modifiedCar.NumberOfSeats;

            return car;
        }
    }
}
