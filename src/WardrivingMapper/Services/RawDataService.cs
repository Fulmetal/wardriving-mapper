using WardrivingMapper.Data.DataModels;
using WardrivingMapper.Data.Interfaces;
using WardrivingMapper.Data.Repositories;
using WardrivingMapper.Services.Interfaces;

namespace WardrivingMapper.Services;

public class RawDataService(IRawDataRepository rawDataRepository,
        IUnitOfWork unitOfWork) : IRawDataService
{
    private readonly IRawDataRepository rawDataRepository = rawDataRepository;

    public async Task<PaginatedList<RawData>> GetRawDataAsync(int pageNumber = 1, int pageSize = 20)
    {
        var data = await rawDataRepository.GetPagedAsync(pageNumber: pageNumber, pageSize: pageSize);
        return data;
    }

    public async Task AddRawDataAsync(RawData rawData)
    {
        await rawDataRepository.AddAsync(rawData);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task AddRawDataAsync(List<RawData> rawDataList)
    {
        await rawDataRepository.AddRangeAsync(rawDataList);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task AddRawDataRangeAsync(List<RawData> rawDataList)
    {
        await rawDataRepository.AddRangeAsync(rawDataList);
    }
}
