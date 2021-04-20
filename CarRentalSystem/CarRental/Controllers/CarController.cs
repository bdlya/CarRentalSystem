using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarProviderService _carProviderService;

        public CarController(ICarProviderService carProviderService)
        {
            _carProviderService = carProviderService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<string> GetCarInfoAsync(int id)
        {
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
