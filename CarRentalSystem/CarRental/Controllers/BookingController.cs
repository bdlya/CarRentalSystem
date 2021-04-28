using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Policies;
using CarRentalSystem.Services.InternalInterfaces;
using CarRentalSystem.View.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.Interfaces;

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


    }
}
