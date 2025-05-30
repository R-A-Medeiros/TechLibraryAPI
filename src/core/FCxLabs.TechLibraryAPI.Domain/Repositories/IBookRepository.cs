using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Domain.Repositories;

public interface IBookRepository
{
    Task Add(Book book);
    Task<List<Book>> GetAll();
    Task<Book?> GetById(int id);
    Task Delete(int id);
}
