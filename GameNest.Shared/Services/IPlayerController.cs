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
    public interface IPlayerController : IService<IPlayerController>
    {
        UnaryResult<PlayerModel> GetPlayerAsync(Guid playerId);
        UnaryResult<PlayerModel> CreatePlayerAsync(string playerName);
        UnaryResult<PlayerModel> UpdatePlayerAsync(PlayerModel player);
        UnaryResult<PlayerModel> DeletePlayerAsync(Guid playerId);
    }
}
