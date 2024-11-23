
using System.Linq.Expressions;
using TradeBuddy.Review.Domain.Entities;

namespace TradeBuddy.Review.Domain.Interfaces
{
    public interface IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        Task<T> GetByIdAsync(TKey id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(TKey id);
        Task<List<T>> SearchAsync(Expression<Func<T, bool>> predicate);
    }
}

