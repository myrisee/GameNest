using GameNest.Domain.Entities;
using GameNest.Shared.ViewModels;

namespace GameNest.Application.Interfaces;

public interface ILoadoutRepository
{
    Task<Loadout?> GetLoadoutByAccountIdAsync(Guid accountId);
    Task<Loadout?> GetLoadoutByIdAsync(Guid loadoutId);
    Task<Loadout> SaveLoadoutAsync(Loadout loadout);
    Task<Loadout> CreateLoadoutAsync(Loadout loadout);
}