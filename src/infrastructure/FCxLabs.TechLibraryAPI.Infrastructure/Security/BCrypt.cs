using FCxLabs.TechLibraryAPI.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;
namespace FCxLabs.TechLibraryAPI.Infrastructure.Security;

internal class BCrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        //string passwordHash = BCrypt.HashPassword(password);
        string passwordHash = BC.HashPassword(password);
        return passwordHash;
    }
}

