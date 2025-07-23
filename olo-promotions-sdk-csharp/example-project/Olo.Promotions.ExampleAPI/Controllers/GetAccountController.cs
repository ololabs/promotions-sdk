using Microsoft.AspNetCore.Mvc;
using Olo.Promotions.SDK.Responses;
using Olo.Promotions.SDK.Responses.Models.Accounts;
using Olo.Promotions.SDK.Responses.Models.Accounts.Rewards;
using Reference = Olo.Promotions.SDK.Responses.Models.Accounts.Reference;
using Type = Olo.Promotions.SDK.Responses.Models.Accounts.Rewards.Type;

namespace Olo.Promotions.ExampleAPI.Controllers
{
    [ApiController]
    [Route("/promotions/accounts/{accountId}")]
    public class GetAccountController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType<GetAccountResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status403Forbidden)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult GetAccount(string accountId)
        {
            /*
             * The account should be looked up using the provided ID.
             */
            
            var account = LookupAccount(accountId);
            
            /*
             * If the account ID is invalid or the account is not found, then a 404 Not Found response is returned.
             */

            /*
             * Example: the given account was not found, so a 404 Not Found response is returned. The relevant request details are
             * saved in the system for future reference under a unique ID, and this ID is returned in the error response.
             * Note that the logic for saving the request details in the system is not provided here.
             */
            if (account is null)
            {
                var requestId = Guid.NewGuid();
                
                return NotFound(new ErrorResponse
                {
                    Id = requestId.ToString(),
                    Details = $"No account was found with ID '{accountId}'",
                    Message = "There was a problem with your loyalty account. Please try again."
                });
            }
            
            /*
             * If the account is found, then the account details are returned in a 200 OK response.
             */
            return Ok(account);
        }

        private Account? LookupAccount(string accountId)
        {
            return new Account
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
                        Expiration = DateTime.UtcNow.AddHours(4),
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
}