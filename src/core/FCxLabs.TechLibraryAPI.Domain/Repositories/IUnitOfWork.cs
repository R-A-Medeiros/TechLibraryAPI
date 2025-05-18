namespace FCxLabs.TechLibraryAPI.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}
