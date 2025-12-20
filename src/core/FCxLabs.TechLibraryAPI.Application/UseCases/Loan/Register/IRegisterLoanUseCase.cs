using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Loan.Register
{
    public interface IRegisterLoanUseCase
    {
        Task<ResponseRegisteredLoanJson> Execute(RequestLoanJson request);
    }
}
