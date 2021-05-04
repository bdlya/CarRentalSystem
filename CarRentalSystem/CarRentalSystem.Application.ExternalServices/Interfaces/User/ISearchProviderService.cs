using System;
using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;

namespace CarRentalSystem.Application.ExternalServices.Interfaces.User
{
    public interface ISearchProviderService
    {
        Task<IQueryable<PointOfRentalModel>> FindPointsAsync(PointSearchModel searchModel);
        Task<IQueryable<CarModel>> FindCarsAsync(int id);
        Task<IQueryable<OrderModel>> FindUserOrdersAsync(int id, OrderSearchModel searchModel);
    }
}