using OloLabs.Promotions.SDK.Responses.Models;

namespace OloLabs.Promotions.SDK.Responses
{
    /// <summary>
    /// Returned for a successful call to the Redeem Promotions endpoint.
    /// </summary>
    public class RedeemPromotionsResponse
    {
        public TransactionWithPromotions Transaction { get; set; }
    }
}