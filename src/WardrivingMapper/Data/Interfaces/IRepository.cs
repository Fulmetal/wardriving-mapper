using System.Linq.Expressions;
using WardrivingMapper.Data.DataModels;

namespace WardrivingMapper.Data.Interfaces;

public interface IRepository<T, TKey> where T : class
{
    Task<T> AttachAsync(T entity);
    Task<long> EntityCountAsync();
    Task<bool> EntityExistsAsync(Expression<Func<T, bool>> expression);
    Task<T?> FindAsync(TKey id);
    Task<PaginatedList<T>> GetPagedAsync(
            Expression<Func<T, bool>>? filter = null,
            int pageNumber = 1,
            int pageSize = 20);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(List<T> list);
    Task DeleteAsync(TKey id);
    Task DeleteRangeAsync(List<TKey> list);
    Task DeleteTable();
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(List<T> list);
    Task<IList<T>> ListAsync(Expression<Func<T, bool>> expression);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
    IQueryable<T> Queriable();
}
