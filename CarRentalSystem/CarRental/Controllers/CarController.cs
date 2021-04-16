using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly ICarProviderService _carProviderService;

        public CarController(ILogger<CarController> logger, ICarProviderService carProviderService)
        {
            _logger = logger;
            _carProviderService = carProviderService;
        }

        [HttpGet]
        [Route("{id}")]
        public string Get(int id)
        {
            return _carProviderService.GetCar(id);
        }

        [HttpPost]
        [Route("test")]
        public ActionResult AddCar([FromBody] CarViewModel carViewModel)
        {
            try
            {
                _carProviderService.AddCar(carViewModel);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
