using AutoMapper;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using FCxLabs.TechLibraryAPI.Domain.Services.LoggedUser;
using FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author.Register;

public class RegisterAuthorUseCase : IRegisterAuthorUseCase
{
    private readonly IAuthorRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogActionRepository _log;
    private readonly ILoggedUser _loggedUser;
    public RegisterAuthorUseCase(IAuthorRepository repository, IUnitOfWork unitOfWork, IMapper mapper, ILogActionRepository log, ILoggedUser loggedUser)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _log = log;
        _loggedUser = loggedUser;
    }
    public async Task<ResponseRegisteredAuthorJson> Execute(RequestAuthorJson request)
    {
        Validate(request);

        var loggedUser = await _loggedUser.Get();

        var author = _mapper.Map<Domain.Entities.Author>(request);

        await _repository.Add(author);

        await _log.Add(new Domain.Entities.LogAction
        {
            Entity = "Author",
            Action = "Create",
            EntityId = author.Id,
            UserId = loggedUser.Id,
            Payload = $"Name={request.Name}"
        });

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredAuthorJson>(author);

    }
    public void Validate(RequestAuthorJson request)
    {
        var validator = new AuthorValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }

    }
}
