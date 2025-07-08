using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNest.Shared.ViewModels;
using Grpc.Core;
using MagicOnion;

namespace GameNest.Shared.Services
{
    public interface IPlayerService : IService<IPlayerService>
    {
        UnaryResult<AccountModel> GetPlayerAsync(Guid playerId);
        UnaryResult<AccountModel> CreatePlayerAsync(string playerName);
        UnaryResult<AccountModel> UpdatePlayerAsync(AccountModel account);
        UnaryResult<AccountModel> DeletePlayerAsync(Guid playerId);
    }
}
