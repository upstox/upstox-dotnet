## Get IPO orders

Returns the IPO applications placed from the authenticated account, most recent first. `pageNumber`
and `records` are strings for this endpoint; `records` is capped by the API, so request a modest
page size such as `"10"`.

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
    var response = await apiInstance.GetIpoOrdersAsync(pageNumber: "1", records: "10");
    var result = response.Ok();

    if (result?.Data != null)
    {
        foreach (var order in result.Data)
        {
            Console.WriteLine($"{order.Symbol} {order.OrderId}: status={order.Status} " +
                              $"payment={order.PaymentStatus}");
        }
    }

    if (result?.MetaData?.Page != null)
    {
        Console.WriteLine($"Page {result.MetaData.Page.PageNumber} of " +
                          $"{result.MetaData.Page.TotalPages} " +
                          $"({result.MetaData.Page.TotalRecords} records)");
    }
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
