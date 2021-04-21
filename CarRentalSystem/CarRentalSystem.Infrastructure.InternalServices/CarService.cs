using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<CarModel> GetCar(int id)
        {
            Car car = await Task.Run(() =>
                _repository.Include(c => c.PointOfRental).FirstOrDefault(carId => carId.Id == id));

            if (car == null)
            {
                throw new NullReferenceException();
            }

            return _mapper.Map<CarModel>(car);
        }

        public async Task AddCar(CarModel addedCar)
        {
            await Task.Run(() =>_repository.Create(_mapper.Map<Car>(addedCar)));
        }
    }
}
