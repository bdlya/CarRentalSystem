using System;
using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.InternalInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Infrastructure.InternalServices
{
    public class OrderService: IOrderService
    {
        private readonly ICarService _carService;
        private readonly IUserService _userService;
        private readonly IRentalRepository<Order> _orders;
        private readonly IMapper _mapper;

        public OrderService(ICarService carService, IUserService userService, IRentalRepository<Order> orders, IMapper mapper)
        {
            _carService = carService;
            _userService = userService;
            _orders = orders;
            _mapper = mapper;
        }

        public async Task<OrderModel> CreateOrderAsync(int userId, int carId)
        {
            OrderModel currentOrder = new OrderModel
            {
                CarId = carId,
                CurrentCustomerId = userId,
                IsActive = true
            };

            if (await IsCarOrdered(carId))
            {
                throw new Exception("Car is already ordered");
            }

            await _orders.CreateAsync(_mapper.Map<Order>(currentOrder));

            var orders = await _orders.GetAsQueryable();
            currentOrder = _mapper.Map<OrderModel>(orders
                .OrderBy(o => o.Id)
                .LastOrDefault(o => o.CarId == carId && o.CurrentCustomerId == userId));

            await _carService.AddOrderAsync(carId, currentOrder);
            await _userService.AddOrderAsync(userId, currentOrder);

            return currentOrder;
        }

        public async Task ChooseDatesAsync(int orderId, BookingDatesModel bookingDates)
        {
            OrderModel order = _mapper.Map<OrderModel>(await _orders.FindByIdAsync(orderId));

            order.StartDate = bookingDates.StartDate;
            order.EndDate = bookingDates.EndDate;

            await _orders.UpdateAsync(_mapper.Map<Order>(order));
        }

        public async Task AddAdditionalServicesAsync(int orderId, List<OrderAdditionalServiceModel> orderAdditionalServices)
        {
            var orders = await _orders.GetAsQueryable();
            OrderModel order = _mapper.Map<OrderModel>(orders
                .Include(o => o.OrderAdditionalServices)
                .FirstOrDefault(o => o.Id == orderId));

            order.OrderAdditionalServices.AddRange(orderAdditionalServices);

            await _orders.UpdateAsync(_mapper.Map<Order>(order));
        }

        public async Task<OrderModel> GetOrderAsync(int orderId)
        {
            var orders = await _orders.GetAsQueryable();
            OrderModel order = _mapper.Map<OrderModel>(orders
                .Include(o => o.CurrentCustomer)
                .Include(o => o.Car)
                .Include(o => o.OrderAdditionalServices)
                .ThenInclude(oas => oas.AdditionalService)
                .FirstOrDefault(o => o.Id == orderId));

            order.TotalCost = CountOrderTotalCost(order);

            await _orders.UpdateAsync(_mapper.Map<Order>(order));

            return order;
        }

        public async Task<IQueryable<OrderModel>> GetUserOrdersAsync(int userId)
        {
            var orders = await _orders.GetAsQueryable();

            return orders
                .Include(o => o.Car)
                .ThenInclude(c => c.PointOfRental)
                .Include(o => o.OrderAdditionalServices)
                .ThenInclude(oas => oas.AdditionalService)
                .AsEnumerable()
                .Select(o => _mapper.Map<OrderModel>(o))
                .AsQueryable();
        }

        public async Task<bool> CheckOrderActivityAsync(OrderModel order)
        {
            if (order.IsActive && DateTime.Now > order.EndDate)
            {
                order.IsActive = false;
            }

            await _orders.UpdateAsync(_mapper.Map<Order>(order));

            return order.IsActive;
        }

        private static int CountOrderTotalCost(OrderModel order)
        {
            return (int)order.EndDate.Subtract(order.StartDate).TotalHours * order.Car.CostPerHour +
                   order.OrderAdditionalServices.Sum(orderService => orderService.AdditionalService.Cost);
        }

        private async Task<bool> IsCarOrdered(int carId)
        {
            CarModel car = await _carService.GetCarAsync(carId);

            OrderModel order = car.CurrentOrder;
            if (order == null)
            {
                return false;
            }

            return await CheckOrderActivityAsync(order);
        }
    }
}