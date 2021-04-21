using System.Threading.Tasks;
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
        public async Task LogOutAsync([FromBody] UserViewModel viewModel)
        {
            await _userProviderService.RemoveToken(viewModel);
        }
    }
}
