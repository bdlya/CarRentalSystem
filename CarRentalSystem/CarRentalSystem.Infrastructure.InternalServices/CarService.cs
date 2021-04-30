using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Infrastructure.ExceptionHandling.Exceptions;
using CarRentalSystem.Services.InternalInterfaces;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            var cars = await _repository.GetAsQueryable();
            CarModel car = _mapper.Map<CarModel>(cars
                .Include(c => c.CurrentOrder)
                .FirstOrDefault(c => c.Id == id));

            if (car == null)
            {
                throw new EntityNotFoundException(nameof(Car));
            }

            return car;
        }

        public async Task DeleteCarAsync(int id)
        {
            CarModel car = _mapper.Map<CarModel>(await _repository.FindByIdAsync(id));

            if (car == null)
            {
                throw new EntityNotFoundException(nameof(Car));
            }

            await _repository.RemoveAsync(_mapper.Map<Car>(car));
        }

        public async Task ModifyCarAsync(int id, CarModel modifiedCar)
        {
            CarModel car = _mapper.Map<CarModel>(await _repository.FindByIdAsync(id));

            if (car == null)
            {
                throw new EntityNotFoundException(nameof(Car));
            }

            car = UpdateCarProperties(car, modifiedCar);

            await _repository.UpdateAsync(_mapper.Map<Car>(car));
        }

        public async Task AddOrderAsync(int id, OrderModel order)
        {
            var cars = await _repository.GetAsQueryable();
            CarModel car = _mapper.Map<CarModel>(cars
                .Include(c => c.CurrentOrder)
                .FirstOrDefault(c => c.Id == id));

            if (car == null)
            {
                throw new EntityNotFoundException(nameof(Car));
            }

            car.CurrentOrderId = order.Id;

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
