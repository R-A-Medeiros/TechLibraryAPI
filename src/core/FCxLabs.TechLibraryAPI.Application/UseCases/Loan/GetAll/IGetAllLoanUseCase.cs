using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Loan.GetAll;

public interface IGetAllLoanUseCase
{
    Task<ResponseLoansJson> Execute();
}
