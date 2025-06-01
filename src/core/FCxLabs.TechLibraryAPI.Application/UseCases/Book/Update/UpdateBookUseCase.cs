using AutoMapper;
using FCxLabs.TechLibraryAPI.Application.ExceptionsBase;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Repositories;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Book.Update;

public class UpdateBookUseCase : IUpdateBookUseCase
{
    private readonly IBookReadOnlyRepository _readOnlyRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBookUseCase(IBookReadOnlyRepository readOnlyRepository, IBookRepository bookRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _readOnlyRepository = readOnlyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute(int id, RequestUpdateBookJson request)
    {
        var book = await _readOnlyRepository.GetById(id);

        if (book is null)
        {
            throw new NotFoundException("Book not found.");
        }

        _mapper.Map(request, book);
        _bookRepository.Update(book);

        await _unitOfWork.Commit();
    }
}
