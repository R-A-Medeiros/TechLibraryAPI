using System.ComponentModel.DataAnnotations;

namespace FCxLabs.TechLibraryAPI.Domain.Communication.Requests;

public class RequestBookJson
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int PublicationYear { get; set; }
    public int AuthorId { get; set; }
}
