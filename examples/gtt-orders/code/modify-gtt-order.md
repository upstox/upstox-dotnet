## Modify Single Leg GTT Order

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
        new GttRule(strategy: GttRule.StrategyEnum.ENTRY, triggerType: GttRule.TriggerTypeEnum.ABOVE, triggerPrice: 7.3f)
    };
    var response = await apiInstance.ModifyGttOrderAsync(new GttModifyOrderRequest(id: "{gtt_order_id}", quantity: 1, rules: rules));
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Modify Multiple Leg GTT Order

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
        new GttRule(strategy: GttRule.StrategyEnum.ENTRY, triggerType: GttRule.TriggerTypeEnum.ABOVE, triggerPrice: 7.3f),
        new GttRule(strategy: GttRule.StrategyEnum.TARGET, triggerType: GttRule.TriggerTypeEnum.IMMEDIATE, triggerPrice: 7.64f),
        new GttRule(strategy: GttRule.StrategyEnum.STOPLOSS, triggerType: GttRule.TriggerTypeEnum.IMMEDIATE, triggerPrice: 7.1f)
    };
    var response = await apiInstance.ModifyGttOrderAsync(new GttModifyOrderRequest(id: "{gtt_order_id}", quantity: 1, rules: rules));
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
