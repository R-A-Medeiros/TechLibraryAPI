
using System.Net;

namespace FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;

public class InvalidLoginException : TechLibraryException
{
    public InvalidLoginException() : base("Email or password invalid.")
    {
    }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
