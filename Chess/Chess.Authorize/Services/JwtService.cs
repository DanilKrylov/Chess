using Chess.Authorize.DtoModels;
using Chess.Authorize.Interfaces;
using Chess.Authorize.Options;
using Chess.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Authorize.Services
{
    internal class JwtService : IJwtService
    {
        private readonly JwtConfigure _jwtConfiguration;

        public JwtService(IOptions<JwtConfigure> jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration.Value;
        }

        public JwtInfo CreateToken(Player user)
        {
            var expiration = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_jwtConfiguration.ExpirationMinutes));

            var token = CreateJwtToken(
                CreateClaims(user),
                CreateSigningCredentials(),
                expiration
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return new JwtInfo
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = expiration
            };
        }

        private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration) =>
            new JwtSecurityToken(
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

        private Claim[] CreateClaims(IdentityUser user) =>
            new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

        private SigningCredentials CreateSigningCredentials() =>
            new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtConfiguration.Key)
                ),
                SecurityAlgorithms.HmacSha256
            );
    }
}
