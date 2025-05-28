using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Book.Register;

public interface IRegisterBookUseCase
{
    Task<ResponseRegisteredBookJson> Execute(RequestRegisteredBookJson request);
}
