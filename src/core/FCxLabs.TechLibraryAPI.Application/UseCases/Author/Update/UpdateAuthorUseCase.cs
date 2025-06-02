using AutoMapper;
using FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Repositories;
using FCxLabs.TechLibraryAPI.Application.UseCases.Book;


namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author.Update;

public class UpdateAuthorUseCase : IUpdateAuthorUseCase
{
    private readonly IAuthorUpdateOnlyRepository _repository;
    private readonly IAuthorReadOnlyRepository _repositoryReadOnly;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateAuthorUseCase(IAuthorUpdateOnlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IAuthorReadOnlyRepository repositoryReadOnly)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
        _repositoryReadOnly = repositoryReadOnly;
    }
    public async Task Execute(int id, RequestAuthorJson request)
    {
        Validate(request);

        var result = await _repositoryReadOnly.GetById(id);

        if(result is null)
        {
            throw new NotFoundException("Author not found.");
        }

        _mapper.Map(request, result);
        _repository.Update(result);

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
