using GameNest.Shared.MessagePacks;
using MagicOnion;

namespace GameNest.Shared.Services;

public interface IAccountService : IService<IAccountService>
{
    UnaryResult<LoginResponse> LoginAsync(LoginMessage message);
    UnaryResult<RegisterResponse> RegisterAsync(RegisterMessage message);
}