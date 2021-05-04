using AutoMapper;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.ExternalInterfaces.Administrator.Moderator;
using CarRentalSystem.Infrastructure.Data.Authorization;
using CarRentalSystem.Presentation.Data.ViewModels.Main;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRentalSystem.Presentation.API.Controllers.Administrator
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

        [HttpDelete]
        [Route("deleteCar/{id}")]
        public async Task<IActionResult> DeleteCarAsync([FromRoute] int id)
        {
            await _adminCarService.DeleteCarAsync(id);

            return NoContent();
        }

        [HttpPatch]
        [Route("modifyCar/{id}")]
        public async Task<IActionResult> ModifyCarAsync([FromRoute] int id, [FromBody] CarViewModel modifiedCar)
        {
            await _adminCarService.ModifyCarAsync(id, _mapper.Map<CarModel>(modifiedCar));

            return NoContent();
        }
    }
}
