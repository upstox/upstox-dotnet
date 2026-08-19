## Cancel IPO order

Withdraws an IPO application and releases the associated UPI mandate. Only applications that have
not yet been processed by the exchange can be cancelled; the bidding window must still be open.

After a successful call the application moves to `application_deleted` and
`cancelRequestedDate`/`cancelAcceptedDate` are populated — confirm with
[Get IPO order details](get-ipo-order-details.md#get-ipo-order-details).

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
var apiInstance = services.GetRequiredService<IIPOApi>();
try
{
    var response = await apiInstance.CancelIpoOrderAsync(orderId: "{your_ipo_order_id}");
    var result = response.Ok();

    Console.WriteLine($"{result?.Data?.OrderId}: {result?.Data?.Status}");
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
