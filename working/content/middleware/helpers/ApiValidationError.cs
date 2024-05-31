namespace ProjectName.Api.Middleware.Helpers;

using Newtonsoft.Json;
using FluentValidation.Results;

public class ApiValidationError : ApiError
{
    public ApiValidationError(string errorDetail, IEnumerable<ValidationFailure> failures) : base("Validation Failed", errorDetail)
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(
                failureGroup => failureGroup.Key,
                failureGroup => failureGroup.ToArray());
    }

    public ApiValidationError(string title, string errorDetail) : base(title, errorDetail)
    {
        Errors = new Dictionary<string, string[]>();
    }

    /// <example>{"Name": ["'Name' must not be empty."]}</example>
    [JsonProperty(Order = 3)]
    public IDictionary<string, string[]> Errors { get; set; }
}
