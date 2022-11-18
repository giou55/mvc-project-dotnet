using Microsoft.AspNetCore.Mvc;

namespace mvc_project_dotnet.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
