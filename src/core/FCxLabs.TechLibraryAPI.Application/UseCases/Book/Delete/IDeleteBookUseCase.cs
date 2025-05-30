namespace FCxLabs.TechLibraryAPI.Application.UseCases.Book.Delete;

public interface IDeleteBookUseCase
{
    Task Execute(int id);
}
