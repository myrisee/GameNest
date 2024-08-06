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
    public class PlayerRepository(GameNestContext context) : IPlayerRepository
    {
        public async Task<Player> CreateAsync(Player entity)
        {
            context.Players.Add(entity);
            await context.SaveChangesAsync(true);
            return entity;
        }

        public Task DeleteAsync(Player entity)
        {
            context.Players.Remove(entity);
            return context.SaveChangesAsync();
        }

        public Task<List<Player>> GetAllAsync()
        {
            return context.Players.ToListAsync();
        }

        public async Task<Player> GetByGuidAsync(Guid id)
        {
            return await context.Players.FindAsync(id);
        }

        public Task<Player?> GetByUsernameAsync(string username)
        {
            return context.Players.FirstOrDefaultAsync(p => p.Username == username);
        }

        public Task<Player> UpdateAsync(Player entity)
        {
            context.Players.Update(entity);
            return context.SaveChangesAsync().ContinueWith(_ => entity);
        }
    }
}
