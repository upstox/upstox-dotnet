## Get IPO order details

Fetches a single IPO application by the `orderId` returned from
[Apply for IPO](apply-for-ipo.md#apply-for-ipo) or
[Get IPO orders](get-ipo-orders.md#get-ipo-orders).

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
    var response = await apiInstance.GetIpoOrderByIdAsync(orderId: "{your_ipo_order_id}");
    var result = response.Ok();

    if (result?.Data != null)
    {
        var order = result.Data;
        Console.WriteLine($"{order.Symbol} {order.OrderId} ({order.Exchange})");
        Console.WriteLine($"  Status: {order.Status}");
        Console.WriteLine($"  Order status: {order.OrderStatus}");
        Console.WriteLine($"  Payment status: {order.PaymentStatus}");
        Console.WriteLine($"  UPI: {order.Upi}, amount blocked: {order.UpiAmountBlocked}");
        Console.WriteLine($"  Units allotted: {order.UnitsAllotted}");

        if (order.Bids != null)
        {
            foreach (var bid in order.Bids)
                Console.WriteLine($"  Bid: {bid?.Quantity} x {bid?.Price} = {bid?.Amount} ({bid?.Message})");
        }
    }
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
