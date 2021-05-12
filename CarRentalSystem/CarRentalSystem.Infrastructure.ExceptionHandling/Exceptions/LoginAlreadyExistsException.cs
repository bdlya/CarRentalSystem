using System;

namespace CarRentalSystem.Infrastructure.ExceptionHandling.Exceptions
{
    public class LoginAlreadyExistsException: Exception
    {
        public LoginAlreadyExistsException(string login) 
            : base($"User with login {login} already exists") { }
    }
}