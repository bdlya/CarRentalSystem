using System;

namespace CarRentalSystem.Infrastructure.ExceptionHandling.Exceptions
{
    public class EntityNotFoundException: Exception
    {
        public EntityNotFoundException(string typeName) 
            : base($"Entity of type {typeName} with the specified id is not found") { }
    }
}