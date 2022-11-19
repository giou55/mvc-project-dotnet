using mvc_project_dotnet.Models.ViewModels;

namespace mvc_project_dotnet.Models
{
    public class ViewModelFactory
    {
        public static BookViewModel Details(Book p)
        {
            return new BookViewModel
            {
                Book = p,
                Action = "Details",
                ReadOnly = true,
                Theme = "info",
                ShowAction = false
            };
        }

        public static BookViewModel Create(Book b)
        {
            return new BookViewModel
            {
                Book = b
            };
        }

        public static BookViewModel Edit(Book b)
        {
            return new BookViewModel
            {
                Book = b,
                Theme = "warning",
                Action = "Edit"
            };
        }

        public static BookViewModel Delete(Book p)
        {
            return new BookViewModel
            {
                Book = p,
                Action = "Delete",
                ReadOnly = true,
                Theme = "danger"
            };
        }
    }
}
