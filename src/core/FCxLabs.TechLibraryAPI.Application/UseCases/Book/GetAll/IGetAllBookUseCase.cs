using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Book.GetAll;

public interface IGetAllBookUseCase
{
    Task<ResponseBooksJson> Execute();
}
