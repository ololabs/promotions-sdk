namespace OloLabs.Promotions.ExampleAPI.Middleware
{
    /// <summary>
    /// Sets the X-Promo-Version header for all responses.
    /// </summary>
    public class PromotionsVersionHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// The version of the Promotions specification that this API is implemented against.
        /// </summary>
        private const string TargetPromotionsVersion = "2.0.0";

        public PromotionsVersionHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Append("X-Promo-Version", TargetPromotionsVersion);
            
            await _next(context);
        }
    }

    public static class PromotionsVersionHeaderMiddlewareExtensions
    {
        public static IApplicationBuilder UsePromotionsResponseHeader(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PromotionsVersionHeaderMiddleware>();
        }
    }
}