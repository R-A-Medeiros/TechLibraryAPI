using AutoMapper;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using FCxLabs.TechLibraryAPI.Domain.Repositories;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Author.GetAll;

public class GetAllAuthorUseCase : IGetAllAuthorUseCase
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;

    public GetAllAuthorUseCase(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;   
    }
    public async Task<ResponseAuthorsJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseAuthorsJson
        {
            Authors = _mapper.Map<List<ResponseAuthorJson>>(result)
        };
    }
}
