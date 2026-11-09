## Get US funds

Returns the US trading account balance in USD and INR.

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
var apiInstance = services.GetRequiredService<IUSStocksFundsApi>();
try
{
    var response = await apiInstance.GetUsFundsAsync();
    var data = response.Ok()?.Data;
    Console.WriteLine($"Available to trade: ${data?.AvailableToTrade} (INR {data?.AvailableToTradeInr}), " +
                      $"exchange rate: {data?.ExchangeRate}");
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
