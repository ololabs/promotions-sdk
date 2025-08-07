using System;

namespace OloLabs.Promotions.SDK.Responses.Models.Accounts.Rewards
{
    public class Reward
    {
        /// <summary>
        /// A unique identifier for the loyalty reward in the provider's system.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The name of the loyalty reward.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A description of the loyalty reward.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The quantity of the reward available in the account.
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// A three-letter <a href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</a> code. If none is provided, will default to "USD".
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// A UTC date-time as defined in <a href="https://www.rfc-editor.org/rfc/rfc3339">RFC 3339</a> that represents when the reward expires.
        /// </summary>
        public DateTime? Expiration { get; set; }
        /// <summary>
        /// Data used to identify the loyalty reward on the POS.
        /// </summary>
        public Reference Reference { get; set; }
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