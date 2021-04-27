using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.Interfaces
{
    public interface ISearchProviderService
    {
        Task<IQueryable<PointOfRentalModel>> FindPointsAsync(PointSearchModel searchModel);
    }
}