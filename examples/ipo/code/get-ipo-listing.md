## Get IPO listing

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
    var response = await apiInstance.GetIpoListingAsync();
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get IPO listing with filters

Narrow the listing by `status` and `issueType`, and page through the results. The `id` returned
for each entry is the IPO slug (for example `mandb-engineering-limited-ipo`) used by the IPO
details and apply endpoints.

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
    var response = await apiInstance.GetIpoListingAsync(status: "open", issueType: "regular", pageNumber: 1, records: 10);
    var result = response.Ok();

    if (result?.Data != null)
    {
        foreach (var ipo in result.Data)
        {
            Console.WriteLine($"{ipo.Symbol} ({ipo.Id}): {ipo.Status} " +
                              $"{ipo.BiddingStartDate} -> {ipo.BiddingEndDate}");
        }
    }
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
