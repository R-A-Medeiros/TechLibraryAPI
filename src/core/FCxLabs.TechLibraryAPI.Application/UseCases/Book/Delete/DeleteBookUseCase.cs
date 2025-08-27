using FCxLabs.TechLibraryAPI.Domain.Repositories;
using FCxLabs.TechLibraryAPI.Domain.Services.LoggedUser;
using FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Book.Delete;

public class DeleteBookUseCase : IDeleteBookUseCase
{
    private readonly IBookRepository _repository;
    private readonly IBookReadOnlyRepository _readonlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogActionRepository _log;
    private readonly ILoggedUser _loggedUser;

    public DeleteBookUseCase(IBookRepository repository, IUnitOfWork unitOfWork, IBookReadOnlyRepository readonlyRepository, ILogActionRepository log, ILoggedUser loggedUser)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _readonlyRepository = readonlyRepository;
        _log = log;
        _loggedUser = loggedUser;
    }
    public async Task Execute(int id)
    {
        var book = await _readonlyRepository.GetById(id);
        var loggedUser = await _loggedUser.Get();

        if (book is null)
        {
           throw new NotFoundException("Book not found.");
        }

         _repository.Delete(book);
        await _log.Add(new Domain.Entities.LogAction
        {
            Entity = "Book",
            Action = "Delete",
            EntityId = book.Id,
            UserId = loggedUser.Id,
            Payload = $"Name={book.Title}"
        });

        await _unitOfWork.Commit();
    }
}
