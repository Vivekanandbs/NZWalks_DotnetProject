using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Entities;
using NZWalks.API.IRepository;

namespace NZWalks.API.Repository
{
    public class DifficultyRepo : IDifficultyRepo
    {
        public readonly NZWalksContext _dbContext;

        public DifficultyRepo(NZWalksContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateAsync(Difficulty difficulty)
        {
            await _dbContext.AddAsync(difficulty);
            await _dbContext.SaveChangesAsync();

            return difficulty.Id;
        }

        public async Task<bool> DeleteAsync(Difficulty difficulty)
        {
            _dbContext.Remove(difficulty);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Difficulty>> GetAllAsync()
        {
            return await _dbContext.Difficulties.ToListAsync();
        }

        public async Task<Difficulty> GetByIdAsync(Guid id)
        {
            return await _dbContext.Difficulties.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Guid> UpdateAsync(Difficulty difficulty)
        {
            _dbContext.Update(difficulty);
            await _dbContext.SaveChangesAsync();

            return difficulty.Id;
        }
    }
}
