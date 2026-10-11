using Microsoft.EntityFrameworkCore;
using WardrivingMapper.Data.DataModels;

namespace WardrivingMapper.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<RawData> RawData => Set<RawData>();
}
