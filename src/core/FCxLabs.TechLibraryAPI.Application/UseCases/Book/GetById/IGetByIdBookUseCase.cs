using FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

namespace FCxLabs.TechLibraryAPI.Application.UseCases.Book.GetById;

public interface IGetByIdBookUseCase
{
    Task<ResponseBookJson> Execute(int id); 
}
