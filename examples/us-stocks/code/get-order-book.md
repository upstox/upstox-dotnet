## Get US order book

Returns all US orders placed for the day.

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
    var response = await apiInstance.GetUsOrderBookAsync();
    foreach (var order in response.Ok()?.Data ?? new List<UsOrderBookData>())
    {
        Console.WriteLine($"{order.OrderId} {order.TradingSymbol} {order.TransactionType} " +
                          $"qty={order.Quantity} filled={order.FilledQuantity} status={order.Status}");
    }
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
