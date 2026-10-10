using Microsoft.EntityFrameworkCore;

namespace WardrivingMapper.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<RawData> RawData => Set<RawData>();
}
