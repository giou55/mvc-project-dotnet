using Microsoft.EntityFrameworkCore;

namespace mvc_project_dotnet.Models;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options) { }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Author => Set<Author>();
    //public DbSet<Âïïê> Books { get; set; }
}
