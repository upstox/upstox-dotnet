## Get trade charges for equity segment

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
var apiInstance = services.GetRequiredService<ITradeProfitAndLossApi>();
try
{
    var response = await apiInstance.GetProfitAndLossChargesAsync(segment: "EQ", financialYear: "2526", fromDate: "01-04-2025", toDate: "04-12-2025");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get trade charges for futures and options segment

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
var apiInstance = services.GetRequiredService<ITradeProfitAndLossApi>();
try
{
    var response = await apiInstance.GetProfitAndLossChargesAsync(segment: "FO", financialYear: "2526", fromDate: "01-04-2025", toDate: "04-12-2025");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
