using System.ComponentModel.DataAnnotations;

namespace FCxLabs.TechLibraryAPI.Domain.Communication.Requests;

public class RequestUpdateBookJson
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateOnly PublicationYear { get; set; }
}
