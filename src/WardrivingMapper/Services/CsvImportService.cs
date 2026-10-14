using System.Data;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WardrivingMapper.Data.DataModels;
using WardrivingMapper.Data.Interfaces;
using WardrivingMapper.Models;
using WardrivingMapper.Services.Interfaces;

namespace WardrivingMapper.Services;

public class CsvImportService(IRawDataService RawDataService,
        IUnitOfWork unitOfWork) : ICsvImportService
{

    public async Task ImportAsync(IBrowserFile file, CancellationToken ct = default)
    {
        const int chunk = 50000; 
        var counter = 0;
        var recordsToAdd = new List<RawData>(chunk);
        try 
        {
            await foreach (var record in ReadCsv(file, ct))
            {
                counter++;
                var dataModel = record.ToDataModel();
                recordsToAdd.Add(dataModel);
                if (recordsToAdd.Count >= chunk)
                {
                    await RawDataService.AddRawDataAsync(recordsToAdd);
                    unitOfWork.ClearTracker();
                    recordsToAdd.Clear();
                    counter = 0;
                }
            }

            await RawDataService.AddRawDataAsync(recordsToAdd);
            recordsToAdd.Clear();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error importing data: {ex.Message}");
            throw;
        }
        finally
        {
        }
    }

    public async Task<ImportResult> PreProcessAsync(IBrowserFile file, CancellationToken ct = default)
    {
        var wifi = 0;
        var ble = 0;
        var bt = 0;
        var lte = 0;
        var recordsCount = 0;

        await foreach (var record in ReadCsv(file, ct))
        {
            recordsCount++;
            switch (record.Type)
            {
                case "WIFI":
                    wifi++;
                    break;
                case "BLE":
                    ble++;
                    break;
                case "BT":
                    bt++;
                    break;
                case "LTE":
                    lte++;
                    break;
                default:
                    break;
            }
        }

        return new ImportResult(recordsCount, wifi, ble, bt, lte);
    }

    private static async IAsyncEnumerable<InputDataModel> ReadCsv(IBrowserFile file, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        const long maxFileSize = 10 * 1024 * 1024;

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            BufferSize = 16 * 1024,
            Delimiter = ","
        };

        await using var stream = file.OpenReadStream(
                maxAllowedSize: maxFileSize,
                cancellationToken: cancellationToken);

        using var reader = new StreamReader(
                stream,
                Encoding.UTF8,
                detectEncodingFromByteOrderMarks: true,
                bufferSize: 16 * 1024);

        using var csv = new CsvReader(reader, config);

        // Read header
        if (!await csv.ReadAsync())
            yield break;

        if (!await csv.ReadAsync())
            yield break;

        csv.ReadHeader();

        // Read every data row
        while (await csv.ReadAsync())
        {
            cancellationToken.ThrowIfCancellationRequested();

            var record = csv.GetRecord<InputDataModel>();
            yield return record;
        }
    }
}
