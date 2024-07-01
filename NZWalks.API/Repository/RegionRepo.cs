using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Entities;
using NZWalks.API.IRepository;

/*  This Repo is now unused. I have created a Common Repo for the controllers(NzWalksRepo).
    I am keeping this Repo for the future reference, how we can use common Repo instead of 
    individual Repos for the controllers    */

namespace NZWalks.API.Repository
{
    public class RegionRepo : IRegionRepo
    {
        private readonly NZWalksContext _dbContext;

        public RegionRepo(NZWalksContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateAsync(Region region)
        {
            await _dbContext.Region.AddAsync(region);
            await _dbContext.SaveChangesAsync();

            return region.Id;
        }

        public async Task<bool> DeleteAsync(Region region)
        {
            _dbContext.Region.Remove(region);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext.Region.ToListAsync();
        }

        public Task<Region> GetByIdAsync(Guid id)
        {
            return _dbContext.Region.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Guid> UpdateAsync(Region region)
        {
            _dbContext.Update(region);
            await _dbContext.SaveChangesAsync();

            return region.Id;
        }

        public async Task<Guid> UpdatePartialAsync(Region region)
        {
            _dbContext.Update(region);
            await _dbContext.SaveChangesAsync();

            return region.Id;
        }
    }
}
