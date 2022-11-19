using Microsoft.AspNetCore.Mvc;
using mvc_project_dotnet.Models;

namespace mvc_project_dotnet.Controllers
{
    public class AddBookController : Controller
    {
        private IBookRepository repository;

        public AddBookController(IBookRepository bookRepo)
        {
            repository = bookRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BookForm(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.Add(book);
                return Redirect("~/Book");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
