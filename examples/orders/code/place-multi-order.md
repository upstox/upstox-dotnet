## Place a multi order

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
var apiInstance = services.GetRequiredService<IOrderApi>();
try
{
    var multiOrderRequest = new List<MultiOrderRequest> { new MultiOrderRequest(quantity: 25, product: MultiOrderRequest.ProductEnum.D, validity: MultiOrderRequest.ValidityEnum.DAY, price: 0f, instrumentToken: "NSE_FO|44166", orderType: MultiOrderRequest.OrderTypeEnum.MARKET, transactionType: MultiOrderRequest.TransactionTypeEnum.BUY, disclosedQuantity: 0, triggerPrice: 0f, isAmo: true, correlationId: "1") };
    var response = await apiInstance.PlaceMultiOrderAsync(multiOrderRequest, origin: "web");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Place Multiple BUY and SELL Orders

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
var apiInstance = services.GetRequiredService<IOrderApi>();
try
{
    var multiOrderRequest = new List<MultiOrderRequest>
    {
        new MultiOrderRequest(quantity: 25, product: MultiOrderRequest.ProductEnum.D, validity: MultiOrderRequest.ValidityEnum.DAY, price: 0f, instrumentToken: "NSE_FO|44166", orderType: MultiOrderRequest.OrderTypeEnum.MARKET, transactionType: MultiOrderRequest.TransactionTypeEnum.BUY, disclosedQuantity: 0, triggerPrice: 0f, isAmo: true, correlationId: "1"),
        new MultiOrderRequest(quantity: 25, product: MultiOrderRequest.ProductEnum.D, validity: MultiOrderRequest.ValidityEnum.DAY, price: 0f, instrumentToken: "NSE_FO|44122", orderType: MultiOrderRequest.OrderTypeEnum.MARKET, transactionType: MultiOrderRequest.TransactionTypeEnum.SELL, disclosedQuantity: 0, triggerPrice: 0f, isAmo: true, correlationId: "2")
    };
    var response = await apiInstance.PlaceMultiOrderAsync(multiOrderRequest, origin: "web");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Place Multiple Orders with Auto Slicing enabled

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
var apiInstance = services.GetRequiredService<IOrderApi>();
try
{
    var multiOrderRequest = new List<MultiOrderRequest> { new MultiOrderRequest(quantity: 25, product: MultiOrderRequest.ProductEnum.D, validity: MultiOrderRequest.ValidityEnum.DAY, price: 0f, instrumentToken: "NSE_FO|44166", orderType: MultiOrderRequest.OrderTypeEnum.MARKET, transactionType: MultiOrderRequest.TransactionTypeEnum.BUY, disclosedQuantity: 0, triggerPrice: 0f, isAmo: true, correlationId: "1") };
    var response = await apiInstance.PlaceMultiOrderAsync(multiOrderRequest, origin: "web");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
