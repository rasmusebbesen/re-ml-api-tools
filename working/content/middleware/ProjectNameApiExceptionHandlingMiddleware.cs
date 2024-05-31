namespace ProjectName.Api.Middleware;

using Microsoft.AspNetCore.Http;
using Exceptions;
using Middleware.Helpers;
using System.Net;
using Newtonsoft.Json;

public class ProjectNameApiExceptionHandlingMiddleware(RequestDelegate next, bool isDev)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ProjectNameBaseApiException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, ProjectNameBaseApiException exception)
    {
        ApiError result = null!;
        var code = HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        switch (exception)
        {
            case ProjectNameUnauthorizedAccessApiException unauthorizedAccessException:
                result = new ApiError("Unauthorized", unauthorizedAccessException.Message);
                code = ProjectNameUnauthorizedAccessApiException.StatusCode;
                break;

            case ProjectNameNotFoundApiException notFoundException:
                result = new ApiError("Not Found", notFoundException.Message);
                code = ProjectNameNotFoundApiException.StatusCode;
                break;

            case not null:
                result = isDev
                    ? new ApiError("Internal Server Error", exception.ToString())
                    : new ApiError("System Error", "Please try again later or contact to system administrator.");
                code = System.Net.HttpStatusCode.InternalServerError;
                break;
        }

        var errorResponse = new ApiErrorResponse
        {
            Error = new ApiErrorResponse.ApiError
            {
                LocalizedMessage = null,
                LocalizedTitle = null,
                Message = exception?.Message ?? "Error with no message",
                IsRecoverable = false,
                Identifier = null,
                Source = null
            },
            Payload = new ApiErrorResponse.ApiPayload
            {
                ValidationErrors = []
            },
            Metadata = new ApiErrorResponse.ApiMetaData
            {
                ErrorId = null
            }
        };

        context.Response.StatusCode = (int)code;
        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
    }
}
