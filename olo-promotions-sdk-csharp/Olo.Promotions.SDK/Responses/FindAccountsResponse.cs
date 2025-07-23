using System.Collections.Generic;
using Olo.Promotions.SDK.Responses.Models.Accounts;

namespace Olo.Promotions.SDK.Responses
{
    /// <summary>
    /// Returned for a successful call to the Find Accounts endpoint.
    /// </summary>
    public class FindAccountsResponse : List<Account>
    {
    }
}