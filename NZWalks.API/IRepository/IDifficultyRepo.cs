using NZWalks.API.Entities;

namespace NZWalks.API.IRepository
{
    public interface IDifficultyRepo
    {
        Task<List<Difficulty>> GetAllAsync();
        Task<Difficulty> GetByIdAsync(Guid id);
        Task<Guid> UpdateAsync(Difficulty difficulty);
        Task<Guid> CreateAsync(Difficulty difficulty);
        Task<bool> DeleteAsync(Difficulty difficulty);
    }
}
