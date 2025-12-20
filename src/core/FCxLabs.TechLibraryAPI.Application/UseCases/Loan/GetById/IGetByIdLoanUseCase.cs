using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Loan.GetById;

public interface IGetByIdLoanUseCase
{
    Task<ResponseLoanJson> Execute(int id);
}
