using System.ComponentModel.DataAnnotations;

namespace FCxLabs.TechLibraryAPI.Domain.Communication.Requests;

public class RequestAuthorJson
{
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime Birth { get; set; }
    public string? Nationality { get; set; }
}
