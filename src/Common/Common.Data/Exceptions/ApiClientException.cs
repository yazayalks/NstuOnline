using System;
using System.Net;

namespace Common.Data.Exceptions
{
    public class ApiClientException : Exception
    {
        public object Content { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }

        public ApiClientException(object content, HttpStatusCode httpStatusCode)
        {
            Content = content;
            HttpStatusCode = httpStatusCode;
        }
    }
}
