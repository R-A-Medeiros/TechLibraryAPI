namespace FCxLabs.TechLibraryAPI.Domain.Communication.Responses;

public class ResponseeErrorJson
{
    public List<string> ErrorMessages { get; set; }

    public ResponseeErrorJson(string errorMessage)
    {
        ErrorMessages = [errorMessage];
    }

    public ResponseeErrorJson(List<string> errorMessage)
    {
        ErrorMessages = errorMessage;        
    }
}
