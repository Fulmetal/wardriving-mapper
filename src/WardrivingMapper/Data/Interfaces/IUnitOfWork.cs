using Microsoft.EntityFrameworkCore.Storage;

namespace WardrivingMapper.Data.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();

    Task<IDbContextTransaction> BeginTransactionAsync();
    void ClearTracker();
}
