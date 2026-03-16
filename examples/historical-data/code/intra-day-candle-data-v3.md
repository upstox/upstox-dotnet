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
    var response = await apiInstance.GetIntraDayCandleDataAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "minutes", interval: 1);
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
    var response = await apiInstance.GetIntraDayCandleDataAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "minutes", interval: 3);
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get data with a 5-minute interval

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
    var response = await apiInstance.GetIntraDayCandleDataAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "minutes", interval: 5);
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
    var response = await apiInstance.GetIntraDayCandleDataAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "minutes", interval: 15);
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get data with a 30-minute interval

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
    var response = await apiInstance.GetIntraDayCandleDataAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "minutes", interval: 30);
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
    var response = await apiInstance.GetIntraDayCandleDataAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "hours", interval: 1);
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get data with a 2-hour interval

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
    var response = await apiInstance.GetIntraDayCandleDataAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "hours", interval: 2);
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get current day data

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
    var response = await apiInstance.GetIntraDayCandleDataAsync(instrumentKey: "NSE_EQ|INE669E01016", unit: "days", interval: 1);
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
