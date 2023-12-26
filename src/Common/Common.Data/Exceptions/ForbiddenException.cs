using System;
using System.Text.Json.Serialization;
using Common.Models;

namespace Common.Data.Exceptions
{
    public class ForbiddenException : LocalizationException
    {
        public ForbiddenException() { }

        public ForbiddenException(string message) 
            : base(message) { }

        public ForbiddenException(string message, Exception innerException) 
            : base(message, innerException) { }

        [JsonConstructor]
        public ForbiddenException(string message, LocalizationDetails localizationDetails) 
            : base(message, localizationDetails) { }
    }
}
