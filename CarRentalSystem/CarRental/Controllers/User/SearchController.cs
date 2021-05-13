using AutoMapper;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.ExternalInterfaces.User;
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
    public class SearchController : ControllerBase
    {
        private readonly ISearchProviderService _searchProviderService;
        private readonly IMapper _mapper;

        public SearchController(ISearchProviderService searchProviderService, IMapper mapper)
        {
            _searchProviderService = searchProviderService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("points")]
        public async Task<IActionResult> FindPointsAsync([FromQuery] PointSearchViewModel searchModel)
        {
            var points = await _searchProviderService.FindPointsAsync(_mapper.Map<PointSearchModel>(searchModel));

            return Ok(points.Select(point => _mapper.Map<PointOfRentalViewModel>(point)));
        }

        [HttpGet]
        [Route("point/cars")]
        public async Task<IActionResult> FindFreeCarsAsync([FromQuery] int id, [FromQuery] CarSearchViewModel searchModel)
        {
            var cars = await _searchProviderService.FindCarsAsync(id, _mapper.Map<CarSearchModel>(searchModel));

            return Ok(cars.Select(car => _mapper.Map<CarViewModel>(car)));
        }
    }
}
