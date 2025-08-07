using OloLabs.Promotions.SDK.Responses.Models.Accounts;
using System.Collections.Generic;

namespace OloLabs.Promotions.SDK.Responses
{
    /// <summary>
    /// Returned for a successful call to the Find Accounts endpoint.
    /// </summary>
    public class FindAccountsResponse : List<Account>
    {
    }
}