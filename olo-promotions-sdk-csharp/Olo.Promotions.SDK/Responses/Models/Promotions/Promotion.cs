namespace Olo.Promotions.SDK.Responses.Models.Promotions
{
    public class Promotion
    {
        /// <summary>
        /// The promotion's unique identifier in the provider's system.
        /// <list type="bullet">
        ///     <item>
        ///         <description>For coupons, this is the coupon code</description>
        ///     </item>
        ///     <item>
        ///         <description>For loyalty rewards, this is the reward ID</description>
        ///     </item>
        /// </list>
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The type of the promotion.
        /// </summary>
        public Type Type { get; set; }
        /// <summary>
        /// The provider calculated discount for the validated promotion.
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        /// Data used to identify the promotion on the POS.
        /// </summary>
        public Reference Reference { get; set; }
    }
}