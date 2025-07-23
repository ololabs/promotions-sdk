using Microsoft.AspNetCore.Mvc;
using Olo.Promotions.SDK.Requests;
using Olo.Promotions.SDK.Responses;
using Olo.Promotions.SDK.Responses.Models.Accounts;
using Olo.Promotions.SDK.Responses.Models.Accounts.Rewards;
using Reference = Olo.Promotions.SDK.Responses.Models.Accounts.Reference;
using Type = Olo.Promotions.SDK.Responses.Models.Accounts.Rewards.Type;

namespace Olo.Promotions.ExampleAPI.Controllers
{
    [ApiController]
    [Route("/promotions/accounts")]
    public class CreateAccountController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType<CreateAccountResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status403Forbidden)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult CreateAccount([FromBody] CreateAccountRequest request)
        {
            /*
             * The account should be created using the provided parameters (firstName, lastName, phoneNumber, emailAddress, externalIdentifier).
             */

            var account = CreateNewAccountForUser(request.FirstName, request.LastName, request.PhoneNumber, request.EmailAddress, request.ExternalIdentifier);

            /*
             * If the account is created without error, then the account details are returned in a 200 OK response.
             */
            return Ok(account);
        }

        private Account? CreateNewAccountForUser(string firstName, string lastName, string phoneNumber, string emailAddress, string externalIdentifier)
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