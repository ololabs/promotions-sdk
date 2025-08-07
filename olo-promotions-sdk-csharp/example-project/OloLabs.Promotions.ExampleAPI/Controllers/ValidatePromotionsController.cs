using Microsoft.AspNetCore.Mvc;
using OloLabs.Promotions.SDK.Requests;
using OloLabs.Promotions.SDK.Responses;
using OloLabs.Promotions.SDK.Responses.Models;
using OloLabs.Promotions.SDK.Responses.Models.Errors;
using OloLabs.Promotions.SDK.Responses.Models.Promotions;

namespace OloLabs.Promotions.ExampleAPI.Controllers
{
    [ApiController]
    [Route("/promotions/validate")]
    public class ValidatePromotionsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType<ValidatePromotionsResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorCodeResponse>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status403Forbidden)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult ValidatePromotions([FromBody] ValidatePromotionsRequest request)
        {
            /*
             * The request should be validated and any error responses should be returned.
             */
            
            /*
             * Example: an account ID was provided, but the account doesn't exist, so a 400 Bad Request response is returned with
             * the code "INVALID_ACCOUNT" and relevant details are included in the Details property.
             * Note that the logic for saving the request details in the system is not provided here.
             */ 
            if (request.AccountId == "some invalid state")
            {
                var requestId = Guid.NewGuid();
                
                return BadRequest(new ErrorCodeResponse
                {
                    Id = requestId.ToString(),
                    Code = ErrorCode.InvalidAccount,
                    Details = $"Account ID {request.AccountId} is invalid",
                    Message = "There was a problem looking up your loyalty account. Please try again."
                });
            }
            
            /*
             * All rewards and coupons in the request should be validated and their discount amounts should be calculated.
             */
            
            /*
             * After validating the request and calculating discount amounts for the promotions, create a Transaction in your
             * system and return the promotion details in a 200 OK response.
             */
            
            /*
             * Example: the request is valid, so a Transaction is created using a Guid as an ID, and two promotions are returned.
             * Note that the logic for saving the request details in the system is not provided here.
             */
            return Ok(new ValidatePromotionsResponse
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