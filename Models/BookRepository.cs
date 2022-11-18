namespace mvc_project_dotnet.Models
{
    public class BookRepository : IBookRepository
    {
        private MyDbContext context;

        public BookRepository(MyDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Book> Books => context.Books;

        public void AddBook(Book b)
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

