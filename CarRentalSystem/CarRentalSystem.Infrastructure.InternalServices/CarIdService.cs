using System;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Infrastructure.Data;
using CarRentalSystem.Services.InternalInterfaces;

namespace CarRentalSystem.Infrastructure.InternalServices
{
    public class CarIdService : ICarIdService
    {
        public string GetById(int id)
        {
            var repository = CreateCarRepository(new CarRentalSystemContext());
            return repository.FindById(id).Brand;
        }

        private CarRentalSystemGenericRepository<Car> CreateCarRepository(CarRentalSystemContext context)
        {
            var repository = new CarRentalSystemGenericRepository<Car>(context);

            repository.Create(new Car("Toyota"));
            repository.Create(new Car("Mercedes"));
            return repository;
        }

        
    }
}
