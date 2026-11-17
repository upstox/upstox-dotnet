## Get US margin

Calculates the margin required for one or more prospective US orders.

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
var apiInstance = services.GetRequiredService<IUSStocksChargesApi>();
try
{
    var instruments = new List<UsOrderEstimateRequest>
    {
        new UsOrderEstimateRequest(
            quantity: 1m,
            price: 180m,
            instrumentKey: "US_EQ|AAPL",
            transactionType: UsOrderEstimateRequest.TransactionTypeEnum.BUY,
            orderType: UsOrderEstimateRequest.OrderTypeEnum.LIMIT)
    };
    var response = await apiInstance.CalculateUsMarginAsync(new UsMarginRequest(instruments));

    var data = response.Ok()?.Data;
    Console.WriteLine($"Required: {data?.RequiredMargin}, available: {data?.AvailableToInvest}, " +
                      $"sufficient: {data?.Sufficient}");
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
