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
        private readonly IMapper _mapper;

        public UserProfileController(ISearchProviderService searchProvider, IMapper mapper)
        {
            _searchProvider = searchProvider;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{userId}/orders")]
        public async Task<IActionResult> FindUserOrdersAsync([FromRoute] int userId, [FromBody] OrderSearchViewModel searchModel)
        {
            var userOrders = await _searchProvider.FindUserOrdersAsync(userId, _mapper.Map<OrderSearchModel>(searchModel));

            return Ok(userOrders.Select(o => _mapper.Map<OrderViewModel>(o)));
        }
    }
}
