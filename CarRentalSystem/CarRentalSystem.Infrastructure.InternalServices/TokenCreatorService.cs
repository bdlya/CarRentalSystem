using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Services.InternalInterfaces;
using Microsoft.IdentityModel.Tokens;

namespace CarRentalSystem.Infrastructure.InternalServices
{
    public class TokenCreatorService: ITokenCreatorService
    {
        private readonly IConfiguration _configuration;

        public TokenCreatorService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User CreateTokenForUser(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_configuration["SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }
    }
}