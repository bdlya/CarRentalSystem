using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Infrastructure.Services
{
    public class SearchProviderService: ISearchProviderService
    {
        private readonly IPointService _points;

        public SearchProviderService(IPointService points)
        {
            _points = points;
        }

        public async Task<IQueryable<PointOfRentalModel>> FindPointsAsync(PointSearchModel searchModel)
        {
            var points = await _points.GetPointsAsync();
            
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
            }

            return points.Where(point => point.Cars.Count != 0).OrderByDescending(point => point.Cars.Count);
        }

        public async Task<IQueryable<CarModel>> FindCarsAsync(int id, DateTime date)
        {
            var point = await _points.GetPointAsync(id);

            var cars = point.Cars
                .AsQueryable()
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