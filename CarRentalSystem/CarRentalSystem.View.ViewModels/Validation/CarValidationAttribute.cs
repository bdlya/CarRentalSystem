using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.View.ViewModels.Validation
{
    public class CarValidationAttribute: ValidationAttribute
    {
        //private readonly IPointOfRentalService _pointService;

        //public CarValidationAttribute(IPointOfRentalService pointService)
        //{
        //    _pointService = pointService;
        //}

        public override bool IsValid(object value)
        {
            CarViewModel model = value as CarViewModel;

            if (model == null)
            {
                throw new NullReferenceException("Car was null");
            }

            string brand = model.Brand;
            if (brand == string.Empty || brand.Length < 3)
            {
                throw new ValidationException("Brand is incorrect");
            }

            int numberOfSeats = model.NumberOfSeats;
            if (numberOfSeats < 2 || numberOfSeats > 10)
            {
                throw new ValidationException("Number of seats is incorrect");
            }

            int averageFuelConsumption = model.AverageFuelConsumption;
            if (averageFuelConsumption <= 0 || averageFuelConsumption > 100)
            {
                throw new ValidationException("Average fuel consumption is incorrect");
            }

            string transmissionType = model.TransmissionType.ToLower();
            if (transmissionType != "automatic" && transmissionType != "mechanic")
            {
                throw new ValidationException("Transmission type is incorrect");
            }

            int costPerHour = model.CostPerHour;
            if (costPerHour <= 0 || costPerHour > 3000)
            {
                throw new ValidationException("Cost per hour is incorrect");
            }

            //bool pointIsExists = await _pointService.IsPointExists(model.PointOfRentalId);
            //if (!pointIsExists)
            //{
            //    return false;
            //}

            return true;
        }
    }
}