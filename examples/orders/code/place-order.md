## Place a delivery market order

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
    var multiOrderRequest = new List<MultiOrderRequest> { new MultiOrderRequest(quantity: 1, product: MultiOrderRequest.ProductEnum.D, validity: MultiOrderRequest.ValidityEnum.DAY, price: 0f, instrumentToken: "NSE_EQ|INE528G01035", orderType: MultiOrderRequest.OrderTypeEnum.MARKET, transactionType: MultiOrderRequest.TransactionTypeEnum.BUY, disclosedQuantity: 0, triggerPrice: 0f, isAmo: false, correlationId: "1") };
    var response = await apiInstance.PlaceMultiOrderAsync(multiOrderRequest, origin: "web");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Place a delivery limit order

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
    var multiOrderRequest = new List<MultiOrderRequest> { new MultiOrderRequest(quantity: 1, product: MultiOrderRequest.ProductEnum.D, validity: MultiOrderRequest.ValidityEnum.DAY, price: 20f, instrumentToken: "NSE_EQ|INE528G01035", orderType: MultiOrderRequest.OrderTypeEnum.LIMIT, transactionType: MultiOrderRequest.TransactionTypeEnum.BUY, disclosedQuantity: 0, triggerPrice: 20.1f, isAmo: false, correlationId: "1") };
    var response = await apiInstance.PlaceMultiOrderAsync(multiOrderRequest, origin: "web");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Place a delivery stop-loss order

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
    var multiOrderRequest = new List<MultiOrderRequest> { new MultiOrderRequest(quantity: 1, product: MultiOrderRequest.ProductEnum.D, validity: MultiOrderRequest.ValidityEnum.DAY, price: 20f, instrumentToken: "NSE_EQ|INE528G01035", orderType: MultiOrderRequest.OrderTypeEnum.SL, transactionType: MultiOrderRequest.TransactionTypeEnum.BUY, disclosedQuantity: 0, triggerPrice: 19.5f, isAmo: false, correlationId: "1") };
    var response = await apiInstance.PlaceMultiOrderAsync(multiOrderRequest, origin: "web");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Place a delivery stop-loss order market

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
    var multiOrderRequest = new List<MultiOrderRequest> { new MultiOrderRequest(quantity: 1, product: MultiOrderRequest.ProductEnum.D, validity: MultiOrderRequest.ValidityEnum.DAY, price: 0f, instrumentToken: "NSE_EQ|INE528G01035", orderType: MultiOrderRequest.OrderTypeEnum.SLM, transactionType: MultiOrderRequest.TransactionTypeEnum.BUY, disclosedQuantity: 0, triggerPrice: 21.5f, isAmo: false, correlationId: "1") };
    var response = await apiInstance.PlaceMultiOrderAsync(multiOrderRequest, origin: "web");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Place an intraday market order

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
    var multiOrderRequest = new List<MultiOrderRequest> { new MultiOrderRequest(quantity: 1, product: MultiOrderRequest.ProductEnum.I, validity: MultiOrderRequest.ValidityEnum.DAY, price: 0f, instrumentToken: "NSE_EQ|INE528G01035", orderType: MultiOrderRequest.OrderTypeEnum.MARKET, transactionType: MultiOrderRequest.TransactionTypeEnum.BUY, disclosedQuantity: 0, triggerPrice: 0f, isAmo: false, correlationId: "1") };
    var response = await apiInstance.PlaceMultiOrderAsync(multiOrderRequest, origin: "web");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Place an intraday limit order

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
    var multiOrderRequest = new List<MultiOrderRequest> { new MultiOrderRequest(quantity: 1, product: MultiOrderRequest.ProductEnum.I, validity: MultiOrderRequest.ValidityEnum.DAY, price: 20f, instrumentToken: "NSE_EQ|INE528G01035", orderType: MultiOrderRequest.OrderTypeEnum.LIMIT, transactionType: MultiOrderRequest.TransactionTypeEnum.BUY, disclosedQuantity: 0, triggerPrice: 20.1f, isAmo: false, correlationId: "1") };
    var response = await apiInstance.PlaceMultiOrderAsync(multiOrderRequest, origin: "web");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Place an intraday stop-loss order

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
    var multiOrderRequest = new List<MultiOrderRequest> { new MultiOrderRequest(quantity: 1, product: MultiOrderRequest.ProductEnum.I, validity: MultiOrderRequest.ValidityEnum.DAY, price: 20f, instrumentToken: "NSE_EQ|INE528G01035", orderType: MultiOrderRequest.OrderTypeEnum.SL, transactionType: MultiOrderRequest.TransactionTypeEnum.BUY, disclosedQuantity: 0, triggerPrice: 19.5f, isAmo: false, correlationId: "1") };
    var response = await apiInstance.PlaceMultiOrderAsync(multiOrderRequest, origin: "web");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Place an intraday stop-loss market order

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
    var multiOrderRequest = new List<MultiOrderRequest> { new MultiOrderRequest(quantity: 1, product: MultiOrderRequest.ProductEnum.I, validity: MultiOrderRequest.ValidityEnum.DAY, price: 0f, instrumentToken: "NSE_EQ|INE528G01035", orderType: MultiOrderRequest.OrderTypeEnum.SLM, transactionType: MultiOrderRequest.TransactionTypeEnum.BUY, disclosedQuantity: 0, triggerPrice: 21.5f, isAmo: false, correlationId: "1") };
    var response = await apiInstance.PlaceMultiOrderAsync(multiOrderRequest, origin: "web");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Place a delivery market amo (after market order)

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
    var multiOrderRequest = new List<MultiOrderRequest> { new MultiOrderRequest(quantity: 1, product: MultiOrderRequest.ProductEnum.D, validity: MultiOrderRequest.ValidityEnum.DAY, price: 0f, instrumentToken: "NSE_EQ|INE528G01035", orderType: MultiOrderRequest.OrderTypeEnum.MARKET, transactionType: MultiOrderRequest.TransactionTypeEnum.BUY, disclosedQuantity: 0, triggerPrice: 0f, isAmo: true, correlationId: "1") };
    var response = await apiInstance.PlaceMultiOrderAsync(multiOrderRequest, origin: "web");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
