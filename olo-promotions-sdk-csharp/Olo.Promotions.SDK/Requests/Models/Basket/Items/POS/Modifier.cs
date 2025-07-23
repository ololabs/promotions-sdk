using System.Collections.Generic;

namespace Olo.Promotions.SDK.Requests.Models.Basket.Items.POS
{
    public class Modifier
    {
        /// <summary>
        /// The POS modifier ID.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The quantity of the modifier applied to the product.
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// The POS product ID the modifier is applied to.
        /// </summary>
        public string Product { get; set; }
        /// <summary>
        /// The POS category IDs for the modifier.
        /// </summary>
        public IEnumerable<string> Categories { get; set; } = new List<string>();
        /// <summary>
        /// The name of the modifier on the POS.
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// The per-unit cost of the modifier on the POS.
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// The modifiers applied to the modifier.
        /// </summary>
        public IEnumerable<Modifier> Modifiers { get; set; } = new List<Modifier>();
    }
}