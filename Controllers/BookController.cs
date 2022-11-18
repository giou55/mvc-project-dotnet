using Microsoft.AspNetCore.Mvc;
using mvc_project_dotnet.Models;

namespace mvc_project_dotnet.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository repository;

        public IQueryable<Book> Books;

        public BookController(IBookRepository bookRepo)
        {
            repository = bookRepo;
        }
        public ViewResult Index()
        {
            Books = repository.Books;
            return View(Books);
        }
    }
}
