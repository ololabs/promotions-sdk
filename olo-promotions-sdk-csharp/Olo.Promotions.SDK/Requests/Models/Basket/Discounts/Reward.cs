namespace Olo.Promotions.SDK.Requests.Models.Basket.Discounts
{
    public class Reward
    {
        /// <summary>
        /// The ID of the reward in the loyalty provider's system.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The name of the reward's loyalty provider.
        /// </summary>
        public string Provider { get; set; }
        /// <summary>
        /// The level at which the reward is applied.
        /// <list type="bullet">
        ///     <item>
        ///         <description>An example of an item-level reward would be "Free Chocolate Shake"</description>
        ///     </item>
        ///     <item>
        ///         <description>An example of a basket-level reward would be "10% Off"</description>
        ///     </item>
        /// </list>
        /// </summary>
        public Level Level { get; set; }
        /// <summary>
        /// The Olo ID of the product the reward is applied to. Only populated if <see cref="Level"/> is "item".
        /// </summary>
        public string Product { get; set; }
        /// <summary>
        /// The discount amount for the reward. Only populated if the basket has already been successfully validated.
        /// </summary>
        public decimal? Discount { get; set; }
        /// <summary>
        /// A string used by the provider to describe the category or nature of the reward. This value will be echoed back in subsequent ValidatePromotions and RedeemPromotions requests. Olo does not validate or interpret this value.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// An image URL representing the reward. Can be used to display icons or badges in brand experiences. Olo does not validate or interpret this value.
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Allows the provider to attach any custom metadata to persist and receive back. This can be used to pass internal references, campaign flags, configurations, etc. This value will be echoed back in subsequent ValidatePromotions and RedeemPromotions requests. Olo does not validate or interpret this value.
        /// </summary>
        public string CustomFields { get; set; }
        
    }
}