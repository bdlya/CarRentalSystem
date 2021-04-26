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
    public class AdminServiceController : ControllerBase
    {
        private readonly IAdminServiceFunctionalityProviderService _additionalService;

        public AdminServiceController(IAdminServiceFunctionalityProviderService additionalService)
        {
            _additionalService = additionalService;
        }

        [HttpGet]
        [Route("getService/{id}")]
        public async Task<IActionResult> GetServiceAsync([FromRoute] int id)
        {
            AdditionalServiceViewModel additionalService = await _additionalService.GetAdditionalServiceAsync(id);

            return Ok(new {Message = GenerateAdditionalServiceInfo(additionalService)});
        }

        [HttpPost]
        [Route("addService")]
        public async Task<IActionResult> AddServiceAsync([FromBody] AdditionalServiceViewModel additionalService)
        {
            await _additionalService.AddAdditionalServiceAsync(additionalService);

            return Ok(new {Message = "Additional service was successfully added"});
        }

        [HttpPost]
        [Route("modifyService/{id}")]
        public async Task<IActionResult> ModifyServiceAsync([FromRoute] int id, [FromBody] AdditionalServiceViewModel additionalService)
        {
            await _additionalService.ModifyAdditionalServiceAsync(id, additionalService);

            return Ok(new {Message = "Additional service was successfully modified"});
        }

        private string GenerateAdditionalServiceInfo(AdditionalServiceViewModel additionalService)
        {
            return $"Name: {additionalService.Name}, " +
                   $"Cost: {additionalService.Cost}, ";
        }
    }
}
