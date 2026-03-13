## Modify a delivery order

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
var apiInstance = services.GetRequiredService<IOrderV3Api>();
try
{
    var response = await apiInstance.ModifyOrderAsync(new ModifyOrderV3Request(orderId: "{order_id}", quantity: 1, validity: ModifyOrderV3Request.ValidityEnum.DAY, price: 0f, orderType: ModifyOrderV3Request.OrderTypeEnum.MARKET, disclosedQuantity: 0, triggerPrice: 0f));
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
