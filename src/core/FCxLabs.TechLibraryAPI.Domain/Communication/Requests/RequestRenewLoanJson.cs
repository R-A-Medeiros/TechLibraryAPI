using FCxLabs.TechLibraryAPI.Domain.Enums;

namespace FCxLabs.TechLibraryAPI.Domain.Communication.Requests
{
    public class RequestRenewLoanJson
    {
        public int ExtraDays { get; set; } = LoanTerm.STARNDARD;
    }
}
