using Microsoft.AspNetCore.Mvc;
using mvc_project_dotnet.Models;
using System.Collections;

namespace mvc_project_dotnet.Controllers;

public class HomeController : Controller
{
    private IBookRepository repository;

    public IQueryable<Book> Books;

    public HomeController(IBookRepository bookRepo)
    {
        repository = bookRepo;
    }

    //public IActionResult Index()
    //{
    //    return View();
    //}

    public List<Book> Books1 = new List<Book> {
        new Book
        {
            Title = "Pride and Prejudice",
            Description = "It is a truth universally acknowledged that when most people think of " +
                "Jane Austen they think of this charming and humorous story of love, " +
                "difficult families and the tricky task of finding a handsome husband with a good fortune.",
            Author = "Jane Austen",
            Price = (float)28.50,
            CreatedTimestamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
        },
        new Book
        {
            Title = "The Great Gatsby",
            Description = "Jay Gatsby, the enigmatic millionaire who throws decadent parties " +
                "but doesn’t attend them, is one of the great characters of American literature. " +
                "This is F. Scott Fitzgerald at his most sparkling and devastating.",
            Author = "F. Scott Fitzgerald",
            Price = (float)32.50,
            CreatedTimestamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
        }
    };

    public ViewResult Index()
    {
        Books = repository.Books;
        return View(Books);
    }
    public string Index2()
    { 
        return "Hello";
    }
}
