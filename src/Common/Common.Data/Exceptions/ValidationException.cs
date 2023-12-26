using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Common.Models;

namespace Common.Data.Exceptions
{
    public class ValidationException : LocalizationException
    {
        public string[] Messages { get; set; }
        public IEnumerable<ValidationFailure> Errors { get; set; }


        #region ConstructorsWithoutErrorCode

        public ValidationException(string message) 
            : this(message, string.Empty) { }

        public ValidationException(string[] messages) 
            : this(messages, string.Empty) { }

        public ValidationException(IEnumerable<ValidationFailure> errors) 
            : this(errors, string.Empty) { }

        public ValidationException(string message, IEnumerable<ValidationFailure> errors) 
            : this(message, errors, string.Empty) { }

        #endregion


        #region ConstructorsWithErrorCode

        public ValidationException(string message, string errorCode) 
            : this(new[] { message }, errorCode) { }

        public ValidationException(string[] messages, string errorCode) 
            : this(messages, Enumerable.Empty<ValidationFailure>(), new LocalizationDetails(errorCode)) { }

        public ValidationException(IEnumerable<ValidationFailure> errors, string errorCode) 
            : this(Array.Empty<string>(), errors, new LocalizationDetails(errorCode)) { }

        public ValidationException(string message, IEnumerable<ValidationFailure> errors, string errorCode) 
            : this(new[] { message }, errors, new LocalizationDetails(errorCode)) { }

        #endregion
        
        #region ConstructorsWithErrorCodeAndDetails

        public ValidationException(string message, string errorCode, object errorDetails) 
            : this(new[] { message }, errorCode, errorDetails) { }

        public ValidationException(string[] messages, string errorCode, object errorDetails) 
            : this(messages, Enumerable.Empty<ValidationFailure>(), new LocalizationDetails(errorCode, errorDetails)) { }

        public ValidationException(IEnumerable<ValidationFailure> errors, string errorCode, object errorDetails) 
            : this(Array.Empty<string>(), errors, new LocalizationDetails(errorCode, errorDetails)) { }

        public ValidationException(string message, IEnumerable<ValidationFailure> errors, string errorCode, object errorDetails) 
            : this(new[] { message }, errors, new LocalizationDetails(errorCode, errorDetails)) { }

        #endregion
        
        
        [JsonConstructor]
        public ValidationException(string[] messages, IEnumerable<ValidationFailure> errors, LocalizationDetails localizationDetails) 
            : base(string.Join(' ', messages), localizationDetails)
        {
            Messages = messages;
            Errors = errors;
        }

        public override object ToResponse()
        {
            return new
            {
                Messages,
                Errors,
                LocalizationDetails
            };
        }
    }

    public class ValidationFailure
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }

        public ValidationFailure(string propertyName)
        {
            PropertyName = propertyName;
        }
        
        public ValidationFailure(string propertyName, string errorCode)
        {
            PropertyName = propertyName;
            ErrorCode = errorCode;
        }

        [JsonConstructor]
        public ValidationFailure(string propertyName, string errorMessage, string errorCode)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
        }
    }
}
