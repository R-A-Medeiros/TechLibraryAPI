
using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using FCxLabs.TechLibraryAPI.Domain.Services.LoggedUser;
using FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author.Delete;

public class DeleteAuthorUseCase : IDeleteAuthorUseCase
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IAuthorReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogActionRepository _log;
    private readonly ILoggedUser _loggedUser;

    public DeleteAuthorUseCase(IAuthorRepository authorRepository, IUnitOfWork unitOfWork, IAuthorReadOnlyRepository readOnlyRepository, ILogActionRepository log, ILoggedUser loggedUser)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _readOnlyRepository = readOnlyRepository;
        _log = log;
        _loggedUser = loggedUser;
    }
    public async Task Execute(int id)
    {
        var author = await _readOnlyRepository.GetById(id);
        var loggedUser = await _loggedUser.Get();

        if (author is null)
        {
            throw new NotFoundException("Author not found.");
        }

        _authorRepository.Delete(author);
        await _log.Add(new Domain.Entities.LogAction
        {
            Entity = "Author",
            Action = "Delete",
            EntityId = author.Id,
            UserId = loggedUser.Id,
            Payload = $"Name={author.Name}"
        });

        await _unitOfWork.Commit(); 
    }
}
