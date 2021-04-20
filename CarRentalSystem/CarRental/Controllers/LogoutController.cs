using Microsoft.AspNetCore.Mvc;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CarRental.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private readonly IUserProviderService _userProviderService;

        public LogoutController(IUserProviderService userProviderService)
        {
            _userProviderService = userProviderService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult LogOut([FromBody] UserViewModel viewModel)
        {
            _userProviderService.RemoveToken(viewModel);
            return Ok();
        }

    }
}
