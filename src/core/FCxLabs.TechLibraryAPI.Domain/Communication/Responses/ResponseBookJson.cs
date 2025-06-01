using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

public class ResponseBookJson
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int PublicationYear { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; } = default!;
}
