namespace Common.Models;

public class LocalizationDetails
{
    public string ErrorCode { get; set; }

    public string Namespace { get; set; }
    
    public object ErrorDetails { get; set; }

    public LocalizationDetails()
    {
    }

    public LocalizationDetails(string errorCode)
    {
        ErrorCode = errorCode;
    }
    
    public LocalizationDetails(string errorCode, object errorDetails)
    {
        ErrorCode = errorCode;
        ErrorDetails = errorDetails;
    }
}