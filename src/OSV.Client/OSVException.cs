namespace OSV.Client;

using System.Net;

public class OSVException : Exception
{
    public OSVException(string? message)
        : base(message)
    {
    }

    public OSVException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    public OSVException(HttpStatusCode statusCode, string? responseContent, string? message = null)
        : base(message ?? $"HTTP request failed with status code {statusCode}")
    {
        this.StatusCode = statusCode;
        this.ResponseContent = responseContent;
    }

    public OSVException(HttpStatusCode statusCode, string? responseContent, Exception? innerException, string? message = null)
        : base(message ?? $"HTTP request failed with status code {statusCode}", innerException)
    {
        this.StatusCode = statusCode;
        this.ResponseContent = responseContent;
    }

    public HttpStatusCode? StatusCode { get; }

    public string? ResponseContent { get; }
}
