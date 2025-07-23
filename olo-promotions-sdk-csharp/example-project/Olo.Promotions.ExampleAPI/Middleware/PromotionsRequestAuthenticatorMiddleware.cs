using System.Net;
using Microsoft.Extensions.Options;
using Olo.Promotions.ExampleAPI.Options;
using Olo.Promotions.SDK.Authentication;
using Olo.Promotions.SDK.Responses;

namespace Olo.Promotions.ExampleAPI.Middleware
{
    /// <summary>
    /// Authenticates all Promotions requests using either Key-Based Authentication or Basic Authentication.
    /// </summary>
    public class PromotionsRequestAuthenticatorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<PromotionsOptions> _options;
        private readonly IRequestAuthenticator _requestAuthenticator;

        public PromotionsRequestAuthenticatorMiddleware(
            RequestDelegate next,
            IOptions<PromotionsOptions> options,
            IRequestAuthenticator requestAuthenticator)
        {
            _next = next;
            _options = options;
            _requestAuthenticator = requestAuthenticator;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            /*
             * This allows the request body stream to be read here for request authentication and then again later in the
             * request pipeline.
             */
            context.Request.EnableBuffering();
            
            var requestIsAuthenticated = await AuthenticatePromotionsRequest(context);

            if (!requestIsAuthenticated)
            {
                /*
                 * When a request fails authentication, a 401 Unauthorized response should be returned with the relevant
                 * error details. The request should be stored in the system using a unique ID.
                 */
                
                /*
                 * Example: a unique ID is generated using a Guid
                 */
                var requestId = Guid.NewGuid();
                
                var promotionsErrorResponse = new ErrorResponse
                {
                    Id = requestId.ToString(),
                    Details = "Request failed authentication.",
                    Message = "There was a problem fulfilling your request. Please try again later."
                };
                
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(promotionsErrorResponse);
                
                return;
            }
            
            await _next(context);
        }

        private async Task<bool> AuthenticatePromotionsRequest(HttpContext context)
        {
            return _options.Value.AuthenticationMethod switch
            {
                PromotionsAuthenticationMethod.Basic => RequestPassesBasicAuthentication(),
                PromotionsAuthenticationMethod.KeyBased => await RequestPassesKeyBasedAuthentication(),
                _ => throw new ArgumentOutOfRangeException(nameof(_options.Value.AuthenticationMethod),
                    $"Unsupported AuthenticationMethod {_options.Value.AuthenticationMethod}."),
            };

            bool RequestPassesBasicAuthentication()
            {
                var requestSecret = context.Request.Headers.Authorization.FirstOrDefault();

                if (string.IsNullOrWhiteSpace(requestSecret))
                {
                    return false;
                }

                var expectedSecret = _requestAuthenticator.CreateBasicAuthorizationValue(_options.Value.Secret);

                return requestSecret == $"Basic {expectedSecret}";
            }
            
            async Task<bool> RequestPassesKeyBasedAuthentication()
            {
                var requestSignature = context.Request.Headers["X-Promo-Signature"].FirstOrDefault();

                if (string.IsNullOrWhiteSpace(requestSignature))
                {
                    return false;
                }

                var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
                /*
                 * Now that we've read the request body stream to the end, we need to reset it to the beginning so that it can be
                 * read again later on in the request pipeline.
                 */
                context.Request.Body.Seek(0, SeekOrigin.Begin);

                var expectedSignature = _requestAuthenticator.CreateSignature(FullRequestUrl(context.Request),
                    requestBody, _options.Value.Secret);

                return requestSignature == expectedSignature;
                
                string FullRequestUrl(HttpRequest request) =>
                    $"{request.Scheme}://{request.Host}{request.PathBase}{request.Path}{request.QueryString}";
            }
        }
    }

    public static class RequestAuthenticatorMiddlewareExtensions
    {
        public static IApplicationBuilder UsePromotionsRequestAuthenticator(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PromotionsRequestAuthenticatorMiddleware>();
        }
    }
}