
using FCxLabs.TechLibraryAPI.Domain.Repositories;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author.Delete;

public class DeleteAuthorUseCase : IDeleteAuthorUseCase
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAuthorUseCase(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute(int id)
    {
        await _authorRepository.Delete(id);
        await _unitOfWork.Commit(); 
    }
}
