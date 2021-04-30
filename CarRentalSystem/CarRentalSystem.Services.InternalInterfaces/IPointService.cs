using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.InternalInterfaces
{
    public interface IPointService
    {
        Task AddPointAsync(PointOfRentalModel addablePoint);
        Task<PointOfRentalModel> GetPointAsync(int id);
        Task ModifyPointAsync(int id, PointOfRentalModel modifiedPoint);
        Task<IQueryable<PointOfRentalModel>> GetPointsAsync();
    }
}