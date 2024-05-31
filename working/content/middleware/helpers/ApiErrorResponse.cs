namespace ProjectName.Api.Middleware.Helpers;

using Newtonsoft.Json;

public class ApiErrorResponse
{
    [JsonProperty(Order = 1)]
    public ApiErrorResponse.ApiError Error { get; set; }

    [JsonProperty(Order = 2)]
    public ApiErrorResponse.ApiPayload Payload { get; set; }

    [JsonProperty(Order = 3)]
    public ApiErrorResponse.ApiMetaData Metadata { get; set; }

    public struct ApiError
    {
        // Optional title localized for end user
        public string? LocalizedMessage { get; set; }
        // Optional message localized for end user
        public string? LocalizedTitle { get; set; }
        // Message for developer
        public string Message { get; set; }
        // Is the error handled in the UI is fatal or can it be recovered, eg: try again
        public bool IsRecoverable {get; set; }
        // Identifier which the consumer of the API can parse and switch case on
        public string Identifier { get; set; }
        // In micro services architecture, you might want to understand what service
        public string? Source { get; set; }
    }

    public struct ApiPayload
    {
        public List<ApiErrorResponse.ApiValidationError> ValidationErrors = [];

        public ApiPayload(List<ApiValidationError> validationErrors)
        {
            this.ValidationErrors = validationErrors;
        }
    }

    public struct ApiValidationError
    {
        public string Field { get; set; }
        public List<ApiErrorResponse.ApiValidationFailure> ValidationFailures = [];

        public ApiValidationError(string field, List<ApiValidationFailure> validationFailures)
        {
            this.Field = field;
            this.ValidationFailures = validationFailures;
        }
    }

    public struct ApiValidationFailure
    {
        public string Type { get; set; }
        public string LocalizedMessage {get; set; }
    }

    public struct ApiMetaData
    {
        public string ErrorId { get; set; }
    }
}