using CarRentalSystem.Domain.Entities;
using CarRentalSystem.Services.InternalInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CarRentalSystem.Domain.Interfaces;

namespace CarRentalSystem.Infrastructure.InternalServices
{
    public class TokenCreatorService: ITokenCreatorService
    {
        private readonly IConfiguration _configuration;
        private readonly IRentalRepository<RefreshToken> _refreshTokens;

        public TokenCreatorService(IConfiguration configuration, IRentalRepository<RefreshToken> refreshTokens)
        {
            _configuration = configuration;
            _refreshTokens = refreshTokens;
        }

        public User CreateTokensForUser(User user)
        {
            user.Token = CreateTokenForUser(user);
            user.RefreshToken = CreateRefreshTokenForUser(user);

            return user;
        }

        private string CreateTokenForUser(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_configuration["SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.Now.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private RefreshToken CreateRefreshTokenForUser(User user)
        {
            RefreshToken newRefreshToken;

            if (user.RefreshTokenId != null)
            {
                newRefreshToken = user.RefreshToken;
                newRefreshToken = UpdateRefreshTokenData(newRefreshToken);
                _refreshTokens.Update(newRefreshToken);
            }
            else
            {
                newRefreshToken = UpdateRefreshTokenData(new RefreshToken());
                _refreshTokens.Create(newRefreshToken);
            }

            return newRefreshToken;
        }

        private RefreshToken UpdateRefreshTokenData(RefreshToken refreshToken)
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);

            refreshToken.Token = Convert.ToBase64String(randomBytes);
            refreshToken.Created = DateTime.Now;
            refreshToken.Expires = DateTime.Now.AddDays(7);

            return refreshToken;
        }
    }
}