using AutoMapper;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using FCxLabs.TechLibraryAPI.Domain.Repositories;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author.Register;

public class RegisterAuthorUseCase : IRegisterAuthorUseCase
{
    private readonly IAuthorRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RegisterAuthorUseCase(IAuthorRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseRegisteredAuthorJson> Execute(RequestRegisteredAuthorJson request)
    {
        var author = _mapper.Map<Domain.Entities.Author>(request);

        await _repository.Add(author);
        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredAuthorJson>(author);

    }
}
