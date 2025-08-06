using OloLabs.Promotions.SDK.Responses.Models.Errors;

namespace OloLabs.Promotions.SDK.Responses
{
    /// <summary>
    /// Returned for 400 Bad Request responses that require a "code" to specify the error reason.
    /// </summary>
    public class ErrorCodeResponse : ErrorResponse
    {
        /// <summary>
        /// A machine-readable code used to identify the issue with the request. See <see cref="ErrorCode"/> for possible values.
        /// </summary>
        public string Code { get; set; }
    }
}