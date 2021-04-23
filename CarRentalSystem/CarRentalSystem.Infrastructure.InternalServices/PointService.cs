using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.InternalInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Infrastructure.InternalServices
{
    public class PointService: IPointService
    {
        private readonly IRentalRepository<PointOfRental> _repository;
        private readonly IMapper _mapper;

        public PointService(IRentalRepository<PointOfRental> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddPointAsync(PointOfRentalModel addablePoint)
        {
            await _repository.Create(_mapper.Map<PointOfRental>(addablePoint));
        }

        public async Task<PointOfRentalModel> GetPointAsync(int id)
        {
            PointOfRental point = await _repository
                .Include(p => p.Cars)
                .ContinueWith(points => points.Result
                    .Include(p => p.Orders))
                .ContinueWith(points => points.Result
                    .FirstOrDefault(p => p.Id == id));

            if (point == null)
            {
                throw new NullReferenceException();
            }

            return _mapper.Map<PointOfRentalModel>(point);
        }

        public async Task ModifyPointAsync(int id, PointOfRentalModel modifiedPoint)
        {
            PointOfRental point = await _repository.FindById(id);

            if (point == null)
            {
                throw new NullReferenceException();
            }

            point = UpdatePointProperties(point, _mapper.Map<PointOfRental>(modifiedPoint));

            await _repository.Update(point);
        }

        private PointOfRental UpdatePointProperties(PointOfRental point, PointOfRental modifiedPoint)
        {
            point.Name = modifiedPoint.Name;
            point.Address = modifiedPoint.Address;
            point.City = modifiedPoint.City;
            point.Country = modifiedPoint.Country;

            return point;
        }
    }
}