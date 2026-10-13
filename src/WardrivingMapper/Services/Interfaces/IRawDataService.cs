using WardrivingMapper.Data.DataModels;

namespace WardrivingMapper.Services.Interfaces;

public interface IRawDataService
{
    Task<PaginatedList<RawData>> GetRawDataAsync(int pageNumber, int pageSize);
    Task AddRawDataAsync(RawData rawData);
    Task AddRawDataAsync(List<RawData> rawDataList);
    Task AddRawDataRangeAsync(List<RawData> rawDataList);
}
