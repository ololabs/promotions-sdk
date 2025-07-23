namespace Olo.Promotions.SDK.Requests
{
    public class CreateAccountRequest
    {
        /// <summary>
        /// First name for the user.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name for the user.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Phone number for the user.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email address for the user.
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Unique external identifier for the user.
        /// </summary>
        public string ExternalIdentifier { get; set; }
    }
}