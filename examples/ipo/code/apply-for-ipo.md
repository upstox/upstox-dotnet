## Apply for IPO

Places a real IPO application and raises a UPI mandate that must be approved in your UPI app for
the application to reach the exchange.

Notes:

- `id` is the IPO slug from the [IPO listing](get-ipo-listing.md#get-ipo-listing) or
  [IPO details](get-ipo-details.md#get-ipo-details) API.
- `upi` must be a UPI handle belonging to the authenticated account.
- `category` must be one the issue accepts — check `investors[].category` in the IPO details
  response.
- `quantity` must be a multiple of the lot size and at least `minimumQuantity`; bid at
  `cutOffPrice` to apply at cut-off. Up to 3 bids are allowed per application.
- The IPO must be inside its bidding window. An issue can be listed as `open` while still in its
  pre-apply phase, in which case the application is rejected.

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
    var bids = new List<IpoBidRequest>
    {
        new IpoBidRequest(quantity: 160, price: 93m)
    };
    var response = await apiInstance.ApplyForIpoAsync(new IpoApplyRequest(
        bids: bids,
        id: "mandb-engineering-limited-ipo",
        upi: "{your_upi_id}",
        category: IpoApplyRequest.CategoryEnum.IND));

    Console.WriteLine(response.Ok()?.Data?.OrderId);
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
