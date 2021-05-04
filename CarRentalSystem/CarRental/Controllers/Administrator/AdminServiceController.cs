using AutoMapper;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.ExternalServices.Interfaces.Administrator.Moderator;
using CarRentalSystem.Infrastructure.Data.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CarRentalSystem.Presentation.Data.ViewModels.Main;

namespace CarRentalSystem.Presentation.API.Controllers.Administrator
{
    [Authorize(Policy = Policy.Administrator)]
    [Route("[controller]")]
    [ApiController]
    public class AdminServiceController : ControllerBase
    {
        private readonly IAdminServiceFunctionalityProviderService _additionalService;
        private readonly IMapper _mapper;

        public AdminServiceController(IAdminServiceFunctionalityProviderService additionalService, IMapper mapper)
        {
            _additionalService = additionalService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getService/{id}")]
        public async Task<IActionResult> GetServiceAsync([FromRoute] int id)
        {
            AdditionalWorkModel additionalService = await _additionalService.GetAdditionalWorkAsync(id);

            return Ok(_mapper.Map<AdditionalWorkViewModel>(additionalService));
        }

        [HttpPost]
        [Route("addService")]
        public async Task<IActionResult> AddServiceAsync([FromBody] AdditionalWorkViewModel additionalService)
        {
            await _additionalService.AddAdditionalWorkAsync(_mapper.Map<AdditionalWorkModel>(additionalService));

            return Created("",new {Message = "Additional service was successfully added"});
        }

        [HttpPatch]
        [Route("modifyService/{id}")]
        public async Task<IActionResult> ModifyServiceAsync([FromRoute] int id, [FromBody] AdditionalWorkViewModel additionalService)
        {
            await _additionalService.ModifyAdditionalWorkAsync(id, _mapper.Map<AdditionalWorkModel>(additionalService));

            return NoContent();
        }
    }
}
