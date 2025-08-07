using Microsoft.AspNetCore.Mvc;
using OloLabs.Promotions.SDK.Requests;
using OloLabs.Promotions.SDK.Responses;
using OloLabs.Promotions.SDK.Responses.Models;

namespace OloLabs.Promotions.ExampleAPI.Controllers
{
    [ApiController]
    [Route("/promotions/accruals")]
    public class AccruePointsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType<AccruePointsResponse>(StatusCodes.Status200OK)]
        [ProducesResponseType<ErrorCodeResponse>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status403Forbidden)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType<ErrorResponse>(StatusCodes.Status503ServiceUnavailable)]
        public IActionResult AccruePoints([FromBody] AccruePointsRequest request)
        {
            /*
             * The request details should be used to determine how many points to accrue for the given account ID.
             *
             * If the account ID is invalid of if the account doesn't exist, a 400 Not Found response should be returned.
             */
            
            /*
             * Once accrual is complete, create a Transaction in your system and return the Transaction ID in a 200 OK response.
             */
            
            /*
             * Example: the request is valid, so a Transaction is created using a Guid as an ID.
             * Note that the logic for saving the Transaction in the system is not provided here.
             */
            return Ok(new AccruePointsResponse
            {
                Transaction = new Transaction
                {
                    Id = Guid.NewGuid().ToString()
                }
            });
        }
    }
}