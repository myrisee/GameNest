using AutoMapper;
using GameNest.Application.Interfaces;
using GameNest.Domain.Entities;
using GameNest.Persistence.Context;
using GameNest.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GameNest.Persistence.Repository;

public class LoadoutRepository(GameNestContext context,IMapper mapper) : ILoadoutRepository
{
    public Task<Loadout?> GetLoadoutByAccountIdAsync(Guid accountId)
    {
        return context.Loadouts
            .Include(l => l.Main)
            .ThenInclude(ii => ii.Item)
            .Include(l => l.Secondary)
            .ThenInclude(ii => ii.Item)
            .Include(l => l.Helmet)
            .ThenInclude(ii => ii.Item)
            .Include(l => l.Chest)
            .ThenInclude(ii => ii.Item)
            .FirstOrDefaultAsync(loadout => loadout.AccountId == accountId);
    }

    public Task<Loadout?> GetLoadoutByIdAsync(Guid loadoutId)
    {
        return context.Loadouts
            .Include(l => l.Main)
            .ThenInclude(ii => ii.Item)
            .Include(l => l.Secondary)
            .ThenInclude(ii => ii.Item)
            .Include(l => l.Helmet)
            .ThenInclude(ii => ii.Item)
            .Include(l => l.Chest)
            .ThenInclude(ii => ii.Item)
            .FirstOrDefaultAsync(loadout => loadout.Id == loadoutId);
    }

    public Task<Loadout> SaveLoadoutAsync(Loadout loadout)
    {
        context.Loadouts.Update(loadout);
        return context.SaveChangesAsync().ContinueWith(_ => loadout);
    }

    public Task<Loadout> CreateLoadoutAsync(Loadout loadout)
    {
        context.Loadouts.Add(loadout);
        return context.SaveChangesAsync().ContinueWith(_ => loadout);
    }
}