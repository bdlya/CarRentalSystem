using AutoMapper;
using CarRentalSystem.Application.Data.Models.Main;
using CarRentalSystem.Application.Data.Models.Support;
using CarRentalSystem.Application.InternalInterfaces.Support;
using CarRentalSystem.Domain.Entities.Support;
using CarRentalSystem.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Application.InternalServices.Implementation.Support
{
    public class TokenCreatorService: ITokenCreatorService
    {
        private readonly IConfiguration _configuration;
        private readonly ICarRentalSystemRepository<RefreshToken> _refreshTokens;
        private readonly IMapper _mapper;

        public TokenCreatorService(IConfiguration configuration, ICarRentalSystemRepository<RefreshToken> refreshTokens, IMapper mapper)
        {
            _configuration = configuration;
            _refreshTokens = refreshTokens;
            _mapper = mapper;
        }

        public async Task<UserModel> CreateTokensForUserAsync(UserModel user)
        {
            user.Token = CreateTokenForUser(user);
            user.RefreshToken = await CreateRefreshTokenForUserAsync(user);

            return user;
        }

        private string CreateTokenForUser(UserModel user)
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

        private async Task<RefreshTokenModel> CreateRefreshTokenForUserAsync(UserModel user)
        {
            RefreshTokenModel newRefreshToken;

            if (user.RefreshTokenId != null)
            {
                newRefreshToken = user.RefreshToken;
                newRefreshToken = UpdateRefreshTokenData(newRefreshToken);
                await _refreshTokens.UpdateAsync(_mapper.Map<RefreshToken>(newRefreshToken));
            }
            else
            {
                newRefreshToken = UpdateRefreshTokenData(new RefreshTokenModel());
                await _refreshTokens.CreateAsync(_mapper.Map<RefreshToken>(newRefreshToken));
            }

            return newRefreshToken;
        }

        private static RefreshTokenModel UpdateRefreshTokenData(RefreshTokenModel refreshToken)
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