using Olo.Promotions.SDK.Responses.Models.Accounts.Rewards;

namespace Olo.Promotions.SDK.Responses.Models.Accounts
{
    public class Reference
    {
        /// <summary>
        /// The POS reference type.
        /// </summary>
        public Type Type { get; set; }
        /// <summary>
        /// The POS reference value.
        /// </summary>
        public string Code { get; set; }
    }
}