## Get full market quote

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
var apiInstance = services.GetRequiredService<IMarketQuoteV3Api>();
try
{
    var response = await apiInstance.GetFullMarketQuoteV3Async(instrumentKey: "NSE_EQ|INE669E01016");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get full market quote for multiple instrument keys

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
var apiInstance = services.GetRequiredService<IMarketQuoteV3Api>();
try
{
    var response = await apiInstance.GetFullMarketQuoteV3Async(instrumentKey: "NSE_EQ|INE669E01016,NSE_EQ|INE848E01016");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Read fields from the full market quote response

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
var apiInstance = services.GetRequiredService<IMarketQuoteV3Api>();
try
{
    var response = await apiInstance.GetFullMarketQuoteV3Async(instrumentKey: "NSE_EQ|INE848E01016");
    var result = response.Ok();

    // result.Data is a dictionary keyed by "<exchange>:<trading_symbol>"
    foreach (var entry in result?.Data ?? new())
    {
        var quote = entry.Value;
        Console.WriteLine(entry.Key);
        Console.WriteLine($"  Symbol                : {quote?.Symbol}");
        Console.WriteLine($"  InstrumentToken       : {quote?.InstrumentToken}");
        Console.WriteLine($"  LastPrice             : {quote?.LastPrice}");
        Console.WriteLine($"  Volume                : {quote?.Volume}");
        Console.WriteLine($"  AveragePrice          : {quote?.AveragePrice}");
        Console.WriteLine($"  NetChange             : {quote?.NetChange}");
        Console.WriteLine($"  PrevClosePrice        : {quote?.PrevClosePrice}");
        Console.WriteLine($"  LowerCircuitLimit     : {quote?.LowerCircuitLimit}");
        Console.WriteLine($"  UpperCircuitLimit     : {quote?.UpperCircuitLimit}");
        Console.WriteLine($"  YearHigh / YearLow    : {quote?.YearHigh} / {quote?.YearLow}");
        Console.WriteLine($"  Oi / PreviousOi       : {quote?.Oi} / {quote?.PreviousOi}");
        Console.WriteLine($"  CasEligible           : {quote?.CasEligible}");

        // Nested OHLC snapshot
        Console.WriteLine($"  Ohlc                  : {quote?.Ohlc?.Open} {quote?.Ohlc?.High} {quote?.Ohlc?.Low} {quote?.Ohlc?.Close}");

        // Nested market depth (top 5 bids and asks)
        foreach (var level in quote?.Depth?.Buy ?? new())
            Console.WriteLine($"  bid: {level?.Price} {level?.Quantity} {level?.Orders}");
        foreach (var level in quote?.Depth?.Sell ?? new())
            Console.WriteLine($"  ask: {level?.Price} {level?.Quantity} {level?.Orders}");
    }
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
