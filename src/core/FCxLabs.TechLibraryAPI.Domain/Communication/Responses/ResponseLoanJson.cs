using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

public class ResponseLoanJson
{
    public long Id { get; set; }
    public DateTime LoanDate { get; set; }
    public int BookCopyId { get; set; }

    public DateTime DueDate { get; set; }

    public string Status { get; set; }
}
