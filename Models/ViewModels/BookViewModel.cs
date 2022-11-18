namespace mvc_project_dotnet.Models.ViewModels
{
    //This class will allow the controller to pass data and display settings to its view.
    public class BookViewModel
    {
        //The Book property provides the data to display
        public Book Book { get; set; } = new Book();

        //The other properties configure aspects of how the content is presented to the user
        public string Action { get; set; } = "Add";
        public bool ReadOnly { get; set; } = false;
        public string Theme { get; set; } = "primary";
        public bool ShowAction { get; set; } = true;
    }
}
