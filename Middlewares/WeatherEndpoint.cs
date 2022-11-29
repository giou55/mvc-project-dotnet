namespace mvc_project_dotnet.Middlewares
{
    public class WeatherEndpoint
    {
        public static async Task Endpoint(HttpContext context)
        {
            await context.Response.WriteAsync("Endpoint Class: It is cloudy in Milan");
        }
    }
}

//an endpoint that produces a similar result to the middleware component in WeatherMiddleware.cs file
