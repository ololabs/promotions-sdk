using System.Collections.Generic;
using OloLabs.Promotions.SDK.Responses.Models.Accounts.Rewards;

namespace OloLabs.Promotions.SDK.Responses.Models.Accounts
{
    public class Account
    {
        /// <summary>
        /// The account's unique identifier in the provider's system.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Whether the loyalty account is active or inactive.
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// The loyalty account's points balance.
        /// </summary>
        public Balance Balance { get; set; }
        /// <summary>
        /// The rewards available in the loyalty account.
        /// </summary>
        public IEnumerable<Reward> Rewards { get; set; } = new List<Reward>();
    }
}