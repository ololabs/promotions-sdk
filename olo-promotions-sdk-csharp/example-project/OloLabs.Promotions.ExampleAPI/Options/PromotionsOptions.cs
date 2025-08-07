namespace OloLabs.Promotions.ExampleAPI.Options
{
    public class PromotionsOptions
    {
        /// <summary>
        /// The chosen method for authenticating Promotions requests.
        /// </summary>
        public PromotionsAuthenticationMethod AuthenticationMethod { get; set; }

        /// <summary>
        /// The shared secret between you and Olo. Used for authenticating all Promotions requests.
        /// </summary>
        public string Secret { get; set; } = string.Empty;

        /// <summary>
        /// Disables Promotions request authentication. For development purposes only.
        /// </summary>
        public bool SkipAuthentication { get; set; } = false;
    }
}