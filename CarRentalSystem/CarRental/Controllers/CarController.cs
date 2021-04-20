using System.Threading.Tasks;
using CarRentalSystem.Domain.Entities.Helpers;
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
            return await Task.Run(() => _carProviderService.GetCar(id));
        }

        [Authorize(Roles = Role.Administrator)]
        [HttpPost]
        [Route("add")]
        public async Task AddCarAsync([FromBody] CarViewModel carViewModel)
        {
            await Task.Run(() => _carProviderService.AddCar(carViewModel));
        }
    }
}
