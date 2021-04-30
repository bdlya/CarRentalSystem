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
            await _repository.CreateAsync(_mapper.Map<PointOfRental>(addablePoint));
        }

        public async Task<PointOfRentalModel> GetPointAsync(int id)
        {
            var points = await _repository.GetAsQueryable();
            PointOfRentalModel point = _mapper.Map<PointOfRentalModel>(points
                .Include(p => p.Cars)
                .FirstOrDefault(p => p.Id == id));

            if (point == null)
            {
                throw new EntityNotFoundException(nameof(point));
            }

            return point;
        }

        public async Task ModifyPointAsync(int id, PointOfRentalModel modifiedPoint)
        {
            PointOfRentalModel point = _mapper.Map<PointOfRentalModel>(await _repository.FindByIdAsync(id));

            if (point == null)
            {
                throw new EntityNotFoundException(nameof(point));
            }

            point = UpdatePointProperties(point, modifiedPoint);

            await _repository.UpdateAsync(_mapper.Map<PointOfRental>(point));
        }

        public async Task<IQueryable<PointOfRentalModel>> GetPointsAsync()
        {
            var points = await _repository.GetAsQueryable();

            return points
                .Include(p => p.Cars)
                .ThenInclude(c => c.CurrentOrder)
                .AsEnumerable()
                .Select(p => _mapper.Map<PointOfRentalModel>(p))
                .AsQueryable();
        }

        private PointOfRentalModel UpdatePointProperties(PointOfRentalModel point, PointOfRentalModel modifiedPoint)
        {
            point.Name = modifiedPoint.Name;
            point.Address = modifiedPoint.Address;
            point.City = modifiedPoint.City;
            point.Country = modifiedPoint.Country;

            return point;
        }
    }
}