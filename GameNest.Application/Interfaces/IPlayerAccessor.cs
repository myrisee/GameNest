using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameNest.Application.Interfaces
{
    public interface IPlayerAccessor
    {
        ClaimsPrincipal User { get; }
    }
}
