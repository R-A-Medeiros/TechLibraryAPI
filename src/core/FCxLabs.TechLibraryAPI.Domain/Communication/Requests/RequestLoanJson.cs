using FCxLabs.TechLibraryAPI.Domain.Enums;

namespace FCxLabs.TechLibraryAPI.Domain.Communication.Requests;

public class RequestLoanJson
{
    public int BookId { get; set; }
    public int Days { get; set; } = LoanTerm.STARNDARD;
}
