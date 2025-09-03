using AutoMapper;
using FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using System.ComponentModel.DataAnnotations;
using FCxLabs.TechLibraryAPI.Domain.Services.LoggedUser;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Book.Update;

public class UpdateBookUseCase : IUpdateBookUseCase
{
    private readonly IBookReadOnlyRepository _readOnlyRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;
    private readonly ILogActionRepository _log;

    public UpdateBookUseCase(IBookReadOnlyRepository readOnlyRepository, IBookRepository bookRepository, IMapper mapper, IUnitOfWork unitOfWork, ILogActionRepository log, ILoggedUser loggedUser)
    {
        _bookRepository = bookRepository;
        _readOnlyRepository = readOnlyRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _log = log;
        _loggedUser = loggedUser;
    }
    public async Task Execute(int id, RequestBookJson request)
    {
        Validate(request);
        var loggedUser = await _loggedUser.Get();

        var book = await _readOnlyRepository.GetById(id);

        if (book is null)
        {
            throw new NotFoundException("Book not found.");
        }

        _mapper.Map(request, book);
        _bookRepository.Update(book);
        await _log.Add(new Domain.Entities.LogAction
        {
            Entity = "Book",
            Action = "Update",
            EntityId = book.Id,
            UserId = loggedUser.Id,
            Payload = $"Name={request.Title}"
        });
        await _unitOfWork.Commit();
    }

    public void Validate(RequestBookJson request)
    {
        var validator = new BookValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }

    }
}
