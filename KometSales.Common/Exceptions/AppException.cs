using System.Net;

namespace KometSales.Common.Exceptions
{
    public class AppException : Exception
    {
        public AppException(HttpStatusCode statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }
    }
}
