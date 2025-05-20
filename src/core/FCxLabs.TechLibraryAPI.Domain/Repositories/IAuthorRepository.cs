using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Domain.Repositories;

public interface IAuthorRepository
{
    Task Add(Author author);
    Task <List<Author>> GetAll();
    Task<Author?> GetById(int id);
}
