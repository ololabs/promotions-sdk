using Microsoft.AspNetCore.Mvc;
using Olo.Promotions.SDK.Requests;
using Olo.Promotions.SDK.Responses;
using Olo.Promotions.SDK.Responses.Models;

namespace Olo.Promotions.ExampleAPI.Controllers
{
    [ApiController]
    [Route("/promotions/redemptions/{redemptionId}")]
    public class VoidPromotionsController : ControllerBase
    {
        [HttpDelete]
        [ProducesResponseType<VoidRedemptionResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorCodeResponse>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status403Forbidden)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult VoidRedemption(string redemptionId, [FromBody] VoidRedemptionRequest request)
        {
            /*
             * The redemption details should be looked up using the redemptionId provided in the URL path.
             * The redemptionId refers to the Transcation created in the Redeem Promotions request.
             *
             * If the redemption is not found, a 404 Not Found response should be returned with the relevant details.
             */
            
            /*
             * Once the redemption is found, any necessary validation should be performed, such as validating the account ID
             * (if provided).
             */
            
            /*
             * Using the details in the request, the coupons and/or rewards provided in the request should be voided.
             * In other words, the redemption should be undone so that the coupons and/or rewards can be used again as if they
             * were never used.
             *
             * If any promotions are invalid for voiding, a 400 Bad Request should be returned with "code" set to
             * "INVALID_PROMOTION" and any relevant promotion details specified in "details".
             */
            
            /*
             * Once voiding is successful, create a Transaction in your system and return the Transaction ID in a 200 OK response.
             */
            
            /*
             * Example: the request is valid, so a Transaction is created using a Guid as an ID.
             * Note that the logic for saving the Transaction in the system is not provided here.
             */
            return Ok(new VoidRedemptionResponse
            {
                Transaction = new Transaction
                {
                    Id = Guid.NewGuid().ToString()
                }
            });
        }
    }
}