using System;
using CarRentalSystem.Domain.Entities.Base;

namespace CarRentalSystem.Domain.Entities
{
    public class Car: BaseEntity
    {
        public string Brand { get; set; }

        public Car(string brand)
        {
            Brand = brand;
        }
    }
}
