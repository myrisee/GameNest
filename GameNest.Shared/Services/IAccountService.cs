using GameNest.Shared.MessagePacks;
using GameNest.Shared.ViewModels;
using MagicOnion;

namespace GameNest.Shared.Services;

public interface IAccountService : IService<IAccountService>
{
    UnaryResult<AccountModel> GetCurrentAccountAsync();
}