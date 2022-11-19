namespace mvc_project_dotnet.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
        void Add(Book p);
        Task AddAsync(Book p);
        Task UpdateAsync(Book p);
        Task Delete(Book p);
        void Save(Book p);
        Task SaveAsync(Book p);
    }
}