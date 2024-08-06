using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNest.Domain.Entities;

namespace GameNest.Application.Interfaces
{
    public interface IClanRepository
    {
        Task<List<Clan>> GetAllAsync();
        Task<Clan> GetByIdAsync(uint id);
        Task<Clan> GetByNameAsync(string name);
        Task<Clan> AddAsync(Clan entity);
        Task<Clan> UpdateAsync(Clan entity);
        Task DeleteAsync(Clan entity);
    }
}
