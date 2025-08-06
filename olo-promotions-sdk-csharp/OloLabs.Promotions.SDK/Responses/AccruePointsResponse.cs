using OloLabs.Promotions.SDK.Responses.Models;

namespace OloLabs.Promotions.SDK.Responses
{
    /// <summary>
    /// Returned for a successful call to the Accrue Points endpoint.
    /// </summary>
    public class AccruePointsResponse
    {
        public Transaction Transaction { get; set; }
    }
}