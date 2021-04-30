using System;
using System.Linq;
using System.Threading.Tasks;
using CarRentalSystem.Infrastructure.Data.Models;

namespace CarRentalSystem.Services.Interfaces
{
    public interface ISearchProviderService
    {
        Task<IQueryable<PointOfRentalModel>> FindPointsAsync(PointSearchModel searchModel);
        Task<IQueryable<CarModel>> FindCarsAsync(int id);
        Task<IQueryable<OrderModel>> FindUserOrdersAsync(int id, OrderSearchModel searchModel);
    }
}