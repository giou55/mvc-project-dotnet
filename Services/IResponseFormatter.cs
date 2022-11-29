namespace mvc_project_dotnet.Services
{
    public interface IResponseFormatter
    {
        Task Format(HttpContext context, string content);
    }
}
