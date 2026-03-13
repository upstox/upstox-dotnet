## Place Single Leg GTT Order

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
    var rules = new List<GttRule>
    {
        new GttRule(strategy: GttRule.StrategyEnum.ENTRY, triggerType: GttRule.TriggerTypeEnum.ABOVE, triggerPrice: 7f)
    };
    var response = await apiInstance.PlaceGttOrderAsync(new GttPlaceOrderRequest(type: GttPlaceOrderRequest.TypeEnum.SINGLE, instrumentToken: "NSE_EQ|INE669E01016", product: GttPlaceOrderRequest.ProductEnum.D, quantity: 1, rules: rules, transactionType: GttPlaceOrderRequest.TransactionTypeEnum.BUY));
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Place Multiple Leg GTT Order

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
    var rules = new List<GttRule>
    {
        new GttRule(strategy: GttRule.StrategyEnum.ENTRY, triggerType: GttRule.TriggerTypeEnum.ABOVE, triggerPrice: 7f),
        new GttRule(strategy: GttRule.StrategyEnum.TARGET, triggerType: GttRule.TriggerTypeEnum.IMMEDIATE, triggerPrice: 9f),
        new GttRule(strategy: GttRule.StrategyEnum.STOPLOSS, triggerType: GttRule.TriggerTypeEnum.IMMEDIATE, triggerPrice: 5f)
    };
    var response = await apiInstance.PlaceGttOrderAsync(new GttPlaceOrderRequest(type: GttPlaceOrderRequest.TypeEnum.MULTIPLE, instrumentToken: "NSE_EQ|INE669E01016", product: GttPlaceOrderRequest.ProductEnum.D, quantity: 1, rules: rules, transactionType: GttPlaceOrderRequest.TransactionTypeEnum.BUY));
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
