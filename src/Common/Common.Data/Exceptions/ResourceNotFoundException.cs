using System;
using System.Text.Json.Serialization;
using Common.Models;

namespace Common.Data.Exceptions
{
    public class ResourceNotFoundException : LocalizationException
    {
        public ResourceNotFoundException() { }

        public ResourceNotFoundException(string message) 
            : base(message) { }

        public ResourceNotFoundException(string message, Exception inner) 
            : base(message, inner) { }

        [JsonConstructor]
        public ResourceNotFoundException(string message, LocalizationDetails localizationDetails) 
            : base(message, localizationDetails) { }
    }
}
