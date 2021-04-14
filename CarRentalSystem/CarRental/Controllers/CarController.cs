using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Services.Interfaces;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CarController> _logger;
        private readonly ICarService _carService;

        public CarController(ILogger<CarController> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        [HttpGet]
        public string Get()
        {
            int carId = 2;
            return _carService.GetCar(carId);
        }
    }
}
