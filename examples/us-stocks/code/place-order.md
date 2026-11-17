## Place US order by quantity

Places a limit order for a quantity of shares. Fractional quantities are allowed only on fractionable stocks.

```csharp
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Extensions;
using UpstoxClient.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = Host.CreateDefaultBuilder()
    .ConfigureApi((context, services, options) =>
    {
        options.AddTokens(new OAuthToken("{your_access_token}"));
    }).Build();
await host.StartAsync();

var services = host.Services;
var apiInstance = services.GetRequiredService<IUSStocksOrderApi>();
try
{
    var response = await apiInstance.PlaceUsOrderAsync(new UsPlaceOrderRequest(
        quantity: 1.5m,
        price: 180.25m,
        validity: UsPlaceOrderRequest.ValidityEnum.DAY,
        tag: "my-tag",
        instrumentKey: "US_EQ|AAPL",
        transactionType: UsPlaceOrderRequest.TransactionTypeEnum.BUY,
        orderType: UsPlaceOrderRequest.OrderTypeEnum.LIMIT));

    Console.WriteLine($"Order id: {response.Ok()?.Data?.OrderId}");
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Place US order by amount

Places a market order sized by USD amount instead of quantity. `price` is not allowed for a market order.

```csharp
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Extensions;
using UpstoxClient.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = Host.CreateDefaultBuilder()
    .ConfigureApi((context, services, options) =>
    {
        options.AddTokens(new OAuthToken("{your_access_token}"));
    }).Build();
await host.StartAsync();

var services = host.Services;
var apiInstance = services.GetRequiredService<IUSStocksOrderApi>();
try
{
    var response = await apiInstance.PlaceUsOrderAsync(new UsPlaceOrderRequest(
        amount: 25m,
        validity: UsPlaceOrderRequest.ValidityEnum.DAY,
        instrumentKey: "US_EQ|AAPL",
        transactionType: UsPlaceOrderRequest.TransactionTypeEnum.BUY,
        orderType: UsPlaceOrderRequest.OrderTypeEnum.MARKET));

    Console.WriteLine($"Order id: {response.Ok()?.Data?.OrderId}");
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
