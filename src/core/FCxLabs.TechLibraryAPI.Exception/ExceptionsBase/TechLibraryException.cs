namespace FCxLabs.TechLibraryAPI.Exception.ExceptionsBase;

public abstract class TechLibraryException : SystemException
{
    protected TechLibraryException(string message) : base(message)
    {
        
    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
