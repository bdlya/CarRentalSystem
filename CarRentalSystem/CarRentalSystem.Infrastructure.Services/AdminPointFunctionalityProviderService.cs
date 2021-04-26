using CarRentalSystem.Infrastructure.Data.Models;
using CarRentalSystem.Services.Interfaces;
using CarRentalSystem.Services.InternalInterfaces;
using System.Threading.Tasks;

namespace CarRentalSystem.Infrastructure.Services
{
    public class AdminPointFunctionalityProviderService : IAdminPointFunctionalityProviderService
    {
        private readonly IPointService _pointService;

        public AdminPointFunctionalityProviderService(IPointService pointService)
        {
            _pointService = pointService;
        }

        public async Task AddPointAsync(PointOfRentalModel addablePoint)
        {
            await _pointService.AddPointAsync(addablePoint);
        }

        public async Task<PointOfRentalModel> GetPointAsync(int id)
        {
            return await _pointService.GetPointAsync(id);
        }

        public async Task ModifyPointAsync(int id, PointOfRentalModel modifiedPoint)
        {
            await _pointService.ModifyPointAsync(id, modifiedPoint);
        }
    }
}