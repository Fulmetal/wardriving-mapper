using Microsoft.AspNetCore.Components.Forms;
using WardrivingMapper.Models;

namespace WardrivingMapper.Services.Interfaces;

public interface ICsvImportService
{
    /// <summary>Pre-processes a CSV file without importing. Returns type counts.</summary>
    Task<ImportResult> PreProcessAsync(IBrowserFile file, CancellationToken ct = default);

    /// <summary>Imports all records from the given CSV file into the database.</summary>
    Task ImportAsync(IBrowserFile file, CancellationToken ct = default);
}
