namespace OloLabs.Promotions.SDK.Requests.Models.Basket.Items.POS
{
    public class PosEntry
    {
        /// <summary>
        /// The quantity of the item in the basket.
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// The item's details.
        /// </summary>
        public PosItem PosItem { get; set; }
    }
}