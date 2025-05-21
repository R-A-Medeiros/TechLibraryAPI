using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Domain.Repositories;

public interface IAuthorRepository
{
    Task Add(Author author);
    Task <List<Author>> GetAll();
    // Quando finalizar os endpoint do livro voltar para adicionar o metodo include.
    Task<Author?> GetById(int id);
    Task Delete(int id);
}
