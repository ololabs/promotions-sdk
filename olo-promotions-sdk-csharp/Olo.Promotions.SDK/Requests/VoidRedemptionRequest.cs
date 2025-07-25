﻿using System.Collections.Generic;

namespace Olo.Promotions.SDK.Requests
{
    public class VoidRedemptionRequest
    {
        /// <summary>
        /// The ID of the order, which is only populated once the order has been placed.
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// The loyalty account's unique identifier in the provider's system. Will only be provided in the case the basket or order contains loyalty rewards.
        /// </summary>
        public string AccountId { get; set; }
        /// <summary>
        /// The coupon codes redeemed with the order that are being voided.
        /// </summary>
        public IEnumerable<string> CouponCodes { get; set; } = new List<string>();
        /// <summary>
        /// The IDs of the rewards redeemed with the order that are being voided.
        /// </summary>
        public IEnumerable<string> RewardIds { get; set; } = new List<string>();
        /// <summary>
        /// A unique ID representing the restaurant brand in Olo's system.
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// The ID of the store as provided by the restaurant.
        /// </summary>
        public string StoreNumber { get; set; }
        /// <summary>
        /// A unique ID representing the vendor restaurant in Olo's system.
        /// </summary>
        public string Restaurant { get; set; }
    }
}