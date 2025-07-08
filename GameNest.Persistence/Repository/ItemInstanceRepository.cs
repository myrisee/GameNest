using GameNest.Application.Interfaces;
using GameNest.Domain.Entities;
using GameNest.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GameNest.Persistence.Repository
{
    public class ItemInstanceRepository(GameNestContext gameNestContext) : IItemInstanceRepository
    {
        public Task<List<ItemInstance>> GetAllAsync()
        {
            return gameNestContext.ItemInstances.ToListAsync();
        }

        public async Task<ItemInstance?> GetByInstanceIdAsync(Guid instanceId)
        {
            return await gameNestContext.ItemInstances.FindAsync(instanceId);
        }

        public Task<List<ItemInstance>> GetByPlayerIdAsync(Guid playerId)
        {
            return gameNestContext.ItemInstances.Where(i => i.PlayerId == playerId).ToListAsync();
        }

        public Task<List<ItemInstance>> GetByItemId(uint itemId)
        {
            return gameNestContext.ItemInstances.Where(i => i.Item.Id == itemId).ToListAsync();
        }

        public Task<ItemInstance> AddAsync(ItemInstance entity)
        {
            gameNestContext.ItemInstances.Add(entity);
            return gameNestContext.SaveChangesAsync().ContinueWith(_ => entity);
        }

        public Task<ItemInstance> UpdateAsync(ItemInstance entity)
        {
            gameNestContext.ItemInstances.Update(entity);
            return gameNestContext.SaveChangesAsync().ContinueWith(_ => entity);
        }

        public Task DeleteAsync(ItemInstance entity)
        {
            gameNestContext.ItemInstances.Remove(entity);
            return gameNestContext.SaveChangesAsync();
        }
    }
}
