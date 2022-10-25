using Microsoft.AspNetCore.Mvc;
using mvc_project_dotnet.Models;

namespace mvc_project_dotnet.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult MessageForm(Message message)
    {
        if (ModelState.IsValid)
        {
            MessagesRepository.AddMessage(message);
            return View("ThankYou", message);
        } else
        {
            return View("Index");
        }
    }
}
