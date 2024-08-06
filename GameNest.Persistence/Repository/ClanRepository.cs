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
    public class ClanRepository(GameNestContext gameNestContext) : IClanRepository
    {
        public Task<List<Clan>> GetAllAsync()
        {
            return gameNestContext.Clans.ToListAsync();
        }

        public async Task<Clan> GetByIdAsync(uint id)
        {
            return await gameNestContext.Clans.FindAsync(id);
        }

        public Task<Clan> GetByNameAsync(string name)
        {
            return gameNestContext.Clans.FirstOrDefaultAsync(c => c.Name == name);
        }

        public Task<Clan> AddAsync(Clan entity)
        {
            gameNestContext.Clans.Add(entity);
            return gameNestContext.SaveChangesAsync().ContinueWith(_ => entity);
        }

        public Task<Clan> UpdateAsync(Clan entity)
        {
            gameNestContext.Clans.Update(entity);
            return gameNestContext.SaveChangesAsync().ContinueWith(_ => entity);
        }

        public Task DeleteAsync(Clan entity)
        {
            gameNestContext.Clans.Remove(entity);
            return gameNestContext.SaveChangesAsync();
        }
    }
}
