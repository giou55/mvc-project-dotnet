using Microsoft.EntityFrameworkCore;
using mvc_project_dotnet.Models;
using mvc_project_dotnet.Middlewares;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

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

builder.Services.AddDbContext<IdentityContext>(opts =>
    opts.UseSqlServer(builder.Configuration[
        "ConnectionStrings:IdentityConnection"]));

//configure application so the Identity database context is set up as a service
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddRazorPages();

//configure password and user validation rules 
builder.Services.Configure<IdentityOptions>(opts => {
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
    opts.User.RequireUniqueEmail = true;
    opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
});

//The result of the Build method is a WebApplication object, which is used to set up middleware components.
var app = builder.Build();

//adding a custom class-based middleware
app.UseMiddleware<QueryStringMiddleWare>();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

//The UseAuthorization method must be called between the UseRouting and UseEndpoints methods
//and after the UseAuthentication method has been called.
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

//app.MapGet("/", () => "Hello World!");
//app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

IdentitySeedData.CreateAdminAccount(app.Services, app.Configuration);

app.Run();
