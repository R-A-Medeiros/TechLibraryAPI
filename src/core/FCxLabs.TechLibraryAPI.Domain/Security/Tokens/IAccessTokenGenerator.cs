using FCxLabs.TechLibraryAPI.Domain.Entities;

namespace FCxLabs.TechLibraryAPI.Domain.Security.Tokens;

public interface IAccessTokenGenerator
{
    string Generate(User user);
}
