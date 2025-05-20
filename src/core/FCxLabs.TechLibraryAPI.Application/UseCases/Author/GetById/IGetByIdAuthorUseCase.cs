using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author.GetById;

public interface IGetByIdAuthorUseCase
{
    Task<ResponseAuthorJson> Execute(int id);
}
