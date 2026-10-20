using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using WardrivingMapper.Data.DataModels;
using WardrivingMapper.Services.Interfaces;

namespace WardrivingMapper.Components.Pages;

public partial class MapViewer : ComponentBase
{
    [Inject] public IJSRuntime JSR { get; set; } = null!;
    [Inject] public IRawDataService RawDataService { get; set; } = null!;
    private PaginatedList<RawData> dataTest = new();
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JSR.InvokeVoidAsync("initMap", "map", 48.8566, 2.3522, 13);
    }

    protected async Task FilterResults()
    {
        dataTest = await RawDataService.GetRawDataAsync(1, 50);
    }
}
