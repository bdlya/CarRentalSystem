using System.Linq;
using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.InternalInterfaces;

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

        public CarModel GetCar(int id)
        {
            return _mapper
                .Map<CarModel>(_repository
                .Include(car => car.PointOfRental)
                .FirstOrDefault(carId => carId.Id == id));
        }

        public void AddCar(CarModel addedCar)
        {
            _repository.Create(_mapper.Map<Car>(addedCar));
        }
    }
}
