using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author.Register;

public interface IRegisterAuthorUseCase
{
    Task<ResponseRegisteredAuthorJson> Execute(RequestRegisterAuthorJson request);
}
