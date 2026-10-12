using WardrivingMapper.Data.DataModels;

namespace WardrivingMapper.Data.Repositories;

public class RawDataRepository : Repository<RawData, long>, IRawDataRepository
{
    public RawDataRepository(DbFactory dbFactory) : base(dbFactory)
    {
    }   
}