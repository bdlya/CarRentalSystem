using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;
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
        private readonly IMapper _mapper;

        public LogoutController(IUserProviderService userProviderService, IMapper mapper)
        {
            _userProviderService = userProviderService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> LogOutAsync([FromBody] UserViewModel viewModel)
        {
            await _userProviderService.RemoveTokenAsync(_mapper.Map<UserModel>(viewModel));

            return Ok(new {Message = "Logout successful"});
        }
    }
}
