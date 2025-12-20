using FCxLabs.TechLibraryAPI.Domain.Enums;

namespace FCxLabs.TechLibraryAPI.Domain.Communication.Requests;

public class RequestLoanJson
{
    public int BookCopyId { get; set; }
    public int loanTermDays { get; set; } = LoanTerm.STARNDARD;
}
