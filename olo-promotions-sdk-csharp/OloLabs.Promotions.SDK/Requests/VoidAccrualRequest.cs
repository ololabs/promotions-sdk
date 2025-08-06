namespace OloLabs.Promotions.SDK.Requests
{
    public class VoidAccrualRequest
    {
        /// <summary>
        /// The ID of the order, which is only populated once the order has been placed.
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// The loyalty account's unique identifier in the provider's system.
        /// </summary>
        public string AccountId { get; set; }
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