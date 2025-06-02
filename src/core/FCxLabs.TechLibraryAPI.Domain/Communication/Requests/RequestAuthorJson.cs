using System.ComponentModel.DataAnnotations;

namespace FCxLabs.TechLibraryAPI.Domain.Communication.Requests;

public class RequestAuthorJson
{
    public string Name { get; set; }
    public DateTime Birth { get; set; }
    public string? Nationality { get; set; }
}
