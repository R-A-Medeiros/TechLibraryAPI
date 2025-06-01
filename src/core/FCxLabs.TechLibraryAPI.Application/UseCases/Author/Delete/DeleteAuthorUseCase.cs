
using FCxLabs.TechLibraryAPI.Application.ExceptionsBase;
using FCxLabs.TechLibraryAPI.Domain.Repositories;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author.Delete;

public class DeleteAuthorUseCase : IDeleteAuthorUseCase
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IAuthorReadOnlyRepository _readOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAuthorUseCase(IAuthorRepository authorRepository, IUnitOfWork unitOfWork, IAuthorReadOnlyRepository readOnlyRepository)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
        _readOnlyRepository = readOnlyRepository;
    }
    public async Task Execute(int id)
    {
        var author = await _readOnlyRepository.GetById(id);

        if (author is null)
        {
            throw new NotFoundException("Author not found.");
        }

        _authorRepository.Delete(author);
        await _unitOfWork.Commit(); 
    }
}
