﻿using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Infrastructure.Data.Policies;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.View.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRental.Controllers.Admin
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AdminPointOfRentalController : ControllerBase
    {
        private readonly IAdminPointFunctionalityProviderService _adminPointService;
        private readonly IMapper _mapper;

        public AdminPointOfRentalController(IAdminPointFunctionalityProviderService adminPointService, IMapper mapper)
        {
            _adminPointService = adminPointService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getPoint/{id}")]
        [Authorize(Policy = Policy.OwnerOrAdministrator)]
        public async Task<IActionResult> GetPointAsync([FromRoute] int id)
        {
            PointOfRentalModel point = await _adminPointService.GetPointAsync(id);

            return Ok(_mapper.Map<PointOfRentalViewModel>(point));
        }

        [HttpPost]
        [Route("addPoint")]
        [Authorize(Policy = Policy.AdministratorOwner)]
        public async Task<IActionResult> AddPointAsync([FromBody] PointOfRentalViewModel addablePoint)
        {
            await _adminPointService.AddPointAsync(_mapper.Map<PointOfRentalModel>(addablePoint));

            return Created("",new { Message = "Point was successfully added" });
        }

        [HttpPatch]
        [Route("modifyPoint/{id}")]
        [Authorize(Policy = Policy.AdministratorOwner)]
        public async Task<IActionResult> ModifyPointAsync([FromRoute] int id, [FromBody] PointOfRentalViewModel modifiedPoint)
        {
            await _adminPointService.ModifyPointAsync(id, _mapper.Map<PointOfRentalModel>(modifiedPoint));

            return NoContent();
        }
    }
}
