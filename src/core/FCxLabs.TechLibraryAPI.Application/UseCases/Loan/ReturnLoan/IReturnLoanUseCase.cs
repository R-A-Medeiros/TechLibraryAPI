using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Loan.ReturnLoan;

public interface IReturnLoanUseCase
{
    Task<ResponseLoanJson> Execute(int loanId);
}
