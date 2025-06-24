using AutoMapper;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using FCxLabs.TechLibraryAPI.Domain.Repositories;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Book.GetAll;

public class GetAllBookUseCase : IGetAllBookUseCase
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;

    public GetAllBookUseCase(IBookRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<ResponseBooksJson> Execute()
    {
        var books = await _repository.GetAll();

        return new ResponseBooksJson
        {
            Books = _mapper.Map<List<ResponseBookJson>>(books)
        };
    }

}
