using FCxLabs.TechLibraryAPI.Application.ExceptionsBase;
using FCxLabs.TechLibraryAPI.Domain.Repositories;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Book.Delete;

public class DeleteBookUseCase : IDeleteBookUseCase
{
    private readonly IBookRepository _repository;
    private readonly IBookReadOnlyRepository _readonlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBookUseCase(IBookRepository repository, IUnitOfWork unitOfWork, IBookReadOnlyRepository readonlyRepository)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _readonlyRepository = readonlyRepository;
    }
    public async Task Execute(int id)
    {
      

        await _repository.Delete(id);
        await _unitOfWork.Commit();
    }
}
