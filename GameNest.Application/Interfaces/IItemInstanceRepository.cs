using GameNest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNest.Application.Interfaces
{
    public interface IItemInstanceRepository
    {
        Task<List<ItemInstance>> GetAllAsync();
        Task<ItemInstance?> GetByInstanceIdAsync(Guid instanceId);
        Task<List<ItemInstance>> GetByPlayerIdAsync(Guid playerId);
        Task<List<ItemInstance>> GetByItemId(uint itemId);
        Task<ItemInstance> AddAsync(ItemInstance entity);
        Task<ItemInstance> UpdateAsync(ItemInstance entity);
        Task DeleteAsync(ItemInstance entity);
    }
}
