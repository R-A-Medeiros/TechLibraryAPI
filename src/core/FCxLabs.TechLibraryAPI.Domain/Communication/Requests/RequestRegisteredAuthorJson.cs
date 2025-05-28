using System.ComponentModel.DataAnnotations;

namespace FCxLabs.TechLibraryAPI.Domain.Communication.Requests;

public class RequestRegisteredAuthorJson
{
    [Required]
    [MinLength(5)]
    [MaxLength(255)]
    public string Name { get; set; }
    [Required]
    public DateTime Birth { get; set; }
    public string? Nationality { get; set; }
}
