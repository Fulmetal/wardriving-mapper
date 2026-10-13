using Microsoft.AspNetCore.Components;
using WardrivingMapper.Data.DataModels;
using WardrivingMapper.Services.Interfaces;

namespace WardrivingMapper.Components.Pages;

public partial class RawDataPage : ComponentBase
{
    [Inject] public IRawDataService RawDataService { get; set; } = null!;

    private PaginatedList<RawData>? _rawData;

    protected override async Task OnInitializedAsync()
    {
        _rawData = await RawDataService.GetRawDataAsync(pageNumber: 1, pageSize: 15);

    }

    private async Task PageChanged(int newPageNumber)
    {
        _rawData = await RawDataService.GetRawDataAsync(pageNumber: newPageNumber, pageSize: 15);
        // Handle page change logic here
    }

}
