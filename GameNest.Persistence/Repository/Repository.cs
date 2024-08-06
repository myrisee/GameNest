using GameNest.Application.Interfaces;
using GameNest.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GameNest.Persistence.Repository
{
    public class Repository<T>(GameNestContext context) : IRepository<T> where T : class
    {
        public Task AddAsync(T entity)
        {
            context.Set<T>().Add(entity);
            return context.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            var entity = context.Set<T>().Find(id);
            context.Set<T>().Remove(entity);
            return context.SaveChangesAsync();
        }

        public Task<List<T>> GetAllAsync()
        {
            return context.Set<T>().ToListAsync();
        }

        public ValueTask<T?> GetByIdAsync(int id)
        {
            return context.Set<T?>().FindAsync(id);
        }

        public ValueTask<T?> GetByGuidAsync(Guid guid)
        {
            return context.Set<T?>().FindAsync(guid);
        }

        public Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            return context.SaveChangesAsync();
        }

        public Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChangesAsync();
        }
    }
}
