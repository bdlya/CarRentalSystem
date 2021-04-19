using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels;
using Serilog;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarProviderService _carProviderService;
        private readonly ILogger _logger;

        public CarController(ICarProviderService carProviderService, ILogger logger)
        {
            _carProviderService = carProviderService;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<string> GetCarInfoAsync(int id)
        {
            _logger.Information("Test get car request log");
            return await Task.Run(() => _carProviderService.GetCar(id));
        }

        [HttpPost]
        [Route("test")]
        public async Task AddCarAsync([FromBody] CarViewModel carViewModel)
        {
            await Task.Run(() => _carProviderService.AddCar(carViewModel));
        }
    }
}
