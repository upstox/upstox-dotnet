## Get US order details

Returns the latest state of a single US order.

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
    var response = await apiInstance.GetUsOrderDetailsAsync("{your_order_id}");
    var order = response.Ok()?.Data;
    Console.WriteLine($"{order?.OrderId} status={order?.Status} avgPrice={order?.AveragePrice} " +
                      $"message={order?.StatusMessage}");
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
