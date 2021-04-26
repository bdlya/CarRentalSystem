using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.View.ViewModels.Validation
{
    public class AdditionalServiceValidationAttribute: ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            if (!(value is AdditionalServiceViewModel model))
            {
                throw new NullReferenceException("Car was null");
            }

            string name = model.Name;
            if (name == string.Empty || name.Length < 3)
            {
                throw new ValidationException("Name is incorrect");
            }

            int cost = model.Cost;
            if (cost <= 0 || cost > 600)
            {
                throw new ValidationException("Cost is incorrect");
            }

            return true;
        }
    }
}