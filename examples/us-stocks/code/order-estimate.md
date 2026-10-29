## Get US order estimate

Returns the charges breakdown and estimated total for a prospective US order.

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
    var response = await apiInstance.EstimateUsOrderAsync(new UsOrderEstimateRequest(
        quantity: 1m,
        price: 180m,
        instrumentKey: "US_EQ|AAPL",
        transactionType: UsOrderEstimateRequest.TransactionTypeEnum.BUY,
        orderType: UsOrderEstimateRequest.OrderTypeEnum.LIMIT));

    var data = response.Ok()?.Data;
    Console.WriteLine($"Trade value: {data?.TradeValue}, charges: {data?.TotalCharges}, " +
                      $"estimated total: {data?.EstimatedTotal}");
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
