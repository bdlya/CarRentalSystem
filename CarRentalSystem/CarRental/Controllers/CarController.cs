﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ICarProviderService _carProviderService;

        public CarController(ILogger<CarController> logger, ICarProviderService carProviderService)
        {
            _logger = logger;
            _carProviderService = carProviderService;
        }

        [HttpGet]
        public string Get()
        {
            int carId = 1;
            return _carProviderService.GetCar(carId);
        }
    }
}
