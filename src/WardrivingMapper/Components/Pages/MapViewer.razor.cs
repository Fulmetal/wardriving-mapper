using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace WardrivingMapper.Components.Pages;

public partial class MapViewer : ComponentBase
{
    [Inject] public IJSRuntime JSR { get; set; } = null!;
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JSR.InvokeVoidAsync("initMap", "map", 48.8566, 2.3522, 13);
    }
}
