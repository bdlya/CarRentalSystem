using AutoMapper;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.ExternalInterfaces.Common;
using CarRentalSystem.Presentation.Data.ViewModels.Main;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRentalSystem.Presentation.API.Controllers.Common
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
        [HttpPatch]
        public async Task<IActionResult> LogOutAsync([FromBody] UserViewModel viewModel)
        {
            await _userProviderService.RemoveTokenAsync(_mapper.Map<UserModel>(viewModel));

            return NoContent();
        }
    }
}
