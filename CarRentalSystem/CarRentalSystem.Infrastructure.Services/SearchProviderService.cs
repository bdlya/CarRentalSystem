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
            var points = await _repository.IncludeAsync()
                .ContinueWith(point => point.Result
                    .Include(p => p.Cars))
                .ContinueWith(point => point.Result
                    .ThenInclude(car => car.CurrentOrder))
                .ContinueWith(point => point.Result
                    .Select(p => _mapper.Map<PointOfRentalModel>(p)));

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
                await points.ForEachAsync(point => point.Cars.Where(car => IsRequiredCar(car, searchModel.DateOfOrder)));
                points = points.Where(point => point.Cars.Count != 0).OrderByDescending(point => point.Cars.Count);
            }

            return points;
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