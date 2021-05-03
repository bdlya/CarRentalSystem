﻿using AutoMapper;
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

            return Created("",new {Message = "Order was created"});
        }

        [HttpPatch]
        [Route("car{carId}/order{orderId}/date")]
        public async Task<IActionResult> ChooseDatesAsync([FromRoute] int orderId, [FromBody] BookingDatesViewModel bookingDates)
        {
            await _bookingService.ChooseDatesAsync(orderId, _mapper.Map<BookingDatesModel>(bookingDates));

            return NoContent();
        }

        [HttpPatch]
        [Route("car{carId}/order{orderId}/services")]
        public async Task<IActionResult> ChooseAdditionalServicesAsync([FromRoute] int orderId, [FromBody] int[] additionalServicesIds)
        {
            await _bookingService.ChooseAdditionalServicesAsync(orderId, additionalServicesIds.ToList());

            return NoContent();
        }

        [HttpGet]
        [Route("car{carId}/order{orderId}/summary")]
        public async Task<IActionResult> GetSummaryAsync([FromRoute] int orderId)
        {
            OrderViewModel order = _mapper.Map<OrderViewModel>(await _bookingService.GetSummaryAsync(orderId));

            return Ok(order);
        }

        [HttpDelete]
        [Route("car{carId}/order{orderId}/delete")]
        public async Task<IActionResult> DeleteOrderAsync([FromRoute] int orderId)
        {
            await _bookingService.DeleteOrderAsync(orderId);

            return NoContent();
        }
    }
}
