using GameNest.Shared.MessagePacks;
using MagicOnion;

namespace GameNest.Shared.Services;

public interface IAuthService : IService<IAuthService>
{
    UnaryResult<LoginResponse> LoginAsync(LoginMessage message);
    UnaryResult<RegisterResponse> RegisterAsync(RegisterMessage message);
}