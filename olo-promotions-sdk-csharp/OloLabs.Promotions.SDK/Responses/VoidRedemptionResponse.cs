using OloLabs.Promotions.SDK.Responses.Models;

namespace OloLabs.Promotions.SDK.Responses
{
    /// <summary>
    /// Returned for a successful call to the Void Redemption endpoint.
    /// </summary>
    public class VoidRedemptionResponse
    {
        public Transaction Transaction { get; set; }
    }
}