using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Entities;
using NZWalks.API.IRepository;
using System.Linq.Expressions;

namespace NZWalks.API.Repository
{
    public class NzWalksRepo<T> : INzWalksRepo<T> where T : class
    {
        private readonly NZWalksContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public NzWalksRepo(NZWalksContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T model)
        {
            await _dbSet.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<bool> DeleteAsync(T model)
        {
            _dbSet.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public Task<T> GetByIdAsync(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter).FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T model)
        {
            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<T> UpdatePartialAsync(T model)
        {
            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }
    }
}
