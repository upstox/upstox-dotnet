## Get US holdings

Returns the US stock holdings of the account.

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
var apiInstance = services.GetRequiredService<IUSStocksPortfolioApi>();
try
{
    var response = await apiInstance.GetUsHoldingsAsync();
    foreach (var holding in response.Ok()?.Data ?? new List<UsHoldingData>())
    {
        Console.WriteLine($"{holding.TradingSymbol} qty={holding.Quantity} avg={holding.AveragePrice} " +
                          $"ltp={holding.LastPrice} pnl={holding.Pnl}");
    }
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
