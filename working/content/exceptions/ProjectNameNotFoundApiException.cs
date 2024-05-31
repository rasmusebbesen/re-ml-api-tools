namespace ProjectName.Api.Exceptions;

using System.Net;

public class ProjectNameNotFoundApiException : ProjectNameBaseApiException
{
    public new const HttpStatusCode StatusCode = HttpStatusCode.NotFound;

    public ProjectNameNotFoundApiException()
    {
    }

    public ProjectNameNotFoundApiException(string message) : base(message)
    {
    }

    public ProjectNameNotFoundApiException(string message, Exception inner) : base(message, inner)
    {
    }
}
