using Microsoft.EntityFrameworkCore;
using mvc_project_dotnet.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<MyDbContext>(
    options => options.UseSqlServer(
        builder.Configuration["ConnectionStrings:MyAppConnection"])
);

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapGet("/", () => "Hello World!");
//app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
