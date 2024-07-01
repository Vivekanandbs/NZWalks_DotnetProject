using NZWalks.API.Entities;
using System.Linq.Expressions;

namespace NZWalks.API.IRepository
{
    public interface INzWalksRepo<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter);
        Task<T> UpdateAsync(T model);
        Task<T> UpdatePartialAsync(T model);
        Task<T> CreateAsync(T model);
        Task<bool> DeleteAsync(T model);
    }
}
