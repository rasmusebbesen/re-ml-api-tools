namespace ProjectName.Api.Exceptions;

using System.Net;

public class ProjectNameBaseApiException : Exception
{
    public const HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;

    public ProjectNameBaseApiException()
    {
    }

    public ProjectNameBaseApiException(string message) : base(message)
    {
    }

    public ProjectNameBaseApiException(string message, Exception inner) : base(message, inner)
    {
    }
}
