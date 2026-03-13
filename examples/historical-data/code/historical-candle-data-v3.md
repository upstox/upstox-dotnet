## Get data with a 1-minute interval 

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
var apiInstance = services.GetRequiredService<IHistoryV3Api>();
try
{
    var response = await apiInstance.GetHistoricalCandleDataWithFromDateAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "minutes", interval: 1, toDate: "2024-12-04", fromDate: "2024-11-28");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get data with a 3-minute interval

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
var apiInstance = services.GetRequiredService<IHistoryV3Api>();
try
{
    var response = await apiInstance.GetHistoricalCandleDataWithFromDateAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "minutes", interval: 3, toDate: "2024-12-04", fromDate: "2024-11-28");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get data with a 15-minute interval

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
var apiInstance = services.GetRequiredService<IHistoryV3Api>();
try
{
    var response = await apiInstance.GetHistoricalCandleDataWithFromDateAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "minutes", interval: 15, toDate: "2024-12-04", fromDate: "2024-11-28");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get data with a 1-hour interval

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
var apiInstance = services.GetRequiredService<IHistoryV3Api>();
try
{
    var response = await apiInstance.GetHistoricalCandleDataWithFromDateAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "hours", interval: 1, toDate: "2024-12-04", fromDate: "2024-11-28");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get data with a 4-hour interval

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
var apiInstance = services.GetRequiredService<IHistoryV3Api>();
try
{
    var response = await apiInstance.GetHistoricalCandleDataWithFromDateAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "hours", interval: 4, toDate: "2024-12-04", fromDate: "2024-11-28");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get data with a daily interval

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
var apiInstance = services.GetRequiredService<IHistoryV3Api>();
try
{
    var response = await apiInstance.GetHistoricalCandleDataWithFromDateAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "days", interval: 1, toDate: "2024-12-04", fromDate: "2024-11-28");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get data with a weekly interval

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
var apiInstance = services.GetRequiredService<IHistoryV3Api>();
try
{
    var response = await apiInstance.GetHistoricalCandleDataWithFromDateAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "weeks", interval: 1, toDate: "2024-12-04", fromDate: "2024-11-28");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get data with a monthly interval

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
var apiInstance = services.GetRequiredService<IHistoryV3Api>();
try
{
    var response = await apiInstance.GetHistoricalCandleDataWithFromDateAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "months", interval: 1, toDate: "2024-12-04", fromDate: "2024-11-28");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
