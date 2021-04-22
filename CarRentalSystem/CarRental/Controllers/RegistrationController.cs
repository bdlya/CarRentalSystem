using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserProviderService _userProviderService;

        public RegistrationController(IUserProviderService userProviderService)
        {
            _userProviderService = userProviderService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task RegisterAsync([FromBody] RegistrationViewModel model)
        {
            await _userProviderService.RegisterUser(model);
        }
    }
}
