namespace FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

public class ResponseRegisteredLoanJson
{
    public long Id { get; set; }
    public DateTime DueDate { get; set; } 
    public string Status { get; set; }

}
