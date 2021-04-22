using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Policies;
using Microsoft.AspNetCore.Mvc;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CarRental.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarProviderService _carProviderService;

        public CarController(ICarProviderService carProviderService)
        {
            _carProviderService = carProviderService;
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<string> GetCarInfoAsync([FromRoute] int id)
        {
            return await _carProviderService.GetCar(id);
        }

        [Authorize(Policy = Policy.Administrator)]
        [HttpPost]
        [Route("add")]
        public async Task AddCarAsync([FromBody] CarViewModel carViewModel)
        {
            await _carProviderService.AddCar(carViewModel);
        }
    }
}
