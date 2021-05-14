using AutoMapper;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.InternalInterfaces.Main;
using CarRentalSystem.Domain.Entities.Main;
using CarRentalSystem.Domain.Interfaces.Repository;
using CarRentalSystem.Infrastructure.ExceptionHandling.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.InternalServices.Implementation.Main
{
    public class OrderService: IOrderService
    {
        private readonly ICarService _carService;
        private readonly IUserService _userService;
        private readonly ICarRentalSystemRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(ICarService carService, IUserService userService, ICarRentalSystemRepository<Order> orderRepository, IMapper mapper)
        {
            _carService = carService;
            _userService = userService;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<OrderModel> CreateOrderAsync(OrderCreationModel order)
        {
            OrderModel currentOrder = new OrderModel
            {
                CarId = order.CarId,
                CurrentCustomerId = order.CustomerId,
                StartDate = order.StartDate,
                EndDate = order.EndDate
            };

            if (await IsCarOrdered(order.CarId))
            {
                throw new BookedCarException(order.CarId);
            }

            await _orderRepository.CreateAsync(_mapper.Map<Order>(currentOrder));

            var orders = await _orderRepository.GetAsQueryable();
            currentOrder = _mapper.Map<OrderModel>(orders
                .OrderBy(o => o.Id)
                .LastOrDefault(o => o.CarId == order.CarId && o.CurrentCustomerId == order.CustomerId));

            await _carService.AddOrderAsync(order.CarId, currentOrder);
            await _userService.AddOrderAsync(order.CustomerId, currentOrder);

            return currentOrder;
        }

        public async Task<OrderModel> GetOrderAsync(int orderId)
        {
            var orders = await _orderRepository.GetAsQueryable();
            OrderModel order = _mapper.Map<OrderModel>(orders
                .Include(o => o.CurrentCustomer)
                .Include(o => o.Car)
                .Include(o => o.OrderAdditionalWorks)
                .ThenInclude(oas => oas.AdditionalService)
                .FirstOrDefault(o => o.Id == orderId));

            order.TotalCost = CountOrderTotalCost(order);

            await _orderRepository.UpdateAsync(_mapper.Map<Order>(order));

            return order;
        }

        public async Task<IQueryable<OrderModel>> GetUserOrdersAsync(int userId)
        {
            var orders = await _orderRepository.GetAsQueryable();

            return orders
                .Include(o => o.Car)
                .ThenInclude(c => c.PointOfRental)
                .Include(o => o.OrderAdditionalWorks)
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

            await _orderRepository.UpdateAsync(_mapper.Map<Order>(order));

            return order.IsActive;
        }

        public async Task CancelOrderAsync(int orderId)
        {
            OrderModel order = _mapper.Map<OrderModel>(await _orderRepository.FindByIdAsync(orderId));

            order.IsActive = false;

            await _orderRepository.UpdateAsync(_mapper.Map<Order>(order));
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var orders = await _orderRepository.GetAsQueryable();
            OrderModel order = _mapper.Map<OrderModel>(orders
                .Include(o => o.Car)
                .FirstOrDefault(o => o.Id == orderId));

            await _orderRepository.RemoveAsync(_mapper.Map<Order>(order));
        }

        public int CountOrderTotalCost(OrderModel order)
        {
            return (int)order.EndDate.Subtract(order.StartDate).TotalHours * order.Car.CostPerHour +
                   order.OrderAdditionalServices.Sum(orderService => orderService.AdditionalWork.Cost);
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