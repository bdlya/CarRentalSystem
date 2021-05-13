using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.ExternalInterfaces.User
{
    public interface ISearchProviderService
    {
        Task<IQueryable<PointOfRentalModel>> FindPointsAsync(PointSearchModel searchModel);
        Task<IQueryable<CarModel>> FindCarsAsync(int id, CarSearchModel searchModel);
        Task<IQueryable<OrderModel>> FindUserOrdersAsync(int id, OrderSearchModel searchModel);
    }
}