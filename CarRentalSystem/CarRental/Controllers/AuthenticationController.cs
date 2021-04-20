using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Authenticate([FromBody] AuthenticationViewModel model)
        {
            UserViewModel userModel  = _userProviderService.Authenticate(model);

            if (userModel == null)
            {
                return BadRequest(new {message = "Username or password is incorrect"});
            }

            return Ok(new {message = $"Welcome, {userModel.Name} your current role is {userModel.Role} and here your token for postman test: {userModel.Token}"});
        }
    }
}
