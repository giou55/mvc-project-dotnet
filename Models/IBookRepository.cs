namespace mvc_project_dotnet.Models
{
    public interface IBookRepository
    {
        List<Book> Books { get; }

        void SaveBook(Book p);
        void CreateBook(Book p);
        void DeleteBook(Book p);
    }
}