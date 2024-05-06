using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.EmployeeManager.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// DbContext :
string connectionString = "Server=localhost;Database=EmployeeMangerDb;User Id=SA;Password=B5uf1g8p29;Encrypt=True;TrustServerCertificate=True;";
builder.Services.AddDbContext<EmployeeManagerDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeManagerDb")));

var app = builder.Build();

// REMEMBER : this is how to automatically check for the latest migration when the app start
await EnsureDatabaseIsMigrated(app.Services);

async Task EnsureDatabaseIsMigrated(IServiceProvider services)
{
    using var scope = services.CreateScope();
    using var ctx = scope.ServiceProvider.GetService<EmployeeManagerDbContext>();

    if (ctx is not null)
    {
        await ctx.Database.MigrateAsync();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();