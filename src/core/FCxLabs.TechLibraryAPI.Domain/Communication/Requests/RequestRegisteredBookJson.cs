using System.ComponentModel.DataAnnotations;

namespace FCxLabs.TechLibraryAPI.Domain.Communication.Requests;

public class RequestRegisteredBookJson
{
    [Required]
    [MinLength(5)]
    [MaxLength(255)]  
    public string Title { get; set; }
    [Required]
    [MinLength(5)]
    [MaxLength(255)]
    public string Genre { get; set; }
    [Required]
    public int PublicationYear { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    public int AuthorId { get; set; }
}
