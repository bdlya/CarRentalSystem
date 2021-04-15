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
        private readonly IOrderProviderService _orderService;

        public CarController(ILogger<CarController> logger, IOrderProviderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpGet]
        public string Get()
        {
            int orderId = 2;
            return _orderService.GetAdditionalServices(orderId);
        }
    }
}
