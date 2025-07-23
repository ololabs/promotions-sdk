using System;
using System.Collections.Generic;
using Olo.Promotions.SDK.Requests.Models;
using Olo.Promotions.SDK.Requests.Models.Basket;
using Olo.Promotions.SDK.Requests.Models.Payments;

namespace Olo.Promotions.SDK.Requests
{
    public class RedeemPromotionsRequest
    {
        /// <summary>
        /// The ID of the order, which is only populated once the order has been placed.
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// The loyalty account's unique identifier in the provider's system. Will only be provided in the case the basket or
        /// order contains loyalty rewards.
        /// </summary>
        public string AccountId { get; set; }
        /// <summary>
        /// The source of the order.
        /// <list type="table">
        ///     <listheader>
        ///         <term>Source</term>
        ///         <description>Value</description>
        ///     </listheader>
        ///     <item>
        ///         <term>Web (Desktop)</term>
        ///         <description>Web</description>
        ///     </item>
        ///     <item>
        ///         <term>Web (Mobile)</term>
        ///         <description>MobileWeb</description>
        ///     </item>
        ///     <item>
        ///         <term>Serve</term>
        ///         <description>MobileWeb</description>
        ///     </item>
        ///     <item>
        ///         <term>iOS</term>
        ///         <description>iOS</description>
        ///     </item>
        ///     <item>
        ///         <term>Android</term>
        ///         <description>Android</description>
        ///     </item>
        ///     <item>
        ///         <term>Kiosk</term>
        ///         <description>Kiosk</description>
        ///     </item>
        ///     <item>
        ///         <term>Not Listed</term>
        ///         <description>Other</description>
        ///     </item>
        /// </list>
        /// </summary>
        public Source Source { get; set; }
        /// <summary>
        /// The handoff method for the order.
        /// </summary>
        public Handoff? Handoff { get; set; }
        /// <summary>
        /// A three-letter <a href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</a> code. If none is provided, will default to "USD".
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// A UTC date-time as defined in <a href="https://www.rfc-editor.org/rfc/rfc3339">RFC 3339</a> that represents when the order was created, but does not indicate when the order was paid for or when the guest wants to receive their food.
        /// </summary>
        public DateTime Placed { get; set; }
        /// <summary>
        /// A UTC date-time as defined in <a href="https://www.rfc-editor.org/rfc/rfc3339">RFC 3339</a> that represents when the guest wants to receive their food.
        /// </summary>
        public DateTime? Wanted { get; set; }
        /// <summary>
        /// The ID of the store as provided by the restaurant.
        /// </summary>
        public string StoreNumber { get; set; }
        /// <summary>
        /// A unique ID representing the vendor restaurant in Olo's system.
        /// </summary>
        public string Restaurant { get; set; }
        /// <summary>
        /// A unique ID representing the restaurant brand in Olo's system.
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// The cost of the food before applying any tax, tip, fees or discounts.
        /// </summary>
        public decimal Subtotal { get; set; }
        /// <summary>
        /// The amount of tax applied to the order.
        /// </summary>
        public decimal? Tax { get; set; }
        /// <summary>
        /// The amount the customer tipped on the order.
        /// </summary>
        public decimal? Tip { get; set; }
        /// <summary>
        /// The delivery fee for the order.
        /// </summary>
        public decimal? Delivery { get; set; }
        /// <summary>
        /// The sum of any custom fees applied to the order.
        /// </summary>
        public decimal? CustomFees { get; set; }
        /// <summary>
        /// The sum of any discounts applied to the order.
        /// </summary>
        public decimal? Discount { get; set; }
        /// <summary>
        /// The final total for the order after any tax, tip, fees and discounts.
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// The destination address of the order.
        /// </summary>
        public Address Address { get; set; }
        /// <summary>
        /// Any payments applied to the order.
        /// </summary>
        public IEnumerable<Payment> Payments { get; set; } = new List<Payment>();
        /// <summary>
        /// The basket contents.
        /// </summary>
        public Basket Basket { get; set; }
    }
}