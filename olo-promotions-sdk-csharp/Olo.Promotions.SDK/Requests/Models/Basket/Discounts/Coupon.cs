namespace Olo.Promotions.SDK.Requests.Models.Basket.Discounts
{
    public class Coupon
    {
        /// <summary>
        /// The coupon's code.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The name of the coupon's provider.
        /// </summary>
        public string Provider { get; set; }
        /// <summary>
        /// The level at which the coupon is applied.
        /// <list type="bullet">
        ///     <item>
        ///         <description>An example of an item-level coupon would be "Free Slice of Cheese"</description>
        ///     </item>
        ///     <item>
        ///         <description>An example of a basket-level coupon would be "$10 Off"</description>
        ///     </item>
        /// </list>
        /// </summary>
        public Level Level { get; set; }
        /// <summary>
        /// The Olo ID of the product the coupon is applied to. Only populated if <see cref="Level"/> is "item".
        /// </summary>
        public string Product { get; set; }
        /// <summary>
        /// The discount amount for the coupon. Only populated if the basket has already been successfully validated.
        /// </summary>
        public decimal? Discount { get; set; }
    }
}