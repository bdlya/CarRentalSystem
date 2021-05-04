using AutoMapper;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.InternalServices.Interfaces.Main;
using CarRentalSystem.Domain.Entities.Main;
using CarRentalSystem.Domain.Interfaces.Repository;
using CarRentalSystem.Infrastructure.ExceptionHandling.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.InternalServices.Implementation.Main
{
    public class CarService : ICarService
    {
        private readonly ICarRentalSystemRepository<Car> _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRentalSystemRepository<Car> carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task AddCarAsync(CarModel addableCar)
        {
            await _carRepository.CreateAsync(_mapper.Map<Car>(addableCar));
        }

        public async Task<CarModel> GetCarAsync(int id)
        {
            var cars = await _carRepository.GetAsQueryable();
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
            CarModel car = _mapper.Map<CarModel>(await _carRepository.FindByIdAsync(id));

            if (car == null)
            {
                throw new EntityNotFoundException(nameof(Car));
            }

            await _carRepository.RemoveAsync(_mapper.Map<Car>(car));
        }

        public async Task ModifyCarAsync(int id, CarModel modifiedCar)
        {
            CarModel car = _mapper.Map<CarModel>(await _carRepository.FindByIdAsync(id));

            if (car == null)
            {
                throw new EntityNotFoundException(nameof(Car));
            }

            car = UpdateCarProperties(car, modifiedCar);

            await _carRepository.UpdateAsync(_mapper.Map<Car>(car));
        }

        public async Task AddOrderAsync(int id, OrderModel order)
        {
            var cars = await _carRepository.GetAsQueryable();
            CarModel car = _mapper.Map<CarModel>(cars
                .Include(c => c.CurrentOrder)
                .FirstOrDefault(c => c.Id == id));

            if (car == null)
            {
                throw new EntityNotFoundException(nameof(Car));
            }

            car.CurrentOrderId = order.Id;

            await _carRepository.UpdateAsync(_mapper.Map<Car>(car));
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
