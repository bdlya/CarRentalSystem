using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserProviderService _userProviderService;

        public AuthenticationController(IUserProviderService userProviderService)
        {
            _userProviderService = userProviderService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<string> AuthenticateAsync([FromBody] AuthenticationViewModel model)
        {
            UserViewModel userModel = await _userProviderService.Authenticate(model);

            return $"Welcome, {userModel.Name} your current role is {userModel.Role} and here your token for postman test: {userModel.Token}";
        }
    }
}
