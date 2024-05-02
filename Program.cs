//Blazor WebAssembly hosting model:

//var builder = WebAssemblyHostBuilder.CreateDefault(args);

//Blazor Server hosting model:

//var builder = WebApplication.CreateBuilder(args);
//// Add services to the container.
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();

//This is a Blazor project based on Blazor Server hosting Model.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();