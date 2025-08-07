using Microsoft.AspNetCore.Mvc;
using OloLabs.Promotions.SDK.Responses;
using OloLabs.Promotions.SDK.Responses.Models.Accounts;
using OloLabs.Promotions.SDK.Responses.Models.Accounts.Rewards;
using Reference = OloLabs.Promotions.SDK.Responses.Models.Accounts.Reference;
using Type = OloLabs.Promotions.SDK.Responses.Models.Accounts.Rewards.Type;

namespace OloLabs.Promotions.ExampleAPI.Controllers
{
    [ApiController]
    [Route("/promotions/accounts")]
    public class FindAccountsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType<FindAccountsResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status403Forbidden)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult FindAccounts(
            [FromQuery(Name = "membershipNumber")] string membershipNumber)
        {
            /*
             * Accounts should be queried using the provided membership number.
             */
            
            var accounts = LookupAccounts(membershipNumber);
            
            /*
             * A 200 OK response should be returned with the found accounts, or an empty list if no accounts are found.
             */
            return Ok(accounts);
        }

        private IEnumerable<Account> LookupAccounts(string membershipNumber)
        {
            return new List<Account>
            {
                ExampleAccount()
            };
        }

        private static Account ExampleAccount() =>
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Status = Status.Active,
                Balance = new Balance
                {
                    Quantity = 250,
                    Target = 1000,
                    Unit = "points"
                },
                Rewards = new List<Reward>
                {
                    new Reward
                    {
                        Id = "abcd1234",
                        Name = "$5 Off",
                        Description = "Get $5 off your next order!",
                        Quantity = 1,
                        Currency = "USD",
                        Expiration = new DateTime().AddHours(4),
                        Reference = new Reference
                        {
                            Type = Type.Promo,
                            Code = "10001"
                        },
                        Type = "redeemable",
                        ImageUrl = "https://cdn.loyaltypartner.com/rewards/perk-badge.png",
                        CustomFields = "{\n\"campaignId\": \"spring23\",\n\"isStackable\": true,\n\"bonusPoints\": 50\n}"
                    }
                }
            };
    }
}