using Microsoft.AspNetCore.Authorization;

namespace CarRentalSystem.Infrastructure.Data.Policies
{
    public static class Policy
    {
        public const string Administrator = "Administrator";

        public const string Customer = "Customer";

        public static AuthorizationPolicy AdministratorPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(Administrator)
                .Build();
        }

        public static AuthorizationPolicy CustomerPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(Customer)
                .Build();
        }
    }
}