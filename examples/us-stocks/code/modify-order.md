## Modify US order

Modifies the quantity or limit price of an open US order.

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
    var response = await apiInstance.ModifyUsOrderAsync(new UsModifyOrderRequest(
        quantity: 2m,
        price: 179.5m,
        validity: UsModifyOrderRequest.ValidityEnum.DAY,
        orderId: "{your_order_id}",
        instrumentKey: "US_EQ|AAPL",
        transactionType: UsModifyOrderRequest.TransactionTypeEnum.BUY,
        orderType: UsModifyOrderRequest.OrderTypeEnum.LIMIT));

    Console.WriteLine($"Order id: {response.Ok()?.Data?.OrderId}");
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
