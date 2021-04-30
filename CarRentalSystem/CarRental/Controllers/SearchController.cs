using System;
using System.Linq;
using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Infrastructure.Data.Policies;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    [Authorize(Policy = Policy.Customer)]
    [Route("customer{userId}/[controller]")]
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
        public async Task<IActionResult> FindPointsAsync([FromBody] PointSearchViewModel searchModel)
        {
            var points = await _searchProviderService.FindPointsAsync(_mapper.Map<PointSearchModel>(searchModel));

            return Ok(points.Select(point => _mapper.Map<PointOfRentalViewModel>(point)));
        }

        [HttpGet]
        [Route("point{id}/cars")]
        public async Task<IActionResult> FindFreeCarsAsync([FromRoute] int id)
        {
            var cars = await _searchProviderService.FindCarsAsync(id);

            return Ok(cars.Select(car => _mapper.Map<CarViewModel>(car)));
        }
    }
}
