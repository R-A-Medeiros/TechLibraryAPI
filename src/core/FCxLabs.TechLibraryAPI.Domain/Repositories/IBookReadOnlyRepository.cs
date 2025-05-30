using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Domain.Repositories;

public interface IBookReadOnlyRepository
{
    Task<Book?> GetById(int Id);
}
