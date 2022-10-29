﻿namespace mvc_project_dotnet.Models
{
    public class BooksRepository : IBookRepository
    {
        private MyDbContext context;

        public BooksRepository(MyDbContext ctx)
        {
            context = ctx;
        }

        public List<Book> Books => context.Books;

        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBook(Book b)
        {
            context.Remove(b);
            context.SaveChanges();
        }

        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }
    }
}

