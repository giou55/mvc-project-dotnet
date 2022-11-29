namespace mvc_project_dotnet.Services
{
    public class TextResponseFormatter : IResponseFormatter
    {
        private int responseCounter = 0;
        private static TextResponseFormatter? shared;
        public async Task Format(HttpContext context, string content)
        {
            await context.Response.
                WriteAsync($"Response {++responseCounter}:\n{content}");
        }

        public static TextResponseFormatter Singleton
        {
            get
            {
                if (shared == null)
                {
                    shared = new TextResponseFormatter();
                }
                return shared;
            }
        }
    }
}

//The TextResponseFormatter class implements the interface and writes the content to the response
//as a simple string with a prefix to make it obvious when the class is used.

//Each TextResponseFormatter object maintains a counter that is included in the response sent to the
//browser

//Here we have a basic implementation of the singleton pattern
//We added a static property to the service class that provides direct access to the shared instance

//We use this service class by a middleware component and an endpoint in Program.cs file
