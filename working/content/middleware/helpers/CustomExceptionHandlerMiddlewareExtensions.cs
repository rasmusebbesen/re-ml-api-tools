namespace ProjectName.Api.Middleware.Helpers;

public static class CustomExceptionHandlerMiddlewareExtensions
{
    public static void UseCustomExceptionHandler(this IApplicationBuilder builder, bool isDev)
    {
        builder.UseMiddleware<ProjectNameApiExceptionHandlingMiddleware>(isDev);
    }
}
