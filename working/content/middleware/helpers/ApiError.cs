namespace ProjectName.Api.Middleware.Helpers;

using Newtonsoft.Json;

public class ApiError(string title, string detail)
{

    /// <example>Type of error</example>
    [JsonProperty(Order = 1)]
    public string Title { get; set; } = title;

    /// <example>Details about the error</example>
    [JsonProperty(Order = 2)]
    public string Detail { get; set; } = detail;
}
