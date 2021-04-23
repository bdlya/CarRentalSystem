using CarRentalSystem.Infrastructure.Data.Policies;
using CarRentalSystem.View.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Services.Interfaces;

namespace CarRental.Controllers.Admin
{
    [Authorize(Policy = Policy.Administrator)]
    [Route("[controller]")]
    [ApiController]
    public class AdminPointOfRentalController : ControllerBase
    {
        private readonly IAdminPointFunctionalityProviderService _adminPointService;

        public AdminPointOfRentalController(IAdminPointFunctionalityProviderService adminPointService)
        {
            _adminPointService = adminPointService;
        }

        [HttpGet]
        [Route("getPoint/{id}")]
        public async Task<IActionResult> GetPointAsync([FromRoute] int id)
        {
            PointOfRentalViewModel point = await _adminPointService.GetPointAsync(id);

            return Ok(new { Message = GeneratePointInfo(point) });
        }

        [HttpPost]
        [Route("addPoint")]
        public async Task<IActionResult> AddPointAsync([FromBody] PointOfRentalViewModel addablePoint)
        {
            await _adminPointService.AddPointAsync(addablePoint);

            return Ok(new { Message = "Point was successfully added" });
        }

        [HttpPost]
        [Route("modifyPoint/{id}")]
        public async Task<IActionResult> ModifyPointAsync([FromRoute] int id, [FromBody] PointOfRentalViewModel modifiedPoint)
        {
            await _adminPointService.ModifyPointAsync(id, modifiedPoint);

            return Ok(new { Message = "Point was successfully modified" });
        }

        private string GeneratePointInfo(PointOfRentalViewModel point)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var carInfo in point.Cars.Select(car => $"Brand: {car.Brand}, Average fuel consumption: {car.AverageFuelConsumption}, Cost per hour: {car.CostPerHour}," +
                                                             $"Number of seats: {car.NumberOfSeats},Transmission type: {car.TransmissionType},"))
            {
                builder.Append($"{carInfo} ");
            }

            return $"Name: {point.Name}, " +
                   $"Country: {point.Country}, " +
                   $"City: {point.City}, " +
                   $"Address: {point.Address}, " +
                   $"Cars: {builder}";
        }
    }
}
