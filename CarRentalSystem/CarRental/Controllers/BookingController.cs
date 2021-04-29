using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Infrastructure.Data.Policies;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;
using CarRentalSystem.View.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    [Authorize(Policy = Policy.Customer)]
    [Route("customer{userId}/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IBookingProviderService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(ICarService carService, IBookingProviderService bookingService, IMapper mapper)
        {
            _carService = carService;
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("car{carId}")]
        public async Task<IActionResult> GetCarAsync([FromRoute] int carId)
        {
            CarViewModel car = _mapper.Map<CarViewModel>(await _carService.GetCarAsync(carId));

            return Ok(car);
        }

        [HttpPost]
        [Route("car{carId}/order")]
        public async Task<IActionResult> CreateOrderAsync([FromRoute] int userId, [FromRoute] int carId)
        {
            OrderViewModel order = _mapper.Map<OrderViewModel>(await _bookingService.CreateOrderAsync(userId, carId));

            return Ok(new {Message = "Order was created"});
        }

        [HttpPost]
        [Route("car{carId}/order{orderId}/date")]
        public async Task<IActionResult> ChooseDatesAsync([FromRoute] int orderId, [FromBody] BookingDatesViewModel bookingDates)
        {
            await _bookingService.ChooseDatesAsync(orderId, _mapper.Map<BookingDatesModel>(bookingDates));

            return Ok(new {Message = "Dates are chosen"});
        }

        [HttpPost]
        [Route("car{carId}/order{orderId}/services")]
        public async Task<IActionResult> ChooseAdditionalServicesAsync([FromRoute] int orderId, [FromBody] int[] additionalServicesIds)
        {
            await _bookingService.ChooseAdditionalServicesAsync(orderId, additionalServicesIds.ToList());

            return Ok(new {Message = "Services are chosen"});
        }

        [HttpGet]
        [Route("car{carId}/order{orderId}/summary")]
        public async Task<IActionResult> GetSummaryAsync([FromRoute] int orderId)
        {
            OrderViewModel order = _mapper.Map<OrderViewModel>(await _bookingService.GetSummaryAsync(orderId));

            return Ok(order);
        }
    }
}
