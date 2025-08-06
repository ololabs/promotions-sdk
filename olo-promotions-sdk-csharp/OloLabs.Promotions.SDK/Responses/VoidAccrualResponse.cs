using OloLabs.Promotions.SDK.Responses.Models;

namespace OloLabs.Promotions.SDK.Responses
{
    /// <summary>
    /// Returned for a successful call to the Void Accrual endpoint.
    /// </summary>
    public class VoidAccrualResponse
    {
        public Transaction Transaction { get; set; }
    }
}