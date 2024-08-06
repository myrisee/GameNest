using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNest.Domain.Entities;

namespace GameNest.Application.Interfaces
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAllAsync();
        Task<Player?> GetByGuidAsync(Guid id);
        Task<Player?> GetByUsernameAsync(string username);
        Task<Player> CreateAsync(Player entity);
        Task<Player> UpdateAsync(Player entity);
        Task DeleteAsync(Player entity);
    }
}
