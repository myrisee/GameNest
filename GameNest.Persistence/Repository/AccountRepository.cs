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
            return context.Accounts.FirstOrDefaultAsync(p => p.Username == username && p.Password == password);
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
            return await context.Accounts.FindAsync(id);
        }

        public Task<Account?> GetByUsernameAsync(string username)
        {
            return context.Accounts.FirstOrDefaultAsync(p => p.Username == username);
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
