using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;
using System.Text;

namespace WardrivingMapper.Components.Pages;

public partial class Upload : ComponentBase
{
    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    private int _recordsCount;
    private int _wifi;
    private int _ble;
    private int _bt;
    private int _lte;

    private async Task OnFileChange(IBrowserFile file)
    {
        try
        {
            _recordsCount = 0;
            await PreProcessCsv(file);
            StateHasChanged();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task PreProcessCsv(IBrowserFile file, CancellationToken cancellationToken = default)
    {
        const long maxFileSize = 10 *  1024 * 1024;

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            BufferSize = 16 * 1024,
            Delimiter = ","
        };

        await using var stream = file.OpenReadStream(
            maxAllowedSize:  maxFileSize,
            cancellationToken: cancellationToken);
        
        using var reader = new StreamReader(
            stream,
            Encoding.UTF8,
            detectEncodingFromByteOrderMarks: true,
            bufferSize: 16 * 1024);

        using var csv = new CsvReader(reader, config);

        // Read header
        if (!await csv.ReadAsync())
            return;

        if (!await csv.ReadAsync())
            return;

        csv.ReadHeader();

        // Read every data row
        while (await csv.ReadAsync())
        {
            cancellationToken.ThrowIfCancellationRequested();

            var record = csv.GetRecord<Models.InputDataModel>();

            _recordsCount++;
            switch (record.Type)
            {
               case "WIFI":
                   _wifi++;
                   break;
               case "BLE":
                   _ble++;
                   break;
               case "BT":
                   _bt++;
                   break;
               case "LTE":
                   _lte++;
                   break;
                default:
                    break;
            }

            // Your processing here
            //ProcessRecord(record);
        }
    }
}
