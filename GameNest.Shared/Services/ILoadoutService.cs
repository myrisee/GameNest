using GameNest.Shared.ViewModels;
using MagicOnion;

namespace GameNest.Shared.Services;

public interface ILoadoutService : IService<ILoadoutService>
{
    UnaryResult<LoadoutModel> GetLoadoutAsync();
    UnaryResult<LoadoutModel> GetLoadoutByIdAsync(Guid loadoutId);
    UnaryResult<LoadoutModel> SaveLoadoutAsync(LoadoutModel loadout);
}