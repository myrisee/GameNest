using GameNest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNest.Application.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
        Task<Item> GetByIdAsync(uint id);
        Task<Item> GetByNameAsync(string name);
        Task<Item> AddAsync(Item entity);
        Task<Item> UpdateAsync(Item entity);
        Task DeleteAsync(Item entity);
    }
    
    
}
