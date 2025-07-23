using Olo.Promotions.SDK.Responses.Models;

namespace Olo.Promotions.SDK.Responses
{
    /// <summary>
    /// Returned for a successful call to the Accrue Points endpoint.
    /// </summary>
    public class AccruePointsResponse
    {
        public Transaction Transaction { get; set; }
    }
}