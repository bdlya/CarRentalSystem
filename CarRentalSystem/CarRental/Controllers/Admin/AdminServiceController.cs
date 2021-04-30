using System.ComponentModel.DataAnnotations;
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
            AdditionalServiceModel additionalService = await _additionalService.GetAdditionalServiceAsync(id);

            return Ok(_mapper.Map<AdditionalServiceViewModel>(additionalService));
        }

        [HttpPost]
        [Route("addService")]
        public async Task<IActionResult> AddServiceAsync([FromBody] AdditionalServiceViewModel additionalService)
        {
            await _additionalService.AddAdditionalServiceAsync(_mapper.Map<AdditionalServiceModel>(additionalService));

            return Created("",new {Message = "Additional service was successfully added"});
        }

        [HttpPost]
        [Route("modifyService/{id}")]
        public async Task<IActionResult> ModifyServiceAsync([FromRoute] int id, [FromBody] AdditionalServiceViewModel additionalService)
        {
            await _additionalService.ModifyAdditionalServiceAsync(id, _mapper.Map<AdditionalServiceModel>(additionalService));

            return Ok(new {Message = "Additional service was successfully modified"});
        }
    }
}
