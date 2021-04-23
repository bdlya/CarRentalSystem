using System.Threading.Tasks;
using AutoMapper;
using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;
using CarRentalSystem.View.ViewModels;

namespace CarRentalSystem.Infrastructure.Services
{
    public class AdminPointFunctionalityProviderService : IAdminPointFunctionalityProviderService
    {
        private readonly IPointService _pointService;
        private readonly IMapper _mapper;

        public AdminPointFunctionalityProviderService(IPointService pointService, IMapper mapper)
        {
            _pointService = pointService;
            _mapper = mapper;
        }

        public async Task AddPointAsync(PointOfRentalViewModel addablePoint)
        {
            await _pointService.AddPointAsync(_mapper.Map<PointOfRentalModel>(addablePoint));
        }

        public async Task<PointOfRentalViewModel> GetPointAsync(int id)
        {
            PointOfRentalModel point = await _pointService.GetPointAsync(id);

            return _mapper.Map<PointOfRentalViewModel>(point);
        }

        public async Task ModifyPointAsync(int id, PointOfRentalViewModel modifiedPoint)
        {
            await _pointService.ModifyPointAsync(id, _mapper.Map<PointOfRentalModel>(modifiedPoint));
        }
    }
}