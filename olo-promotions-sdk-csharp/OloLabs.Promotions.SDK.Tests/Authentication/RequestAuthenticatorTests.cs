using OloLabs.Promotions.SDK.Authentication;

namespace OloLabs.Promotions.SDK.Tests.Authentication;

[TestFixture]
public class RequestAuthenticatorTests
{
    private RequestAuthenticator _requestAuthenticator;
    
    [SetUp]
    public void Setup()
    {
        _requestAuthenticator = new RequestAuthenticator();
    }

    [Test]
    public void ForBasicAuth_GeneratesExpectedValue()
    {
        const string secret = "the secret";
        
        var result = _requestAuthenticator.CreateBasicAuthorizationValue(secret);

        result.Should().Be("dGhlIHNlY3JldA==");
    }
    
    [Test]
    public void ForKeyBasedAuth_GeneratesExpectedValue()
    {
        const string url = "http://fake-url.local";
        const string body = "some content";
        const string secret = "the secret";
        const string expectedSignature = "kcyxqCCIUR4ZG6qoeQ3CgaFzaHhI_bkWBambxcVFzJ8";
        
        var result = _requestAuthenticator.CreateSignature(url, body, secret);

        result.Should().Be(expectedSignature);
    }
    
    [Test]
    public void ForKeyBasedAuth_GeneratesExpectedValue2()
    {
        const string url = "https://localhost:7012/promotions/validate";
        const string body = """{"orderId":null,"accountId":"044d8de0-0978-40f2-aab6-07aadea2a876","source":"Other","handoff":"pickup","currency":"USD","placed":null,"wanted":null,"storeNumber":"193","restaurant":"192498","brand":"193","subtotal":15.00,"tax":0.00,"tip":0.0000,"delivery":0.0000,"customFees":0.0,"discount":0.0,"total":15.00,"address":null,"payments":null,"basket":{"id":"8521027f-1a81-4f53-afc6-e0c7e19f9ea5","rewards":[{"provider":"Mock Promotions API","id":"abcd1234","level":"basket","product":null,"discount":0.0}],"coupons":[{"provider":null,"id":null,"level":"basket","product":null,"discount":0.0}],"entries":[{"quantity":3,"item":{"product":"534035","label":"Cheeseburger","cost":5.0000}}],"posEntries":[{"quantity":3,"posItem":{"product":"51242557","categories":[],"modifiers":[],"label":"Cheeseburger","cost":5.00}}]}}""";
        const string secret = "YOUR_SHARED_SECRET";
        const string expectedSignature = "0aOAWNziTtYu-bCA9V9I7hAuww-xEzUSWoGjo8SWu-M";
        
        var result = _requestAuthenticator.CreateSignature(url, body, secret);

        result.Should().Be(expectedSignature);
    }
}