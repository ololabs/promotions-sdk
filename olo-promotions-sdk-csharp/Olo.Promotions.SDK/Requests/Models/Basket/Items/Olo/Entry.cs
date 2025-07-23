namespace Olo.Promotions.SDK.Requests.Models.Basket.Items.Olo
{
    public class Entry
    {
        /// <summary>
        /// The quantity of the item in the basket.
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// The item's details.
        /// </summary>
        public Item Item { get; set; }
    }
}