using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}
