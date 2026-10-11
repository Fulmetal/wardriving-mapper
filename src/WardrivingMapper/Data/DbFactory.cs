using Microsoft.EntityFrameworkCore;

namespace WardrivingMapper.Data;

public class DbFactory : IDisposable
{
    private readonly Func<AppDbContext> _instanceFunc;
    private DbContext? _dbContext;
    private bool _disposed;

    public DbFactory(Func<AppDbContext> dbContextFactory)
    {
        _instanceFunc = dbContextFactory;
    }

    public DbContext DbContext => _dbContext ??= _instanceFunc.Invoke();

    public void Dispose()
    {
        if (_disposed || _dbContext == null) return;
        _disposed = true;
        _dbContext.Dispose();
    }
    
}