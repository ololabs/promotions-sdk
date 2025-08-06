namespace OloLabs.Promotions.SDK.Responses.Models.Accounts
{
    public class Balance
    {
        /// <summary>
        /// The amount of "points" in the user's loyalty account. The term "points" is customizable via <see cref="Unit"/>.
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// The "points" required for the user the unlock some next step in their loyalty account. Used to display an optional progress bar. The term "points" is customizable via <see cref="Unit"/>.
        /// </summary>
        public decimal Target { get; set; }
        /// <summary>
        /// The unit used to describe the quantity of a loyalty account balance.
        /// </summary>
        public string Unit { get; set; } = "points";
    }
}