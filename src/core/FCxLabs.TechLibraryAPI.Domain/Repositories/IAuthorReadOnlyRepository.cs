using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Domain.Repositories;

public interface IAuthorReadOnlyRepository
{
    Task<Author?> GetById(int id);
}
