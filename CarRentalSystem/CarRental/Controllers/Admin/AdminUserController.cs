using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Infrastructure.Data.Policies;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models.Base;

namespace CarRental.Controllers.Admin
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
