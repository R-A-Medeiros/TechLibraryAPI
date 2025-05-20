using AutoMapper;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using FCxLabs.TechLibraryAPI.Domain.Repositories;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author.GetById;

public class GetByIdAuthorUseCase : IGetByIdAuthorUseCase
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;
    public GetByIdAuthorUseCase(IAuthorRepository repository, IMapper mapper)
    {
       _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseAuthorJson> Execute(int id)
    {
        var author = await _repository.GetById(id);

        if (author is null)
        {
            throw new KeyNotFoundException("$\"Author with ID {id} not found.");
        }

        return _mapper.Map<ResponseAuthorJson>(author);
    }
}
