using System.Net;

namespace FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;

public class NotFoundException : TechLibraryException
{
    public NotFoundException(string message) : base(message)
    {
        
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
