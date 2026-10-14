using WardrivingMapper.Components;
using MudBlazor.Services;
using WardrivingMapper.Data;
using Microsoft.EntityFrameworkCore;
using WardrivingMapper.Data.Interfaces;
using WardrivingMapper.Data.Repositories;
using WardrivingMapper.Services.Interfaces;
using WardrivingMapper.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
            

builder.Services.AddScoped<Func<AppDbContext?>>(provider => () => provider.GetService<AppDbContext>());

builder.Services.AddScoped<DbFactory>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IRawDataRepository, RawDataRepository>();

builder.Services.AddScoped<IRawDataService, RawDataService>();
builder.Services.AddScoped<ICsvImportService, CsvImportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
