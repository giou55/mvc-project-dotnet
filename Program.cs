using Microsoft.EntityFrameworkCore;
using mvc_project_dotnet.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<MyDbContext>(opts => {
//    opts.UseSqlServer(
//        builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
//});


//var connectionString = "server=linuxzone34.grserver.gr:3306;user=giourmet449939;password=85!Lh65FdqW;database=sportsstore_dotnet";
//var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

//builder.Services.AddDbContext<MyDbContext>(
//    dbContextOptions => dbContextOptions
//        .UseMySql(connectionString, serverVersion)
//);

var connectionString = builder.Configuration.GetConnectionString("SportsStoreConnection");

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
