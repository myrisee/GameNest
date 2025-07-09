using GameNest.Application.Interfaces;
using GameNest.Domain.Entities;
using GameNest.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GameNest.Persistence.Repository
{
    public class AccountRepository(GameNestContext context,IJwtProvider provider) : IAccountRepository
    {
        public Task<Account?> GetByUsernameAndPasswordAsync(string username, string password)
        {
            return context.Accounts
                .Include(a => a.Items)
                .ThenInclude(ii => ii.Item)
                .Include(a => a.Loadout)
                .ThenInclude(l => l.Main)
                .Include(a => a.Loadout)
                .ThenInclude(l => l.Secondary)
                .Include(a => a.Loadout)
                .ThenInclude(l => l.Chest)
                .Include(a => a.Loadout)
                .ThenInclude(l => l.Helmet)
                .FirstOrDefaultAsync(p => p.Username == username && p.Password == password);
        }

        public async Task<Account> CreateAsync(Account entity)
        {
            try
            {
                context.Accounts.Add(entity);
                await context.SaveChangesAsync(true);
                return entity;
            }
            catch (Exception ex)
            {
                // Hata loglanabilir veya üst katmana iletilebilir
                throw new Exception($"Account kaydı sırasında hata oluştu: {ex.Message}", ex);
            }
        }

        public Task DeleteAsync(Account entity)
        {
            context.Accounts.Remove(entity);
            return context.SaveChangesAsync();
        }

        public Task<List<Account>> GetAllAsync()
        {
            return context.Accounts.ToListAsync();
        }

        public async Task<Account> GetByGuidAsync(Guid id)
        {
            return await context.Accounts
                .Include(a => a.Items)
                .ThenInclude(ii => ii.Item)
                .Include(a => a.Loadout)
                .ThenInclude(l => l.Main)
                .Include(a => a.Loadout)
                .ThenInclude(l => l.Secondary)
                .Include(a => a.Loadout)
                .ThenInclude(l => l.Chest)
                .Include(a => a.Loadout)
                .ThenInclude(l => l.Helmet)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<Account?> GetByUsernameAsync(string username)
        {
            return context.Accounts
                .Include(a => a.Items)
                .ThenInclude(ii => ii.Item)
                .Include(a => a.Loadout)
                .ThenInclude(l => l.Main)
                .Include(a => a.Loadout)
                .ThenInclude(l => l.Secondary)
                .Include(a => a.Loadout)
                .ThenInclude(l => l.Chest)
                .Include(a => a.Loadout)
                .ThenInclude(l => l.Helmet)
                .FirstOrDefaultAsync(p => p.Username == username);
        }

        public async Task<Account> UpdateAsync(Account entity)
        {
            context.Accounts.Update(entity);
            if (entity.Loadout != null)
            {
                // Loadout'un state'ini Modified olarak işaretle
                context.Entry(entity.Loadout).State = entity.Loadout.Id == default ? EntityState.Added : EntityState.Modified;
            }
            return await context.SaveChangesAsync().ContinueWith(_ => entity);
        }
    }
}
