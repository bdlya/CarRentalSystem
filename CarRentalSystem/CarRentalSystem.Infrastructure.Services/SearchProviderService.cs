using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Infrastructure.Services
{
    public class SearchProviderService: ISearchProviderService
    {
        private readonly IRentalRepository<PointOfRental> _repository;
        private readonly IMapper _mapper;

        public SearchProviderService(IRentalRepository<PointOfRental> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IQueryable<PointOfRentalModel>> FindPointsAsync(PointSearchModel searchModel)
        {
            var pointsModel = await _repository.IncludeAsync()
                .ContinueWith(point => point.Result
                    .Include(point => point.Cars))
                .ContinueWith(point => point.Result
                    .ThenInclude(car => car.CurrentOrder));

            var points = pointsModel.AsEnumerable().Select(point => _mapper.Map<PointOfRentalModel>(point)).AsQueryable();

            if (!string.IsNullOrEmpty(searchModel.Country))
            {
                points = points.Where(point => point.Country == searchModel.Country);
            }

            if (!string.IsNullOrEmpty(searchModel.City))
            {
                points = points.Where(point => point.City == searchModel.City);
            }

            if (searchModel.DateOfOrder >= DateTime.Today)
            {
                points.ToList().ForEach(point => point.Cars.Where(car => IsRequiredCar(car, searchModel.DateOfOrder)));
                points = points.Where(point => point.Cars.Count != 0).OrderByDescending(point => point.Cars.Count);
            }

            return points;
        }

        public async Task<IQueryable<CarModel>> FindCarsAsync(int id, DateTime date)
        {
            var requiredPoint = await _repository.IncludeAsync()
                .ContinueWith(point => point.Result
                    .Include(p => p.Cars))
                .ContinueWith(point => point.Result
                    .FirstOrDefaultAsync(p => p.Id == id).Result);

            var cars = _mapper.Map<PointOfRentalModel>(requiredPoint).Cars.AsQueryable()
                .Where(car => IsRequiredCar(car, date));

            return cars;
        }

        private bool IsRequiredCar(CarModel car, DateTime dateOfOrder)
        {
            OrderModel order = car.CurrentOrder;

            if (order == null)
            {
                return true;
            }

            return dateOfOrder > order.EndDate;
        }
    }
}