using GameNest.Application.Interfaces;
using GameNest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace GameNest.Infrastructure.Authentication
{
    public class JwtProvider(JwtOptions jwtOptions) : IJwtProvider
    {
        public string GenerateToken(Player player)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,player.Id.ToString()),
                new Claim(ClaimTypes.Name, player.Username)
            };

            var signingCredentials =
                new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret)),SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                               issuer: jwtOptions.Issuer,
                               audience: jwtOptions.Audience,
                               claims:claims,
                               expires: DateTime.Now.AddMinutes(30),
                               signingCredentials:signingCredentials
                               );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
