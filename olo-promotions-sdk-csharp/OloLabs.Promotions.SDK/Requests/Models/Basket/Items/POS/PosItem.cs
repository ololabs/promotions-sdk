using System.Collections.Generic;

namespace OloLabs.Promotions.SDK.Requests.Models.Basket.Items.POS
{
    public class PosItem
    {
        /// <summary>
        /// The POS product ID.
        /// </summary>
        public string Product { get; set; }
        /// <summary>
        /// The POS category IDs for the product.
        /// </summary>
        public IEnumerable<string> Categories { get; set; } = new List<string>();
        /// <summary>
        /// The modifiers applied to the product.
        /// </summary>
        public IEnumerable<Modifier> Modifiers { get; set; } = new List<Modifier>();
        /// <summary>
        /// The name of the product on the POS.
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// The per-unit cost of the product on the POS.
        /// </summary>
        public decimal Cost { get; set; }
    }
}