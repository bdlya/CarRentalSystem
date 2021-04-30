using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models.Base;
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
        private readonly IMapper _mapper;

        public RegistrationController(IUserProviderService userProviderService, IMapper mapper)
        {
            _userProviderService = userProviderService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegistrationViewModel model)
        {
            await _userProviderService.RegisterUserAsync(_mapper.Map<RegistrationModel>(model));

            return Created("", new {Message = "User was registered"});
        }
    }
}
