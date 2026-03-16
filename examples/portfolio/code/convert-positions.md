## Convert a position from intraday to delivery

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
var apiInstance = services.GetRequiredService<IPortfolioApi>();
try
{
    var response = await apiInstance.ConvertPositionsAsync(new ConvertPositionRequest(instrumentToken: "NSE_EQ|INE669E01016", newProduct: ConvertPositionRequest.NewProductEnum.D, oldProduct: ConvertPositionRequest.OldProductEnum.I, transactionType: ConvertPositionRequest.TransactionTypeEnum.BUY, quantity: 1));
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Convert a position from delivery to intraday

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
var apiInstance = services.GetRequiredService<IPortfolioApi>();
try
{
    var response = await apiInstance.ConvertPositionsAsync(new ConvertPositionRequest(instrumentToken: "NSE_EQ|INE669E01016", newProduct: ConvertPositionRequest.NewProductEnum.I, oldProduct: ConvertPositionRequest.OldProductEnum.D, transactionType: ConvertPositionRequest.TransactionTypeEnum.BUY, quantity: 1));
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
