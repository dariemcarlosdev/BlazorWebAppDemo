//Blazor WebAssembly hosting model:

//var builder = WebAssemblyHostBuilder.CreateDefault(args);

//Blazor Server hosting model:

//var builder = WebApplication.CreateBuilder(args);
//// Add services to the container.
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();

//This is a Blazor project based on Blazor Server hosting Model.
using BlazingPizza.DAL;
using BlazingPizza.Services;
using Microsoft.AspNetCore.Builder;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//AddHttpClient service allows the app to access HTTP commands.The app uses an HttpClient to get the JSON for pizza specials.
builder.Services.AddHttpClient();
//AddSqlite service registers the new PizzaStoreContext and provides the filename for the SQLite database
builder.Services.AddSqlite<PizzaStoreDemoContext>("Data Source=pizza.db");

// Registering AppState class as scoped Service.
builder.Services.AddScoped<PizzaSaleState>();

builder.Services.AddScoped<PizzaOrderStateService>();

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
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

//Initialize the database: This change creates a database scope with the PizzaStoreContext. If there isn't a database already created, it calls the SeedData static class to create one.
/*
It retrieves the IServiceScopeFactory from the application’s services, which is used to create a new scope for retrieving services.

It creates a new scope using scopeFactory.CreateScope(). This is necessary because some services, like DbContext, have a scoped lifetime and need to be retrieved within a specific scope.

Within this scope, it retrieves an instance of PizzaStoreContext from the service provider. PizzaStoreContext is presumably a DbContext used for interacting with a database.

It checks if the database has been created using db.Database.EnsureCreated().If the database doesn’t exist, it will be created.

If the database was just created, it calls SeedData.Initialize(db) to seed the database with initial data.

Finally, it runs the application with app.Run().

*/

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PizzaStoreDemoContext>();
    if (dbContext.Database.EnsureCreated())
    {
        PizzaSpecialDataSeed.OnInitialize(dbContext);
    }
}

app.Run();