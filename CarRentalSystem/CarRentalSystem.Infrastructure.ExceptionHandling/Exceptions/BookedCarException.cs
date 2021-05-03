using System;

namespace CarRentalSystem.Infrastructure.ExceptionHandling.Exceptions
{
    public class BookedCarException: Exception
    {
        public BookedCarException(int carId) 
            : base($"Car with id {carId} is already ordered.") { }
    }
}