using Microsoft.AspNetCore.Mvc;
using mvc_project_dotnet.Models;

namespace mvc_project_dotnet.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
