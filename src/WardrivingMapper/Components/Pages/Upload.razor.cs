using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using WardrivingMapper.Services.Interfaces;
using WardrivingMapper.Models;

namespace WardrivingMapper.Components.Pages;

public partial class Upload : ComponentBase
{
    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    [Inject] public IRawDataService RawDataService { get; set; } = null!;
    [Inject] public ICsvImportService CsvService { get; set; } = null!;

    private IBrowserFile? _selectedFile;
    private ImportResult? _importResult;

    private async Task OnFileChange(IBrowserFile file)
    {
        try
        {
            _selectedFile = file; 
            _importResult = await CsvService.PreProcessAsync(file);
            StateHasChanged();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task ImportData()
    {
        if (_selectedFile == null)
        {
            Snackbar.Add("No file selected for import.", Severity.Warning);
            return;
        }

        try
        {
            await CsvService.ImportAsync(_selectedFile); 

            Snackbar.Add($"Successfully imported {_importResult?.TotalRecords} records.", Severity.Success);
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Error importing data: {ex.Message}", Severity.Error);
        }
    }

}
