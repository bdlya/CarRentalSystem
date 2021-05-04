using AutoMapper;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.ExternalInterfaces.Administrator.Owner;
using CarRentalSystem.Infrastructure.Data.Authorization;
using CarRentalSystem.Presentation.Data.ViewModels.Support;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRentalSystem.Presentation.API.Controllers.Administrator
{
    [Authorize(Policy = Policy.AdministratorOwner)]
    [Route("[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly IAdminUserFunctionalityProviderService _adminService;
        private readonly IMapper _mapper;

        public AdminUserController(IAdminUserFunctionalityProviderService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("addAdmin")]
        public async Task<IActionResult> CreateAdminAsync([FromBody] RegistrationViewModel admin)
        {
            await _adminService.CreateAdminAsync(_mapper.Map<RegistrationModel>(admin));

            return Created("", new {Message = "Admin was successfully added"});
        }

        [HttpDelete]
        [Route("deleteAdmin/{id}")]
        public async Task<IActionResult> DeleteAdminAsync([FromRoute] int id)
        {
            await _adminService.DeleteAdminAsync(id);

            return NoContent();
        }

        [HttpGet]
        [Route("getAdmins")]
        public async Task<IActionResult> GetAllAdminsAsync()
        {
            var admins = await _adminService.GetAllAdminsAsync();

            return Ok(admins);
        }
    }
}
