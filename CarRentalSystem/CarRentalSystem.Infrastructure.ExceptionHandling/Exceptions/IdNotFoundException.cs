using System;

namespace CarRentalSystem.Infrastructure.ExceptionHandling.Exceptions
{
    public class IdNotFoundException: Exception
    {
        public IdNotFoundException() :
            this("Object with this id is not found")
        {
            
        }

        public IdNotFoundException(string message) 
            : base(message)
        {

        }
    }

}