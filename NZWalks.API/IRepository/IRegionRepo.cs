using NZWalks.API.Entities;

namespace NZWalks.API.IRepository
{
    public interface IRegionRepo
    {
        Task<List<Region>> GetAllAsync();
        Task<Region> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(Region region);
        Task<Guid> UpdateAsync(Region region);
        Task<Guid> UpdatePartialAsync(Region region);
        Task<bool> DeleteAsync(Region regions);
    }
}
