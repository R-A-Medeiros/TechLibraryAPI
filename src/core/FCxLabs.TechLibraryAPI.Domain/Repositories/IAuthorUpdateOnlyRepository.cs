using FCxLabs.TechLibraryAPI.Domain.Communication.Requests;
using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Domain.Repositories;

public interface IAuthorUpdateOnlyRepository
{
    void Update(Author author);
    // Quando finalizar os endpoint do livro voltar para adicionar o metodo include.
    Task<Author?> GetById(int id);
}
