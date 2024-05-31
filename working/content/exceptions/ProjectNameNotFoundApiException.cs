namespace ProjectName.Api.Exceptions;

using System.Net;

public class ProjectNameNotFoundAccessApiException : ProjectNameBaseApiException
{
    public new const HttpStatusCode StatusCode = HttpStatusCode.NotFound;

    public ProjectNameNotFoundAccessApiException()
    {
    }

    public ProjectNameNotFoundAccessApiException(string message) : base(message)
    {
    }

    public ProjectNameNotFoundAccessApiException(string message, Exception inner) : base(message, inner)
    {
    }
}
