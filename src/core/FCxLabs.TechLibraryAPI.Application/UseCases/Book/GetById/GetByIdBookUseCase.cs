using AutoMapper;
using FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;
using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;
using FCxLabs.TechLibraryAPI.Domain.Repositories;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Book.GetById;

public class GetByIdBookUseCase : IGetByIdBookUseCase
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;

    public GetByIdBookUseCase(IBookRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<ResponseBookJson> Execute(int id)
    {
        var book = await _repository.GetById(id);

        if (book is null)
        {
            throw new NotFoundException($"Book with ID {id} not found.");
        }

        return _mapper.Map<ResponseBookJson>(book);
    }
}
