using AutoMapper;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.ExternalServices.Interfaces.Common;
using CarRentalSystem.Presentation.Data.ViewModels.Support;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRentalSystem.Presentation.API.Controllers.Common
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
