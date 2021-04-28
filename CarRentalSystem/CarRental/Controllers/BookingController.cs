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
        [Route("car{id}")]
        public async Task<IActionResult> GetCarAsync([FromRoute] int id)
        {
            CarViewModel car = _mapper.Map<CarViewModel>(await _carService.GetCarAsync(id));

            return Ok(car);
        }

        [HttpPost]
        [Route("car{carId}/date")]
        public async Task<IActionResult> ChooseDatesAsync([FromRoute] int userId, [FromRoute] int carId, [FromBody] BookingDatesViewModel bookingDates)
        {
            await _bookingService.ChooseDatesAsync(userId, carId, _mapper.Map<BookingDatesModel>(bookingDates));

            return Ok(new {Message = "Dates are chosen"});
        }

        [HttpPost]
        [Route("car{carId}/services")]
        public async Task<IActionResult> ChooseAdditionalServicesAsync([FromRoute] int carId, [FromBody] int[] additionalServicesIds)
        {
            await _bookingService.ChooseAdditionalServicesAsync(carId, additionalServicesIds.ToList());

            return Ok(new {Message = "Services are chosen"});
        }

        [HttpGet]
        [Route("car{carId}/summary")]
        public async Task<IActionResult> GetSummaryAsync([FromRoute] int carId)
        {
            OrderViewModel order = _mapper.Map<OrderViewModel>(await _bookingService.GetSummaryAsync(carId));

            return Ok(order);
        }
    }
}
