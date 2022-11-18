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
    }
}
