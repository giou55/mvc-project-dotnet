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

        public void Add(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }
        public async Task AddAsync(Book b)
        {
            context.Add(b);
            await context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Book b)
        {
            context.Update(b);
            await context.SaveChangesAsync();
        }
        public async Task Delete(Book b)
        {
            context.Remove(b);
            await context.SaveChangesAsync();
        }

        public void Save(Book b)
        {
            context.SaveChanges();
        }
        public async Task SaveAsync(Book b)
        {
            await context.SaveChangesAsync();
        }
    }
}

