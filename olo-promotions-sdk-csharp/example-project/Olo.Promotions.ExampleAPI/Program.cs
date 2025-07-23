using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Olo.Promotions.ExampleAPI.Middleware;
using Olo.Promotions.ExampleAPI.Options;
using Olo.Promotions.SDK.Authentication;

[assembly: ApiController]
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Return enum names in camel case in Promotions responses
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    // Do not return null properties in Promotions responses
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // This resolves conflicts in Swagger since some Promotions models are reused across response types.
    // https://stackoverflow.com/a/63331752
    options.CustomSchemaIds(type => type.ToString());
});

// Read Promotions configuration settings from appsettings.json for easy reference throughout the app via IOptions<PromotionsOptions>.
builder.Services.Configure<PromotionsOptions>(builder.Configuration.GetSection("Promotions"));

// Register the Promotions RequestAuthenticator for use in the RequestAuthenticatorMiddleware
builder.Services.AddSingleton<IRequestAuthenticator, RequestAuthenticator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Use the PromotionsErrorHanderMiddleware to automatically catch exceptions and return 500 Internal Server Error
// responses with the expected schema.
app.UsePromotionsErrorHandler();

// Use the PromotionsResponseHeaderMiddleware to add the X-Promo-Version response header.
app.UsePromotionsResponseHeader();

HandlePromotionsRequestAuthentication();

app.Run();
return;

void HandlePromotionsRequestAuthentication()
{
    var promotionsOptions = app.Services.GetService<IOptions<PromotionsOptions>>()!;

    if (app.Environment.IsDevelopment() && promotionsOptions.Value.SkipAuthentication)
        return;
    
    // Use the RequestAuthenticatorMiddleware to authenticate all Promotions requests.
    app.UsePromotionsRequestAuthenticator();
}