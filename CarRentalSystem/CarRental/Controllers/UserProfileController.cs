using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Infrastructure.Data.Policies;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
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

        [HttpPost]
        [Route("{userId}/order{orderId}/cancel")]
        public async Task<IActionResult> CancelOrderAsync([FromRoute] int orderId)
        {
            await _userProfileProvider.CancelOrderAsync(orderId);

            return Ok(new {Message = "Order was canceled"});
        }
    }
}
