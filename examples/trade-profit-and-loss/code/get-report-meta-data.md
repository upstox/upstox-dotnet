## Get report meta data for equity segment

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
    var response = await apiInstance.GetTradeWiseProfitAndLossMetaDataAsync(segment: "EQ", financialYear: "2526");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
