namespace FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

public class ResponseLoanJson
{
    public DateTime ReturnedAt { get; set; } = DateTime.UtcNow;
}
