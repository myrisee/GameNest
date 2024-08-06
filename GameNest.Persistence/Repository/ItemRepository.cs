using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNest.Application.Interfaces;
using GameNest.Domain.Entities;
using GameNest.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GameNest.Persistence.Repository
{
    public class ItemRepository(GameNestContext context) : IItemRepository
    {
        public Task<List<Item>> GetAllAsync()
        {
            return context.Items.ToListAsync();
        }

        public async Task<Item> GetByIdAsync(uint id)
        {
            return await context.Items.FindAsync(id);
        }

        public Task<Item> GetByNameAsync(string name)
        {
            name = name.ToLower();
            return context.Items.FirstOrDefaultAsync(i => i.Name.ToLower() == name);
        }

        public async Task<Item> AddAsync(Item entity)
        {
            context.Items.Add(entity);
            await context.SaveChangesAsync(true);
            return entity;
        }

        public Task<Item> UpdateAsync(Item entity)
        {
            context.Items.Update(entity);
            return context.SaveChangesAsync().ContinueWith(_ => entity);
        }

        public Task DeleteAsync(Item entity)
        {
            context.Items.Remove(entity);
            return context.SaveChangesAsync();
        }
    }
}
