using System.Threading.Tasks;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.ExternalServices.Interfaces.Administrator.Common;
using CarRentalSystem.Application.InternalServices.Interfaces.Main;

namespace CarRentalSystem.Application.ExternalServices.Implementation.Administrator.Common
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