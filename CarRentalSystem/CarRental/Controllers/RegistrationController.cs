﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels;
using Microsoft.AspNetCore.Authorization;

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
        public async Task RegisterAsync([FromBody] UserViewModel model)
        {
            await _userProviderService.RegisterUser(model);
        }
    }
}
