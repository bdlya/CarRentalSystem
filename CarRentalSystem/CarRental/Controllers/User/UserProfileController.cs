using AutoMapper;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.ExternalServices.Interfaces.User;
using CarRentalSystem.Infrastructure.Data.Authorization;
using CarRentalSystem.Presentation.Data.ViewModels.Main;
using CarRentalSystem.Presentation.Data.ViewModels.Support;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Presentation.API.Controllers.User
{
    [Authorize(Policy = Policy.Customer)]
    [Route("[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly ISearchProviderService _searchProvider;
        private readonly IUserProfileProviderService _userProfileProvider;
        private readonly IMapper _mapper;

        public UserProfileController(ISearchProviderService searchProvider, IMapper mapper, IUserProfileProviderService userProfileProvider)
        {
            _searchProvider = searchProvider;
            _mapper = mapper;
            _userProfileProvider = userProfileProvider;
        }

        [HttpGet]
        [Route("{userId}/orders")]
        public async Task<IActionResult> FindUserOrdersAsync([FromRoute] int userId, [FromBody] OrderSearchViewModel searchModel)
        {
            var userOrders = await _searchProvider.FindUserOrdersAsync(userId, _mapper.Map<OrderSearchModel>(searchModel));

            return Ok(userOrders.Select(o => _mapper.Map<OrderViewModel>(o)));
        }

        [HttpGet]
        [Route("{userId}/order{orderId}")]
        public async Task<IActionResult> GetOrderAsync([FromRoute] int orderId)
        {
            OrderViewModel order = _mapper.Map<OrderViewModel>(await _userProfileProvider.GetOrderAsync(orderId));

            return Ok(order);
        }

        [HttpPatch]
        [Route("{userId}/order{orderId}/cancel")]
        public async Task<IActionResult> CancelOrderAsync([FromRoute] int orderId)
        {
            await _userProfileProvider.CancelOrderAsync(orderId);

            return NoContent();
        }
    }
}
