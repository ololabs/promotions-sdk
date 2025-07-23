namespace Olo.Promotions.SDK.Requests.Models.Basket.Items.Olo
{
    public class Item
    {
        /// <summary>
        /// The Olo product ID.
        /// </summary>
        public string Product { get; set; }
        /// <summary>
        /// The name of the product in Olo's system.
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// The per-unit cost of the product in Olo's system.
        /// </summary>
        public decimal Cost { get; set; }
    }
}