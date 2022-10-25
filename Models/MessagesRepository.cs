using mvc_project_dotnet.Models;

namespace mvc_project_dotnet.Models
{
    public static class MessagesRepository
    {
/*        private static List<Message> messages = new List<Message>()
        {
            { "Michael", "fffff@fg", "Hello George dfgsdfsdf ggggggggggggg" },
            { "Peter", "rrrrrr@fg", "Hello George dfgsdfsdf mmmmmmmmmmmmmmm" },
            { "Carla", "qqqqqqq@fg", "Hello George dfgsdfsdf sssssssssssss" },
            { "Maria", "mmmmmm@fg", "Hello George dfgsdfsdf aaaaaaaaaaaaa" }
        };*/

        private static List<Message> messages = new();

        public static IEnumerable<Message> Messages => messages;

        public static void AddMessage(Message msg)
        {
            messages.Add(msg);
        }
    }
}
