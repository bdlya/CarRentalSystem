using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Application.Data.Models.Main;

namespace CarRentalSystem.Application.InternalServices.Interfaces.Main
{
    public interface IPointService
    {
        Task AddPointAsync(PointOfRentalModel addablePoint);

        Task<PointOfRentalModel> GetPointAsync(int id);

        Task ModifyPointAsync(int id, PointOfRentalModel modifiedPoint);

        Task<IQueryable<PointOfRentalModel>> GetPointsAsync();
    }
}