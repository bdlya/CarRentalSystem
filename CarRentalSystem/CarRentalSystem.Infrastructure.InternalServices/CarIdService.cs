using System;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;

namespace CarRentalSystem.Infrastructure.InternalServices
{
    public class CarIdService : ICarIdService
    {
        private readonly IRentalRepository<Car> _repository;

        public CarIdService(IRentalRepository<Car> repository)
        {
            _repository = repository;
        }

        public string GetById(int id)
        {
            return _repository.FindById(id).Brand;
        }
    }
}
