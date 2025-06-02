using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Book.Update
{
    public interface IUpdateBookUseCase
    {
        Task Execute(int id, RequestBookJson request);
    }
}
