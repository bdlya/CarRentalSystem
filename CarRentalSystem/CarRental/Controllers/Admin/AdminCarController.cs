using CarRentalSystem.Infrastructure.Data.Policies;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRental.Controllers.Admin
{
    [Authorize(Policy = Policy.Administrator)]
    [Route("[controller]")]
    [ApiController]
    public class AdminCarController : ControllerBase
    {
        private readonly IAdminCarFunctionalityProviderService _adminCarService;

        public AdminCarController(IAdminCarFunctionalityProviderService adminCarService)
        {
            _adminCarService = adminCarService;
        }

        [HttpGet]
        [Route("getCar/{id}")]
        public async Task<IActionResult> GetCarAsync([FromRoute] int id)
        {
            CarViewModel car = await _adminCarService.GetCarAsync(id);

            return Ok(new {Message = GenerateCarInfo(car)});
        }

        [HttpPost]
        [Route("addCar")]
        public async Task<IActionResult> AddCarAsync([FromBody] CarViewModel addableCar)
        {
            await _adminCarService.AddCarAsync(addableCar);

            return Ok(new {Message = "Car was successfully added"});
        }

        [HttpPost]
        [Route("deleteCar/{id}")]
        public async Task<IActionResult> DeleteCarAsync([FromRoute] int id)
        {
            await _adminCarService.DeleteCarAsync(id);

            return Ok(new {Message = "Car was successfully deleted"});
        }

        [HttpPost]
        [Route("modifyCar/{id}")]
        public async Task<IActionResult> ModifyCarAsync([FromRoute] int id, [FromBody] CarViewModel modifiedCar)
        {
            await _adminCarService.ModifyCarAsync(id, modifiedCar);

            return Ok(new {Message = "Car was successfully modified"});
        }

        private string GenerateCarInfo(CarViewModel car)
        {
            return $"Brand: {car.Brand}, " +
                   $"Average fuel consumption: {car.AverageFuelConsumption}, " +
                   $"Cost per hour: {car.CostPerHour}," +
                   $"Number of seats: {car.NumberOfSeats}," +
                   $"Transmission type: {car.TransmissionType}," +
                   $"Point of rental: name: {car.PointOfRental.Name}, country: {car.PointOfRental.Country}, city: {car.PointOfRental.City}, address: {car.PointOfRental.Address}";
        }
    }
}
