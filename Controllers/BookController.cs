using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_project_dotnet.Models;
using mvc_project_dotnet.Models.ViewModels;
using System.Text.Json;

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

        //this method uses the id parameter, from the routing pattern
        //in Program.cs file, to query the database
        public async Task<IActionResult> Details(long id)
        {
            Book? b = await repository.Books
                .FirstOrDefaultAsync(b => b.BookID == id) ?? new Book();
            //the ViewModelFactory.Details method to create a ProductViewModel object
            //and display it to the user with the BookEditor view
            BookViewModel model = ViewModelFactory.Details(b);
            return View("BookEditor", model);
        }

        public IActionResult Add()
        {
            return View("BookEditor",
                ViewModelFactory.Create(new Book()));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Book book)
        {
            if (ModelState.IsValid)
            {
                book.BookID = default;
                await repository.AddAsync(book);
                return RedirectToAction(nameof(Index));
            }
            return View("BookEditor", ViewModelFactory.Create(book));
        }

        public async Task<IActionResult> Edit(long id)
        {
            Book? b = await repository.Books
                .FirstOrDefaultAsync(b => b.BookID == id) ?? new Book();
            if (b != null)
            {
                BookViewModel model = ViewModelFactory.Edit(b);
                return View("BookEditor", model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Book book)
        {
            if (ModelState.IsValid)
            {
                await repository.UpdateAsync(book);
                return RedirectToAction(nameof(Index));
            }
            return View("BookEditor", ViewModelFactory.Edit(book));
        }

        public async Task<IActionResult> Delete(long id)
        {
            Book? b = await repository.Books
                .FirstOrDefaultAsync(b => b.BookID == id) ?? new Book();
            if (b != null)
            {
                BookViewModel model = ViewModelFactory.Delete(b);
                return View("BookEditor", model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Book book)
        {
            await repository.Delete(book);
            return RedirectToAction(nameof(Index));
        }
    }
}
