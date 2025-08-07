namespace OloLabs.Promotions.SDK.Requests.Models.Payments
{
    public class Payment
    {
        /// <summary>
        /// The payment's tender type.
        /// </summary>
        public Tender? Tender { get; set; }
        /// <summary>
        /// The credit card issuer. Only populated if <see cref="Tender"/> is "credit".
        /// </summary>
        public Issuer? Issuer { get; set; }
        /// <summary>
        /// The credit card suffix. Only populated if <see cref="Tender"/> is "credit".
        /// </summary>
        public string Suffix { get; set; }
        /// <summary>
        /// The payment amount for this payment method.
        /// </summary>
        public decimal? Amount { get; set; }
    }
}