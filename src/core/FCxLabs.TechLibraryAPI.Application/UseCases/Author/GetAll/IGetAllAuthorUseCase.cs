using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author.GetAll;

public interface IGetAllAuthorUseCase
{
    Task<ResponseAuthorsJson> Execute();
}
