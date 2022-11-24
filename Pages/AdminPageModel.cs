using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace mvc_project_dotnet.Pages
{
    [Authorize(Roles = "Admins")] //apply the Authorize attribute to the class to create the authorization policy
    public class AdminPageModel : PageModel
    {
    }
}
