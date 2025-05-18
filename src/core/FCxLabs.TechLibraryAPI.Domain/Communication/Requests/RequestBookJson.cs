using System.ComponentModel.DataAnnotations;

namespace FCxLabs.TechLibraryAPI.Domain.Communication.Requests;

public class RequestBookJson
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Genre { get; set; }
    [Required]
    public int PublicationYear { get; set; }
    [Required]
    public int AuthorId { get; set; }
}
