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
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;

        public JwtProvider(Microsoft.Extensions.Options.IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
            Console.WriteLine($"[JwtProvider] Secret from config: '{_jwtOptions.Secret}'");
        }

        public string GenerateToken(Account account)
        {
            Console.WriteLine($"[JwtProvider.GenerateToken] Secret: '{_jwtOptions.Secret}'");
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.Username)
            };

            var signingCredentials =
                new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret)),SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                               issuer: _jwtOptions.Issuer,
                               audience: _jwtOptions.Audience,
                               claims:claims,
                               expires: DateTime.Now.AddMinutes(30),
                               signingCredentials:signingCredentials
                               );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
