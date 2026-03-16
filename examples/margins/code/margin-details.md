## Get margin details for equity delivery orders

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
var apiInstance = services.GetRequiredService<IChargeApi>();
try
{
    var response = await apiInstance.PostMarginAsync(new MarginRequest(new List<Instrument> { new Instrument(instrumentKey: "NSE_EQ|INE528G01035", quantity: 5, product: "D", transactionType: "BUY") }));
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get margin details for future delivery orders

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
var apiInstance = services.GetRequiredService<IChargeApi>();
try
{
    var response = await apiInstance.PostMarginAsync(new MarginRequest(new List<Instrument> { new Instrument(instrumentKey: "NSE_FO|35000", quantity: 5, product: "D", transactionType: "BUY") }));
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get margin details for option delivery orders

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
var apiInstance = services.GetRequiredService<IChargeApi>();
try
{
    var response = await apiInstance.PostMarginAsync(new MarginRequest(new List<Instrument> { new Instrument(instrumentKey: "NSE_FO|54524", quantity: 5, product: "D", transactionType: "BUY") }));
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get margin details for MCX delivery orders

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
var apiInstance = services.GetRequiredService<IChargeApi>();
try
{
    var response = await apiInstance.PostMarginAsync(new MarginRequest(new List<Instrument> { new Instrument(instrumentKey: "MCX_FO|435356", quantity: 5, product: "D", transactionType: "BUY") }));
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```

## Get margin details for currency delivery orders

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
var apiInstance = services.GetRequiredService<IChargeApi>();
try
{
    var response = await apiInstance.PostMarginAsync(new MarginRequest(new List<Instrument> { new Instrument(instrumentKey: "NCD_FO|15758", quantity: 5, product: "D", transactionType: "BUY") }));
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
