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
            OrderModel order = _mapper.Map<OrderModel>(await _orders
                .IncludeAsync(orders => orders.OrderAdditionalServices)
                .ContinueWith(result => result.Result
                    .FirstOrDefault(o => o.Id == orderId)));

            order.OrderAdditionalServices.AddRange(orderAdditionalServices);

            await _orders.UpdateAsync(_mapper.Map<Order>(order));
        }

        public async Task<OrderModel> GetOrderAsync(int orderId)
        {
            OrderModel order = _mapper.Map<OrderModel>(await _orders.IncludeAsync(o => o.CurrentCustomer)
                .ContinueWith(result => result.Result
                    .Include(orders => orders.Car)
                    .Include(orders => orders.OrderAdditionalServices)
                    .ThenInclude(orderAdditionalService => orderAdditionalService.AdditionalService)
                    .FirstOrDefault(o => o.Id == orderId)));

            order.TotalCost = CountOrderTotalCost(order);

            await _orders.UpdateAsync(_mapper.Map<Order>(order));

            return order;
        }

        private static int CountOrderTotalCost(OrderModel order)
        {
            return (int)order.EndDate.Subtract(order.StartDate).TotalHours * order.Car.CostPerHour +
                   order.OrderAdditionalServices.Sum(orderService => orderService.AdditionalService.Cost);
        }
    }
}