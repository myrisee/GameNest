using GameNest.Infrastructure.Authentication;
using Microsoft.Extensions.Options;

namespace GameNest.RealtimeApi.ConfigureOptions
{
    public class JwtConfigurationOptions(IConfiguration configuration) : IConfigureOptions<JwtOptions>
    {
        public void Configure(JwtOptions options)
        {
            configuration.GetSection("Jwt").Bind(options);
        }
    }
}
