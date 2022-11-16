using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using mvc_project_dotnet.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//The app registers the IBookRepository service with the type BookRepository.
//The AddScoped method registers the service with a scoped lifetime, the lifetime of
//a single request.
builder.Services.AddScoped<IBookRepository, BookRepository>();

//Entity Framework Core must be configured so that it knows
//the type of database to which it will connect,
//which connection string describes that connection,
//and which context class will present the data in the database.
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
