using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Entities;
using NZWalks.API.IRepository;

/*  This Repo is now unused. I have created a Common Repo for the controllers(NzWalksRepo).
    I am keeping this Repo for the future reference, how we can use common Repo instead of 
    individual Repos for the controllers    */

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
