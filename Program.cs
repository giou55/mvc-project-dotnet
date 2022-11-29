using Microsoft.EntityFrameworkCore;
using mvc_project_dotnet.Models;
using mvc_project_dotnet.Middlewares;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using mvc_project_dotnet.Services;
using System.ComponentModel;

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

//this custom middleware checks the Path property of the HttpRequest object to see whether the request is
//for the /short URL; if it is, it calls the WriteAsync method without calling the next function.
app.Use(async (context, next) => {
    if (context.Request.Path == "/short")
    {
        await context.Response.WriteAsync($"Hello from Request Short Circuited");
    }
    else
    {
        await next();
    }
});

//adding a custom class-based middleware from Middlewares folder
app.UseMiddleware<QueryStringMiddleWare>();

app.UseMiddleware<WeatherMiddleware>();

//We use singleton pattern to share a single TextResponseFormatter so it is used by a middleware
//component and an endpoint, with the effect that a single counter is incremented by requests for two
//different URLs
app.MapGet("middleware/function", async (context) => {
    await TextResponseFormatter.Singleton.Format(context,
    "Middleware Function: It is snowing in Chicago");
});
app.MapGet("endpoint/function", async context => {
    await TextResponseFormatter.Singleton.Format(context,
    "Endpoint Function: It is sunny in LA");
});

app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);

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
