using System;
using Common.Models;

namespace Common.Data.Exceptions;

public abstract class LocalizationException : ApplicationException
{
    public LocalizationDetails LocalizationDetails { get; set; }
    
    public LocalizationException()
        : this(string.Empty, string.Empty){ }

    public LocalizationException(string message) 
        : this(message, string.Empty) { }

    public LocalizationException(string message, Exception innerException) 
        : this(message, string.Empty, innerException) { }

    public LocalizationException(string message, string errorCode) 
        : this(message, new LocalizationDetails(errorCode)) { }
    
    public LocalizationException(string message, string errorCode, object errorDetails) 
        : this(message, new LocalizationDetails(errorCode, errorDetails)) { }
    
    public LocalizationException(string message, string errorCode, Exception innerException) 
        : this(message, new LocalizationDetails(errorCode), innerException) { }
    
    public LocalizationException(string message, string errorCode, object errorDetails, Exception innerException) 
        : this(message, new LocalizationDetails(errorCode, errorDetails), innerException) { }
    
    public LocalizationException(string message, LocalizationDetails localizationDetails) 
        : base(message)
    {
        LocalizationDetails = localizationDetails;
    }
    public LocalizationException(string message, LocalizationDetails localizationDetails, Exception innerException) 
        : base(message, innerException)
    {
        LocalizationDetails = localizationDetails;
    }
    
    public virtual object ToResponse()
    {
        return new
        {
            Message,
            LocalizationDetails
        };
    }
}