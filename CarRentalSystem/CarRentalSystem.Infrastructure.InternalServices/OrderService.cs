using AutoMapper;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Domain.Interfaces;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.InternalInterfaces;
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
    }
}