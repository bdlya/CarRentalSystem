using AutoMapper;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.ExternalInterfaces.User;
using CarRentalSystem.Application.InternalInterfaces.Main;
using CarRentalSystem.Infrastructure.Data.Authorization;
using CarRentalSystem.Presentation.Data.ViewModels.Main;
using CarRentalSystem.Presentation.Data.ViewModels.Support;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Presentation.API.Controllers.User
{
    [Authorize(Policy = Policy.Customer)]
    [Route("[controller]")]
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
        [Route("car")]
        public async Task<IActionResult> GetCarAsync([FromQuery] int carId)
        {
            CarViewModel car = _mapper.Map<CarViewModel>(await _carService.GetCarAsync(carId));

            return Ok(car);
        }

        [HttpGet]
        [Route("/summary")]
        public async Task<IActionResult> GetSummaryAsync([FromQuery] OrderCreationViewModel order)
        {
            OrderViewModel orderSummary = _mapper.Map<OrderViewModel>(await _bookingService.GetSummaryAsync(_mapper.Map<OrderCreationModel>(order)));

            return Ok(orderSummary);
        }

        [HttpGet]
        [Route("additionalWorks")]
        public async Task<IActionResult> GetAdditionalServices()
        {
            var additionalWorks = await _bookingService.GetAdditionalWorks();

            var additionalWorksModel = additionalWorks.AsEnumerable()
                .Select(work => _mapper.Map<AdditionalWorkViewModel>(work)).ToList();

            return Ok(additionalWorksModel);
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
