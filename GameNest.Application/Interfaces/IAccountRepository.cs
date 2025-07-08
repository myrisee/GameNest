using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNest.Domain.Entities;

namespace GameNest.Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAsync();
        Task<Account?> GetByGuidAsync(Guid id);
        Task<Account?> GetByUsernameAsync(string username);
        Task<Account?> GetByUsernameAndPasswordAsync(string username, string password);
        Task<Account> CreateAsync(Account entity);
        Task<Account> UpdateAsync(Account entity);
        Task DeleteAsync(Account entity);
    }
}
