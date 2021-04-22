using System;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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

            SetRefreshTokenCookie(userModel.RefreshToken.Token);

            return $"Welcome, {userModel.Name} your current role is {userModel.Role} and here your token for postman test: {userModel.Token}";
        }

        [Authorize]
        [HttpPost]
        [Route("refresh-token")]
        public async Task RefreshToken()
        {
            var currentRefreshToken = Request.Cookies["RefreshToken"];

            RefreshTokenViewModel newRefreshToken = await _userProviderService.RefreshToken(currentRefreshToken);

            SetRefreshTokenCookie(newRefreshToken.Token);
        }

        private void SetRefreshTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7)
            };

            Response.Cookies.Append("RefreshToken", token, cookieOptions);
        }
    }
}
