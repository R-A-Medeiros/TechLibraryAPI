using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author.Update
{
    public interface IUpdateAuthorUseCase
    {
        Task Execute(int id, RequestUpdateAuthorJson request);
    }
}
