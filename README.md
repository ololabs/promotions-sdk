# Olo.Promotions.SDK

Olo.Promotions.SDK is a NuGet package that provides models and tools for integrating with the Olo Promotions Specification.

View the Promotions Spec at https://developer.olo.com/docs.

Use of the SDK is subject to the terms of the [Olo Promotions SDK License](LICENSE.md).

## Table of Contents

- [Olo.Promotions.SDK](#olopromotionssdk)
  - [Table of Contents](#table-of-contents)
  - [Getting Started](#getting-started)
    - [Install from nuget.org](#install-from-nugetorg)
    - [Install from `.nupkg` file](#install-from-nupkg-file)
  - [Structure](#structure)
  - [How to Use](#how-to-use)
    - [Authentication](#authentication)
    - [Requests](#requests)
    - [Responses](#responses)
      - [Successful Responses](#successful-responses)
      - [Error Responses](#error-responses)

## Getting Started

### Install from nuget.org

Coming soon.

### Install from `.nupkg` file

1. Download the NuGet package from our [latest release](https://github.com/ololabs/olo-promotions-sdk/releases/latest).
2. Create a local feed for NuGet.
   - See https://learn.microsoft.com/en-us/nuget/hosting-packages/local-feeds.
3. Add the Olo.Promotions.SDK package to the local feed.
4. Install the package to your application.
   - `nuget install Olo.Promotions.SDK`

## Structure

The SDK includes three primary directories/namespaces:

```bash
├───Olo.Promotions.SDK
│   ├───Authentication
│   ├───Requests
│   └───Responses
```

These areas include:

- Authentication helpers
- Models for Requests
- Models for Responses

## How to Use

### Authentication

```cs
bool ValidateSignature(string signatureFromRequest)
{
    // Build the RequestAuthenticator.
    var requestAuthenticator = new RequestAuthenticator();

    // Generate a signature using the URL and body from the incoming request, along with the shared secret between you and Olo.
    var expectedSignature = requestAuthenticator.CreateSignature(
        url: "https://your-promotions-api.local/promotions/validate",
        body: "{the-request-body}",
        secret: "YOUR_SECRET");

    // Compare the request's signature (provided in the header X-Promo-Signature) with your generated signature.
    // If they match, then the signature is valid and the request is successfully authenticated.
    // If they don't match, then the signature is invalid and the request fails authentication.
    return signatureFromRequest == expectedSignature;
}
```

> [!TIP]
> You can register the `RequestAuthenticator` for dependency injection using the `IRequestAuthenticator` interface.
> 
> ```cs
> builder.Services.AddSingleton<IRequestAuthenticator, RequestAuthenticator>();
> ```
> Then you can inject it in your controllers/services/etc.
> 
>```cs
> public class PromotionsRequestAuthenticatorMiddleware
> {
>     private readonly IRequestAuthenticator _requestAuthenticator;
> 
>     public PromotionsRequestAuthenticatorMiddleware(IRequestAuthenticator requestAuthenticator)
>     {
>         _requestAuthenticator = requestAuthenticator;
>     }
> 
>     bool ValidateSignature(string signatureFromRequest)
>     {
>         var expectedSignature = _requestAuthenticator.CreateSignature(...);
> 
>         ...
>     }
> }
> ```

### Requests

The following request models are provided:

- `AccruePointsRequest`
- `CreateAccountRequest`
- `RedeemPromotionsRequest`
- `ValidatePromotionsRequest`
- `VoidAccrualRequest`
- `VoidRedemptionRequest`

You can use the relevant models in your API configuration to accept incoming Promotions requests that specify a request body.

```cs
public class ValidatePromotionsController
{
    [HttpPost]
    public IActionResult ValidatePromotions([FromBody] ValidatePromotionsRequest request)
    {
        Console.WriteLine(JsonSerializer.Serialize(request));
    }
}

// Output:
// {
//    "orderId": null,
//    "accountId": "391528477",
//    "source": "Web",
//    "handoff": "delivery",
//    "currency": "USD",
//    "placed": "2023-02-01T18:00:00.000Z",
//    "wanted": "2023-02-01T19:30:00.000Z",
//    ...
// }
```

> [!NOTE]
> No request models are provided for the endpoints "Find Accounts" and "Get Account" since they only accept query and path parameters via the URL and do not accept request bodies.
>
> To accept these parameters, specify them in your API route configuration.
>
> ```cs
> [Route("/promotions/accounts/{accountId}")]
> public class GetAccountController
> {
>     ...
> }
> ```


### Responses

#### Successful Responses

The following response models are provided:

- `AccruePointsResponse`
- `CreateAccountResponse`
- `FindAccountsResponse`
- `GetAccountResponse`
- `RedeemPromotionsResponse`
- `ValidatePromotionsResponse`
- `VoidAccrualResponse`
- `VoidRedemptionResponse`

You can use the relevant models to return successful responses from your API.

```cs
public class VoidAccrualController
{
    [HttpDelete]
    public IActionResult VoidAccrual(...)
    {
        ...

        return Ok(new VoidAccrualResponse
        {
            Transaction = new Transaction
            {
                ...
            }
        });
    }
}
```

#### Error Responses

Two error response models are provided:

- `ErrorCodeResponse`
  - For `400 Bad Request` error responses that require a `code`.
  - Use `ErrorCode` to specify the value for `code`
    - `ErrorCode.InvalidAccount` -> `INVALID_ACCOUNT`
    - `ErrorCode.InvalidPromotion` -> `INVALID_PROMOTION`
    - etc.
- `ErrorResponse`
  - For all other error responses.

Example for `ErrorCodeResponse`:
```cs
public class VoidAccrualController
{
    [HttpDelete]
    [Route("/promotions/accruals/{accrualId}")]
    public IActionResult VoidAccrual(string accrualId, [FromBody] VoidAccrualRequest request)
    {
        ...

        return BadRequest(new ErrorCodeResponse
        {
            Id = Guid.NewGuid().ToString(),
            Code = ErrorCode.InvalidAccount // "INVALID_ACCOUNT",
            Details = $"Account ID '{request.AccountId}' could not be found.",
            Message = "There was a problem with your loyalty account. Please try again later."
        });
    }
}
```

Example for `ErrorResponse`:
```cs
public class VoidAccrualController
{
    [HttpDelete]
    [Route("/promotions/accruals/{accrualId}")]
    public IActionResult VoidAccrual(string accrualId, [FromBody] VoidAccrualRequest request)
    {
        ...

        return NotFound(new ErrorResponse
        {
            Id = Guid.NewGuid().ToString(),
            Details = $"Transaction ID {accrualId} could not be found.",
            Message = "There was a problem voiding the loyalty transaction. Please try again later."
        });
    }
}
```