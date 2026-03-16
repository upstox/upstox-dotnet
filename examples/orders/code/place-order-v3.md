## Place an order with slicing enabled

```csharp
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = Host.CreateDefaultBuilder()
    .ConfigureApi((context, services, options) =>
    {
        options.AddTokens(new OAuthToken("{your_access_token}"));
    }).Build();
await host.StartAsync();

var services = host.Services;
var apiInstance = services.GetRequiredService<IOrderV3Api>();
try
{
    var response = await apiInstance.PlaceOrderAsync(new PlaceOrderV3Request(quantity: 1, product: PlaceOrderV3Request.ProductEnum.I, validity: PlaceOrderV3Request.ValidityEnum.DAY, price: 11f, instrumentToken: "NSE_EQ|INE669E01016", orderType: PlaceOrderV3Request.OrderTypeEnum.LIMIT, transactionType: PlaceOrderV3Request.TransactionTypeEnum.BUY, disclosedQuantity: 0, triggerPrice: 0f, isAmo: false));
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Place an order with slicing disabled

```csharp
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = Host.CreateDefaultBuilder()
    .ConfigureApi((context, services, options) =>
    {
        options.AddTokens(new OAuthToken("{your_access_token}"));
    }).Build();
await host.StartAsync();

var services = host.Services;
var apiInstance = services.GetRequiredService<IOrderV3Api>();
try
{
    var response = await apiInstance.PlaceOrderAsync(new PlaceOrderV3Request(quantity: 1, product: PlaceOrderV3Request.ProductEnum.I, validity: PlaceOrderV3Request.ValidityEnum.DAY, price: 11f, instrumentToken: "NSE_EQ|INE669E01016", orderType: PlaceOrderV3Request.OrderTypeEnum.LIMIT, transactionType: PlaceOrderV3Request.TransactionTypeEnum.BUY, disclosedQuantity: 0, triggerPrice: 0f, isAmo: false));
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
