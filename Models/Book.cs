using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_project_dotnet.Models;

public class Book
{
    public int? BookID { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Author { get; set; }

    [Column(TypeName = "decimal(8, 2)")] 
    public float? Price { get; set; }
    public string? CreatedTimestamp { get; set; }
}
