using Olo.Promotions.SDK.Responses.Models;

namespace Olo.Promotions.SDK.Responses
{
    /// <summary>
    /// Returned for a successful call to the Void Accrual endpoint.
    /// </summary>
    public class VoidAccrualResponse
    {
        public Transaction Transaction { get; set; }
    }
}