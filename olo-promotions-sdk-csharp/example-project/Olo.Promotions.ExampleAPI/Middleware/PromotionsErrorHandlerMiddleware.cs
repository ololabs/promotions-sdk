using System.Net;
using Olo.Promotions.SDK.Responses;

namespace Olo.Promotions.ExampleAPI.Middleware
{
    /// <summary>
    /// Catches any exceptions that happen while handling the Promotions request and returns a 500 Internal Server Error
    /// response with the expected response schema.
    /// </summary>
    public class PromotionsErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public PromotionsErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception)
            {
                /*
                 * If possible, the request details and error details should be saved for future reference, identified by a unique ID.
                 */
                
                /*
                 * Example: a unique ID is generated for this request and error details are returned in the Details property.
                 * Note that the logic for saving the request details in the system are not provided.
                 */
                var requestId = Guid.NewGuid();

                var errorExample = "Error parsing request.";
                
                var promotionsErrorResponse = new ErrorResponse
                {
                    Id = requestId.ToString(),
                    Details = errorExample,
                    Message = "An unexpected error occurred. Please try again later."
                };
                
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(promotionsErrorResponse);
            }
        }
    }

    public static class PromotionsErrorHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UsePromotionsErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PromotionsErrorHandlerMiddleware>();
        }
    }
}