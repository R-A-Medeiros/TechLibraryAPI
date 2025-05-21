using AutoMapper;
using FCxLabs.TechLibraryAPI.Application.ExceptionsBase;
using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Repositories;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author.Update;

public class UpdateAuthorUseCase : IUpdateAuthorUseCase
{
    private readonly IAuthorUpdateOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateAuthorUseCase(IAuthorUpdateOnlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute(int id, RequestUpdateAuthorJson request)
    {
        var result = await _repository.GetById(id);

        if(result is null)
        {
            throw new NotFoundException("Author not found.");
        }

        _mapper.Map(request, result);
        _repository.Update(result);

        await _unitOfWork.Commit();
    }
}
