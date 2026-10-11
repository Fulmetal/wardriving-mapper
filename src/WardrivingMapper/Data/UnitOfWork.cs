using Microsoft.EntityFrameworkCore.Storage;
using WardrivingMapper.Data.Interfaces;

namespace WardrivingMapper.Data;

public class UnitOfWork(DbFactory dbFactory) : IUnitOfWork
{
    public void ClearTracker()
    {
        dbFactory.DbContext.ChangeTracker.Clear();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await dbFactory.DbContext.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await dbFactory.DbContext.Database.BeginTransactionAsync();
    }
}