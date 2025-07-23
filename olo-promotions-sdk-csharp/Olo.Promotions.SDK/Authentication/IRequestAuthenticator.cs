namespace Olo.Promotions.SDK.Authentication
{
    public interface IRequestAuthenticator
    {
        /// <summary>
        /// Generates a signature for Key-Based authentication. This signature is provided in requests via the X-Promo-Signature header.
        /// Example: X-Promo-Signature: {signature}
        /// </summary>
        /// <param name="url">The full URL of the request (e.g. "https://api.provider.local/promotions/validate")</param>
        /// <param name="body">The body of the request, serialized as JSON (<a href="https://www.rfc-editor.org/rfc/rfc4627">RFC 4627</a>) and encoded as UTF-8 (<a href="https://www.rfc-editor.org/rfc/rfc3629">RFC 3629</a>).</param>
        /// <param name="secret">The shared secret between Olo and the Promotions provider.</param>
        /// <returns></returns>
        string CreateSignature(string url, string body, string secret);
        /// <summary>
        /// Generates the authorization value for Basic Authentication. This is provided in requests via the Authorization header.
        /// Example: Authorization: Basic {value}
        /// </summary>
        /// <param name="secret">The shared secret between Olo and the Promotions provider.</param>
        /// <returns></returns>
        string CreateBasicAuthorizationValue(string secret);
    }
}