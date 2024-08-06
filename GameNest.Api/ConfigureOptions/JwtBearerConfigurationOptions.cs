using GameNest.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GameNest.WebApi.ConfigureOptions
{
    public class JwtBearerConfigurationOptions(IOptions<JwtOptions> options) : IConfigureOptions<JwtBearerOptions>
    {
        private readonly JwtOptions jwtOptions = options.Value;

        public void Configure(JwtBearerOptions bearerOptions)
        {
            bearerOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOptions.Issuer,
                ValidAudience = jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret))
            };
        }
    }
}
