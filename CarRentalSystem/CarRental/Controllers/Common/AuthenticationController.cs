using AutoMapper;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.ExternalInterfaces.Common;
using CarRentalSystem.Presentation.Data.ViewModels.Main;
using CarRentalSystem.Presentation.Data.ViewModels.Support;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarRentalSystem.Presentation.API.Controllers.Common
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserProviderService _userProviderService;
        private readonly IMapper _mapper;

        public AuthenticationController(IUserProviderService userProviderService, IMapper mapper)
        {
            _userProviderService = userProviderService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticationViewModel model)
        {
            UserViewModel userViewModel = _mapper.Map<UserViewModel>(await _userProviderService.AuthenticateAsync(_mapper.Map<AuthenticationModel>(model)));

            SetRefreshTokenCookie(userViewModel.RefreshToken.Token);

            return Created("",new {Message = $"Welcome, {userViewModel.Name} your current role is {userViewModel.Role} and here your token for postman test: {userViewModel.Token}"});
        }

        [Authorize]
        [HttpPatch]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var currentRefreshToken = Request.Cookies["RefreshToken"];

            RefreshTokenViewModel newRefreshToken = _mapper.Map<RefreshTokenViewModel>(await _userProviderService.RefreshTokenAsync(currentRefreshToken));

            SetRefreshTokenCookie(newRefreshToken.Token);

            return NoContent();
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
