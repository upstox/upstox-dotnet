## Get US market holidays

Returns the US market holidays for the current year.

```csharp
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Extensions;
using UpstoxClient.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = Host.CreateDefaultBuilder()
    .ConfigureApi((context, services, options) =>
    {
        options.AddTokens(new OAuthToken("{your_access_token}"));
    }).Build();
await host.StartAsync();

var services = host.Services;
var apiInstance = services.GetRequiredService<IUSMarketHolidaysAndTimingsApi>();
try
{
    var response = await apiInstance.GetUsHolidaysAsync();
    foreach (var holiday in response.Ok()?.Data ?? new List<UsHolidayData>())
    {
        Console.WriteLine($"{holiday.Date} {holiday.Description} ({holiday.HolidayType})");
    }
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get US market holiday for a date

Returns holiday details for a specific date (`yyyy-MM-dd`); empty when it is not a holiday.

```csharp
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Extensions;
using UpstoxClient.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = Host.CreateDefaultBuilder()
    .ConfigureApi((context, services, options) =>
    {
        options.AddTokens(new OAuthToken("{your_access_token}"));
    }).Build();
await host.StartAsync();

var services = host.Services;
var apiInstance = services.GetRequiredService<IUSMarketHolidaysAndTimingsApi>();
try
{
    var response = await apiInstance.GetUsHolidayAsync("2026-11-26");
    foreach (var holiday in response.Ok()?.Data ?? new List<UsHolidayData>())
    {
        Console.WriteLine($"{holiday.Date} {holiday.Description} ({holiday.HolidayType})");
    }
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get US market timings

Returns US exchange session timings (epoch millis) for a date (`yyyy-MM-dd`).

```csharp
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Extensions;
using UpstoxClient.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = Host.CreateDefaultBuilder()
    .ConfigureApi((context, services, options) =>
    {
        options.AddTokens(new OAuthToken("{your_access_token}"));
    }).Build();
await host.StartAsync();

var services = host.Services;
var apiInstance = services.GetRequiredService<IUSMarketHolidaysAndTimingsApi>();
try
{
    var response = await apiInstance.GetUsExchangeTimingsAsync("2026-10-29");
    foreach (var timing in response.Ok()?.Data ?? new List<UsExchangeTimingData>())
    {
        Console.WriteLine($"{timing.Exchange}: {timing.StartTime} - {timing.EndTime} " +
                          $"(overnight {timing.OvernightStartTime} - {timing.OvernightEndTime})");
    }
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get US market status

Returns the live status of the US market.

```csharp
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Extensions;
using UpstoxClient.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = Host.CreateDefaultBuilder()
    .ConfigureApi((context, services, options) =>
    {
        options.AddTokens(new OAuthToken("{your_access_token}"));
    }).Build();
await host.StartAsync();

var services = host.Services;
var apiInstance = services.GetRequiredService<IUSMarketHolidaysAndTimingsApi>();
try
{
    var response = await apiInstance.GetUsMarketStatusAsync();
    var data = response.Ok()?.Data;
    Console.WriteLine($"{data?.Exchange}: {data?.Status} (updated {data?.LastUpdated})");
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
