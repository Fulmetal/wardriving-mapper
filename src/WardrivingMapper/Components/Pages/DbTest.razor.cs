using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using WardrivingMapper.Data;
using WardrivingMapper.Data.DataModels;

namespace WardrivingMapper.Components.Pages;

public partial class DbTest : ComponentBase
{
    [Inject] AppDbContext DbContext { get; init; } = null!;
    private List<RawData>? _rawData;

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

            DbContext.RawData.Add(raw);
            await DbContext.SaveChangesAsync();

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
        _rawData = DbContext.RawData.ToList();
    }

    private async Task ClearRawData()
    {
        try
        {
            var records = await DbContext.RawData.ToListAsync();
            DbContext.RawData.RemoveRange(records);
            await DbContext.SaveChangesAsync();
        
            await GetAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
