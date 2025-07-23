using Olo.Promotions.SDK.Responses.Models;

namespace Olo.Promotions.SDK.Responses
{
    /// <summary>
    /// Returned for a successful call to the Redeem Promotions endpoint.
    /// </summary>
    public class RedeemPromotionsResponse
    {
        public TransactionWithPromotions Transaction { get; set; }
    }
}