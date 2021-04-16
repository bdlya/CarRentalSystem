using CarRentalSystem.View.ViewModels;

namespace CarRentalSystem.Services.Interfaces
{
    public interface ICarProviderService
    {
        string GetCar(int number);
        bool AddCar(CarViewModel addedCar);
    }
}
