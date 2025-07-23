using Olo.Promotions.SDK.Responses.Models;

namespace Olo.Promotions.SDK.Responses
{
    /// <summary>
    /// Returned for a successful call to the Void Redemption endpoint.
    /// </summary>
    public class VoidRedemptionResponse
    {
        public Transaction Transaction { get; set; }
    }
}