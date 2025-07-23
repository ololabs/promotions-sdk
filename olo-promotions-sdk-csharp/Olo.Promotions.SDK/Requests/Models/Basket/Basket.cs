using System.Collections.Generic;
using Olo.Promotions.SDK.Requests.Models.Basket.Discounts;
using Olo.Promotions.SDK.Requests.Models.Basket.Items.Olo;
using Olo.Promotions.SDK.Requests.Models.Basket.Items.POS;

namespace Olo.Promotions.SDK.Requests.Models.Basket
{
    public class Basket
    {
        /// <summary>
        /// The ID of the basket. Serves as the unique identifier for the order until it's placed and an order ID is generated.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Any loyalty rewards applied to the basket.
        /// </summary>
        public IEnumerable<Reward> Rewards { get; set; } = new List<Reward>();
        /// <summary>
        /// Any coupons applied to the basket.
        /// </summary>
        public IEnumerable<Coupon> Coupons { get; set; } = new List<Coupon>();
        /// <summary>
        /// The Olo representations of the basket items.
        /// </summary>
        public IEnumerable<Entry> Entries { get; set; } = new List<Entry>();
        /// <summary>
        /// The POS representations of the basket items.
        /// </summary>
        public IEnumerable<PosEntry> PosEntries { get; set; } = new List<PosEntry>();
    }
}