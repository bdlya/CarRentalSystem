﻿using System;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;

namespace CarRental.Controllers
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
        public async Task<string> AuthenticateAsync([FromBody] AuthenticationViewModel model)
        {
            UserViewModel userViewModel = _mapper.Map<UserViewModel>(await _userProviderService.AuthenticateAsync(_mapper.Map<AuthenticationModel>(model)));

            SetRefreshTokenCookie(userViewModel.RefreshToken.Token);

            return $"Welcome, {userViewModel.Name} your current role is {userViewModel.Role} and here your token for postman test: {userViewModel.Token}";
        }

        [Authorize]
        [HttpPost]
        [Route("refresh-token")]
        public async Task RefreshToken()
        {
            var currentRefreshToken = Request.Cookies["RefreshToken"];

            RefreshTokenViewModel newRefreshToken = _mapper.Map<RefreshTokenViewModel>(await _userProviderService.RefreshTokenAsync(currentRefreshToken));

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
