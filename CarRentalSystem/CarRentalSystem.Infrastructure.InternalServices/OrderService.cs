using System;
using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.InternalInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Infrastructure.InternalServices
{
    public class OrderService: IOrderService
    {
        private readonly ICarService _carService;
        private readonly IUserService _userService;
        private readonly IRentalRepository<Order> _orders;
        private readonly IRentalRepository<OrderAdditionalService> _orderAdditionalServices;
        private readonly IMapper _mapper;

        public OrderService(ICarService carService, IUserService userService, IRentalRepository<Order> orders, IMapper mapper, IRentalRepository<OrderAdditionalService> orderAdditionalServices)
        {
            _carService = carService;
            _userService = userService;
            _orders = orders;
            _mapper = mapper;
            _orderAdditionalServices = orderAdditionalServices;
        }

        public async Task CreateOrderAsync(int userId, int carId, BookingDatesModel bookingDates)
        {
            OrderModel currentOrder = new OrderModel
            {
                StartDate = bookingDates.StartDate,
                EndDate = bookingDates.EndDate,
                CarId = carId,
                CurrentCustomerId = userId
            };

            await _orders.CreateAsync(_mapper.Map<Order>(currentOrder));

            currentOrder = _mapper.Map<OrderModel>(await _orders
                .IncludeAsync()
                .ContinueWith(r => r.Result
                    .OrderBy(order => order.Id)
                    .LastOrDefault(order => order.CarId == carId && order.CurrentCustomerId == userId)));

            await _carService.AddOrderAsync(carId, currentOrder);
            await _userService.AddOrderAsync(userId, currentOrder);
        }

        public async Task AddAdditionalServicesAsync(int carId, List<AdditionalServiceModel> additionalServices)
        {
            CarModel car = await _carService.GetCarAsync(carId);

            OrderModel order = car.CurrentOrder;

            foreach (var service in additionalServices)
            {
                var orderAdditionalService = new OrderAdditionalServiceModel
                {
                    OrderId = order.Id,
                    AdditionalServiceId = service.Id
                };

                await _orderAdditionalServices.CreateAsync(_mapper.Map<OrderAdditionalService>(orderAdditionalService));

                order.OrderAdditionalServices.Add(orderAdditionalService);
            }

            await _orders.UpdateAsync(_mapper.Map<Order>(order));
        }

        public async Task<OrderModel> GetOrderAsync(int carId)
        {
            CarModel car = await _carService.GetCarAsync(carId);

            OrderModel order = _mapper.Map<OrderModel>(await _orders.IncludeAsync(o => o.CurrentCustomer)
                .ContinueWith(result => result.Result
                    .Include(orders => orders.Car)
                    .Include(orders => orders.OrderAdditionalServices)
                    .ThenInclude(orderAdditionalService => orderAdditionalService.AdditionalService)
                    .FirstOrDefault(o => o.Id == car.CurrentOrderId)));

            order.TotalCost = CountOrderTotalCost(order);

            await _orders.UpdateAsync(_mapper.Map<Order>(order));

            return order;
        }

        private static int CountOrderTotalCost(OrderModel order)
        {
            double cost = 0;

            TimeSpan span = order.EndDate.Subtract(order.StartDate);

            cost += span.TotalHours * order.Car.CostPerHour + order.OrderAdditionalServices.Sum(orderService => orderService.AdditionalService.Cost);

            return (int)cost;
        }
    }
}