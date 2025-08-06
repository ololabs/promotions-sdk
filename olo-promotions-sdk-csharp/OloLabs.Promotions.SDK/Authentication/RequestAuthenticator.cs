using System;
using System.Security.Cryptography;
using System.Text;

namespace OloLabs.Promotions.SDK.Authentication
{
    public class RequestAuthenticator : IRequestAuthenticator
    {
        public string CreateSignature(string url, string body, string secret)
        {
            var plainBytes = Encoding.UTF8.GetBytes(url + body);
            var secretBytes = Encoding.UTF8.GetBytes(secret);

            using (var algorithm = new HMACSHA256(secretBytes))
            {
                var hash = algorithm.ComputeHash(plainBytes);

                return ToUrlBase64WithoutPadding(hash);
            }
            
            string ToUrlBase64WithoutPadding(byte[] bytes) =>
                Convert.ToBase64String(bytes).Replace('+', '-').Replace('/', '_').Replace("=", string.Empty);
        }
        
        public string CreateBasicAuthorizationValue(string secret)
            => Convert.ToBase64String(Encoding.UTF8.GetBytes(secret));
    }
}