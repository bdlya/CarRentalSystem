using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.ExternalServices.Interfaces.User;
using CarRentalSystem.Application.InternalServices.Interfaces.Main;
using System;
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

        public async Task<IQueryable<CarModel>> FindCarsAsync(int id)
        {
            var point = await _points.GetPointAsync(id);

            var cars = point.Cars
                .AsQueryable()
                .Where(car => IsRequiredCar(car).Result);

            return cars;
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