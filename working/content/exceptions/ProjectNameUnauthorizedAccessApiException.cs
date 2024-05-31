namespace ProjectName.Api.Exceptions;

using System.Net;

public class ProjectNameUnauthorizedAccessApiException : ProjectNameBaseApiException
{
    public new const HttpStatusCode StatusCode = HttpStatusCode.Unauthorized;

    public ProjectNameUnauthorizedAccessApiException()
    {
    }

    public ProjectNameUnauthorizedAccessApiException(string message) : base(message)
    {
    }

    public ProjectNameUnauthorizedAccessApiException(string message, Exception inner) : base(message, inner)
    {
    }
}
