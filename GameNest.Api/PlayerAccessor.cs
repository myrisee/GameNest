using System.Security.Claims;
using GameNest.Application.Interfaces;

namespace GameNest.WebApi
{
    public class PlayerAccessor(IHttpContextAccessor httpContextAccessor) : IPlayerAccessor
    {
        public ClaimsPrincipal User => httpContextAccessor?.HttpContext?.User;
    }
}
