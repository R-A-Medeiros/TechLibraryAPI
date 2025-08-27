using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Domain.Repositories;

public  interface ILogActionRepository
{
    Task Add(LogAction log);
    Task<List<LogAction>> GetAllAsync(int skip = 0, int take = 100); // método para listar logs
}
