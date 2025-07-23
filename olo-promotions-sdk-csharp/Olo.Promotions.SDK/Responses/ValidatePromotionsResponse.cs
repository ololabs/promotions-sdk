using Olo.Promotions.SDK.Responses.Models;

namespace Olo.Promotions.SDK.Responses
{
    /// <summary>
    /// Returned for a successful call to the Validate Promotions endpoint.
    /// </summary>
    public class ValidatePromotionsResponse
    {
        public TransactionWithPromotions Transaction { get; set; }
    }
}