using System.Text.Json.Serialization;

namespace FCxLabs.TechLibraryAPI.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int PublicationYear { get; set; }
    public int AuthorId { get; set; }
    [JsonIgnore]
    public Author Author { get; set; } = default!;
}
