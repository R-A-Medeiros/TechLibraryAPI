using AutoMapper;
using FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using FCxLabs.TechLibraryAPI.Application.UseCases.Book;
using FCxLabs.TechLibraryAPI.Domain.Services.LoggedUser;
using FCxLabs.TechLibraryAPI.Domain.Entities;


namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author.Update;

public class UpdateAuthorUseCase : IUpdateAuthorUseCase
{
    private readonly IAuthorUpdateOnlyRepository _repository;
    private readonly IAuthorReadOnlyRepository _repositoryReadOnly;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogActionRepository _log;
    private readonly ILoggedUser _loggedUser;

    public UpdateAuthorUseCase(IAuthorUpdateOnlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IAuthorReadOnlyRepository repositoryReadOnly, ILogActionRepository log, ILoggedUser loggedUser)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
        _repositoryReadOnly = repositoryReadOnly;
        _log = log;
        _loggedUser = loggedUser;
    }
    public async Task Execute(int id, RequestAuthorJson request)
    {
        Validate(request);

        var loggedUser = await _loggedUser.Get();

        var result = await _repositoryReadOnly.GetById(id);

        if(result is null)
        {
            throw new NotFoundException("Author not found.");
        }

        _mapper.Map(request, result);
        _repository.Update(result);

        await _log.Add(new Domain.Entities.LogAction
        {
            Entity = "Author",
            Action = "Update",
            EntityId = result.Id,
            UserId = loggedUser.Id,
            Payload = $"Name={request.Name}"
        });

        await _unitOfWork.Commit();
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
