## Get IPO details

Pass the IPO slug returned as `id` by the [IPO listing](get-ipo-listing.md#get-ipo-listing) API.
The response carries the values needed to place an application — `lotSize`, `minimumQuantity`,
`cutOffPrice`, the bidding window, and the investor categories the issue accepts.

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
    var response = await apiInstance.GetIpoDetailsAsync(id: "mandb-engineering-limited-ipo");
    var result = response.Ok();

    if (result?.Data != null)
    {
        var ipo = result.Data;
        Console.WriteLine($"{ipo.Name} ({ipo.Symbol})");
        Console.WriteLine($"  Status: {ipo.Status}");
        Console.WriteLine($"  Price band: {ipo.MinimumPrice} - {ipo.MaximumPrice}");
        Console.WriteLine($"  Cut-off price: {ipo.CutOffPrice}");
        Console.WriteLine($"  Lot size: {ipo.LotSize}, minimum quantity: {ipo.MinimumQuantity}");
        Console.WriteLine($"  Bidding: {ipo.BiddingStartDate} -> {ipo.BiddingEndDate} " +
                          $"({ipo.DailyStartTime} - {ipo.DailyEndTime})");

        if (ipo.Investors != null)
        {
            foreach (var investor in ipo.Investors)
                Console.WriteLine($"  Accepts category: {investor?.Category}");
        }
    }
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
