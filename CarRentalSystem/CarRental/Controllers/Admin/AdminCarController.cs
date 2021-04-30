using CarRentalSystem.Infrastructure.Data.Policies;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRental.Controllers.Admin
{
    [Authorize(Policy = Policy.Administrator)]
    [Route("[controller]")]
    [ApiController]
    public class AdminCarController : ControllerBase
    {
        private readonly IAdminCarFunctionalityProviderService _adminCarService;
        private readonly IMapper _mapper;

        public AdminCarController(IAdminCarFunctionalityProviderService adminCarService, IMapper mapper)
        {
            _adminCarService = adminCarService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getCar/{id}")]
        public async Task<IActionResult> GetCarAsync([FromRoute] int id)
        {
            CarModel car = await _adminCarService.GetCarAsync(id);

            return Ok(_mapper.Map<CarViewModel>(car));
        }

        [HttpPost]
        [Route("addCar")]
        public async Task<IActionResult> AddCarAsync([FromBody] CarViewModel addableCar)
        {
            await _adminCarService.AddCarAsync(_mapper.Map<CarModel>(addableCar));

            return Created("",new {Message = "Car was successfully added"});
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
            await _adminCarService.ModifyCarAsync(id, _mapper.Map<CarModel>(modifiedCar));

            return Ok(new {Message = "Car was successfully modified"});
        }
    }
}
