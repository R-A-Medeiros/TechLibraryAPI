namespace FCxLabs.TechLibraryAPI.Domain.Security.Tokens;

public interface ITokenProvider
{
    string TokenOnRequest();
}
