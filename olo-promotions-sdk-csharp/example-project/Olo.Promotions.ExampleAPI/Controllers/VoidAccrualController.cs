using Microsoft.AspNetCore.Mvc;
using Olo.Promotions.SDK.Requests;
using Olo.Promotions.SDK.Responses;
using Olo.Promotions.SDK.Responses.Models;

namespace Olo.Promotions.ExampleAPI.Controllers
{
    [ApiController]
    [Route("/promotions/accruals/{accrualId}")]
    public class VoidAccrualController : ControllerBase
    {
        [HttpDelete]
        [ProducesResponseType<VoidAccrualResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorCodeResponse>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status403Forbidden)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult VoidAccrual(string accrualId, [FromBody] VoidAccrualRequest request)
        {
            /*
             * The accrual details should be looked up using the redemptionId provided in the URL path.
             * The accrualId refers to the Transcation created in the Accrue Points request.
             *
             * If the accrual is not found, a 404 Not Found response should be returned with the relevant details.
             */
            
            /*
             * Once voiding the accrual is complete, create a Transaction in your system and return the Transaction ID in a
             * 200 OK response.
             */
            
            /*
             * Example: the request is valid, so a Transaction is created using a Guid as an ID.
             * Note that the logic for saving the Transaction in the system is not provided here.
             */
            return Ok(new VoidAccrualResponse
            {
                Transaction = new Transaction
                {
                    Id = Guid.NewGuid().ToString()
                }
            });
        }
    }
}