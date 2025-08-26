using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Domain.Services.LoggedUser;

public interface ILoggedUser
{
    Task<User> Get();
}
