using AutoMapper;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using FCxLabs.TechLibraryAPI.Domain.Services.LoggedUser;
using FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Book.Register;

public class RegisterBookUseCase : IRegisterBookUseCase
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggedUser _loggedUser;
    private readonly ILogActionRepository _log;

    public RegisterBookUseCase(IBookRepository repository, IMapper mapper, IUnitOfWork unitOfWork, ILoggedUser loggedUser, ILogActionRepository log)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
        _loggedUser = loggedUser;
        _log = log;
    }
    public async Task<ResponseRegisteredBookJson> Execute(RequestBookJson request)
    {
        Validate(request);

        var loggedUser = await _loggedUser.Get();

        var book = _mapper.Map<Domain.Entities.Book>(request);

        await _repository.Add(book);
        await _log.Add(new Domain.Entities.LogAction
        {
            Entity = "Book",
            Action = "Create",
            EntityId = book.Id,
            UserId = loggedUser.Id,
            Payload = $"Name={request.Title}"
        });

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredBookJson>(book);
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
