using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.View.ViewModels.Validation
{
    public class PointOfRentalValidationAttribute: ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            if (!(value is PointOfRentalViewModel model))
            {
                throw new NullReferenceException("Point was null");
            }

            string name = model.Name;
            if (name == string.Empty || name.Length < 3)
            {
                throw new ValidationException("Name is incorrect");
            }

            string country = model.Country;
            if (country == string.Empty || country.Length < 3)
            {
                throw new ValidationException("Country is incorrect");
            }

            string city = model.City;
            if (city == string.Empty || city.Length < 3)
            {
                throw new ValidationException("City is incorrect");
            }

            string address = model.Address;
            if (address == string.Empty || address.Length < 3)
            {
                throw new ValidationException("Address is incorrect");
            }

            return true;
        }
    }
}