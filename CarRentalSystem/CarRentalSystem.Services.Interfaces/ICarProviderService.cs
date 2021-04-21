using System.Threading.Tasks;
using CarRentalSystem.View.ViewModels;

namespace CarRentalSystem.Services.Interfaces
{
    public interface ICarProviderService
    {
        Task<string> GetCar(int number);
        Task AddCar(CarViewModel addedCar);
    }
}
