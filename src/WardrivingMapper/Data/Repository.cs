using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WardrivingMapper.Data.DataModels;
using WardrivingMapper.Data.Interfaces;

namespace WardrivingMapper.Data;

public class Repository<T, TKey> : IRepository<T, TKey> where T : class
{
    private readonly DbFactory _dbFactory;
    private DbSet<T>? _dbSet;

    public Repository(DbFactory dbFactory)
    {
        _dbFactory = dbFactory;
    }

    protected DbSet<T> DbSet => _dbSet ?? (_dbSet = _dbFactory.DbContext.Set<T>());

    public async Task<T> AttachAsync(T entity)
    {
        return DbSet.Attach(entity).Entity;
    }

    public async Task<long> EntityCountAsync()
    {
        return await DbSet.CountAsync();
    }

    public async Task<bool> EntityExistsAsync(Func<T, bool> expression)
    {
        return await Task.FromResult(DbSet.Any(expression));
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.AsNoTracking().ToListAsync();
    }
    
    public async Task<IEnumerable<T>> SudoGetAllAsync()
    {
        return await DbSet.AsNoTracking().ToListAsync();
    }

    public async Task<T?> FindAsync(TKey id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<T> AddAsync(T entity)
    {
        var newEntity = await DbSet.AddAsync(entity);
        return newEntity.Entity;
    }

    public async Task AddRangeAsync(List<T> list)
    {
        await DbSet.AddRangeAsync(list);
    }

    public async Task DeleteAsync(TKey id)
    {
        var e = await FindAsync(id);

        if (e == null) return;
        
        DbSet.Remove(e);
    }

    public async Task DeleteAsync(T e)
    {
        DbSet.Remove(e);
    }


    public async Task DeleteRangeAsync(List<TKey> list)
    {
        var entities = await ListAsync(x => list.Contains(((IEntityBase<TKey>)x).Id));

        DbSet.RemoveRange(entities);
    }

    public async Task<IList<T>> ListAsync(Expression<Func<T, bool>> expression)
    {
        var r = DbSet.AsNoTracking().Where(expression);

        return await r.ToListAsync();
    }

    public async Task<T?> SingleAsync(Expression<Func<T, bool>> expression)
    {
        var r = DbSet.AsQueryable();
        return await r.FirstOrDefaultAsync(expression);
    }

    public async Task UpdateAsync(T entity)
    {
        DbSet.Update(entity);
    }

    public async Task UpdateRangeAsync(List<T> list)
    {
        DbSet.UpdateRange(list);
    }

    public IQueryable<T> Queriable()
    {
        return DbSet;
    }
}