## Cancel US order

Cancels an open US order.

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
    var response = await apiInstance.CancelUsOrderAsync("{your_order_id}");
    Console.WriteLine($"Cancelled order id: {response.Ok()?.Data?.OrderId}");
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
