using Microsoft.AspNetCore.Components;
using WardrivingMapper.Data.DataModels;
using WardrivingMapper.Data.Interfaces;
using WardrivingMapper.Data.Repositories;

namespace WardrivingMapper.Components.Pages;

public partial class DbTest : ComponentBase
{
    [Inject] IRawDataRepository RawDataRepository { get; init; } = null!;
    [Inject] IUnitOfWork UnitOfWork { get; init; } = null!;
    
    private IEnumerable<RawData>? _rawData;

    private async Task AddRandomRecord()
    {
        try
        {
            var raw = new RawData()
            {
                MAC = "93:39;f9:k2",
                SSID = "test ssid",
                AuthMode = "WEP",
                FirstSeen = DateTime.Now,
                Channel = 1,
                Frequency = 2400,
                CurrentLatitude = 15.0,
                CurrentLongitude = 45.0,
                AltitudeMeters = 120.0,
                AccuracyMeters = 2,
                Type = "WIFI"
            };

            await RawDataRepository.AddAsync(raw);
            await UnitOfWork.SaveChangesAsync();

            await GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task GetAll()
    {
        _rawData = await RawDataRepository.GetAllAsync();
    }

    private async Task ClearRawData()
    {
        try
        {
            await RawDataRepository.DeleteTable();
            await UnitOfWork.SaveChangesAsync();
        
            await GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
