using System.Collections.Generic;
using Olo.Promotions.SDK.Responses.Models.Promotions;

namespace Olo.Promotions.SDK.Responses.Models
{
    /// <summary>
    /// Represents the result of a Promotions operation that includes validated or redeemed promotions.
    /// </summary>
    public class TransactionWithPromotions : Transaction
    {
        /// <summary>
        /// The details of the validated/redeemed promotions.
        /// </summary>
        public IEnumerable<Promotion> Promotions { get; set; } = new List<Promotion>();
    }
}