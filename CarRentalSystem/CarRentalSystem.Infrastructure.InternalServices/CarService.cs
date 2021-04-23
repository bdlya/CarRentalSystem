using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.InternalInterfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

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
            await _repository.Create(_mapper.Map<Car>(addableCar));
        }

        public async Task<CarModel> GetCarAsync(int id)
        {
            Car car = await _repository
                .Include(c => c.PointOfRental)
                .ContinueWith(cars => cars.Result
                    .FirstOrDefault(c => c.Id == id));

            if (car == null)
            {
                throw new NullReferenceException();
            }

            return _mapper.Map<CarModel>(car);
        }

        public async Task DeleteCarAsync(int id)
        {
            Car car = await _repository.FindById(id);

            if (car == null)
            {
                throw new NullReferenceException();
            }

            await _repository.Remove(car);
        }

        public async Task ModifyCarAsync(int id, CarModel modifiedCar)
        {
            Car car = await _repository.FindById(id);

            if (car == null)
            {
                throw new NullReferenceException();
            }

            car = UpdateCarProperties(car, _mapper.Map<Car>(modifiedCar));

            await _repository.Update(car);
        }

        private Car UpdateCarProperties(Car car, Car modifiedCar)
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
