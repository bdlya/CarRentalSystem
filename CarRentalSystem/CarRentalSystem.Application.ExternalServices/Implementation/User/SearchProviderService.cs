using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.ExternalInterfaces.User;
using CarRentalSystem.Application.InternalInterfaces.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.ExternalServices.Implementation.User
{
    public class SearchProviderService: ISearchProviderService
    {
        private readonly IPointService _points;
        private readonly IOrderService _orders;

        public SearchProviderService(IPointService points, IOrderService orders)
        {
            _points = points;
            _orders = orders;
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
                points.ToList().ForEach(point => point.Cars.Where(car => IsRequiredCar(car).Result));
            }

            return points.Where(point => point.Cars.Count != 0).OrderByDescending(point => point.Cars.Count);
        }

        public async Task<IQueryable<CarModel>> FindCarsAsync(int id, CarSearchModel searchModel)
        {
            var cars = await GetCars(id);

            if (!string.IsNullOrEmpty(searchModel.Brand))
            {
                cars = cars.Where(car => car.Brand == searchModel.Brand);
            }

            if (!string.IsNullOrEmpty(searchModel.TransmissionType))
            {
                cars = cars.Where(point => point.TransmissionType == searchModel.TransmissionType);
            }

            if (searchModel.NumberOfSeats > 0)
            {
                cars = cars.Where(car => car.NumberOfSeats == searchModel.NumberOfSeats);
            }

            return cars.AsQueryable();
        }

        public async Task<IQueryable<OrderModel>> FindUserOrdersAsync(int userId, OrderSearchModel searchModel)
        {
            var orders = (await _orders.GetUserOrdersAsync(userId)).ToList();

            if (string.IsNullOrEmpty(searchModel.OrderType) || searchModel.OrderType == "Current")
            {
                orders = orders.Where(o => IsOrderActive(o).Result).ToList();
            }
            else if(searchModel.OrderType == "Previous")
            {
                orders = orders.Where(o => !IsOrderActive(o).Result).ToList();
            }

            if (!string.IsNullOrEmpty(searchModel.Country))
            {
                orders = orders.Where(o => o.Car.PointOfRental.Country == searchModel.Country).ToList();
            }

            if (!string.IsNullOrEmpty(searchModel.City))
            {
                orders = orders.Where(o => o.Car.PointOfRental.City == searchModel.City).ToList();
            }

            return orders.AsQueryable();
        }

        private async Task<IQueryable<CarModel>> GetCars(int id)
        {
            List<CarModel> cars = new List<CarModel>();

            if (id == 0)
            {
                var points = await _points.GetPointsAsync();
                foreach (var point in points)
                {
                    cars.AddRange(point.Cars.Where(car => IsRequiredCar(car).Result));
                }
            }
            else
            {
                var point = await _points.GetPointAsync(id);
                cars = point.Cars
                    .AsQueryable()
                    .Where(car => IsRequiredCar(car).Result).ToList();
            }

            return cars.AsQueryable();
        }

        private async Task<bool> IsRequiredCar(CarModel car)
        {
            OrderModel order = car.CurrentOrder;

            if (order == null)
            {
                return true;
            }

            bool result = await IsOrderActive(order);

            return !result;
        }

        private async Task<bool> IsOrderActive(OrderModel order)
        {
            bool result = await _orders.CheckOrderActivityAsync(order);

            return result;
        }
    }
}