namespace OloLabs.Promotions.SDK.Responses
{
    /// <summary>
    /// Returned for all error responses. For 400 Bad Request responses that require an error code, see <see cref="ErrorCodeResponse"/>.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// A unique identifier for the error in the provider's system.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Additional details used to help troubleshoot the error.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// An error message to be shown to the customer.
        /// </summary>
        public string Message { get; set; }
    }
}