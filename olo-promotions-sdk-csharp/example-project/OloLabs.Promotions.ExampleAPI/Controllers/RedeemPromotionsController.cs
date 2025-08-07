using Microsoft.AspNetCore.Mvc;
using OloLabs.Promotions.SDK.Requests;
using OloLabs.Promotions.SDK.Responses;
using OloLabs.Promotions.SDK.Responses.Models;
using OloLabs.Promotions.SDK.Responses.Models.Promotions;

namespace OloLabs.Promotions.ExampleAPI.Controllers
{
    [ApiController]
    [Route("/promotions/redemptions")]
    public class RedeemPromotionsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType<RedeemPromotionsResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorCodeResponse>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status403Forbidden)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult RedeemPromotions([FromBody] RedeemPromotionsRequest request)
        {
            /*
             * The logic for redemption should follow the same logic as validation, except that any included promotions are marked
             * as redeemed in the system.
             * The request should be validated and any error responses should be returned.
             */
            
            /*
             * All rewards and coupons in the request should be validated and their discount amounts should be calculated.
             */
            
            /*
             * After validating the request and calculating discount amounts for the promotions, mark the promotions as redeemed
             * in your system, create a Transaction in your system, and return the promotion details in a 200 OK response.
             */
            
            /*
             * Example: the request is valid, so a Transaction is created using a Guid as an ID, and two promotions are returned.
             * Note that the logic for saving the Transaction in the system is not provided here.
             */
            return Ok(new RedeemPromotionsResponse
            {
                Transaction = new TransactionWithPromotions
                {
                    Id = Guid.NewGuid().ToString(),
                    Promotions = new List<Promotion>
                    {
                        new Promotion
                        {
                            Id = "123",
                            Discount = 5.00m
                        },
                        new Promotion
                        {
                            Id = "456",
                            Discount = 1.25m
                        }
                    }
                }
            });
        }
    }
}