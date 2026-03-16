## Access token request

```csharp
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var host = Host.CreateDefaultBuilder()
    .ConfigureApi((context, services, options) =>
    {
    }).Build();
await host.StartAsync();

var services = host.Services;
var apiInstance = services.GetRequiredService<ILoginApi>();
try
{
    var response = await apiInstance.InitTokenRequestForIndieUserAsync(new IndieUserTokenRequest(clientSecret: "{client_secret}"), clientId: "{client_id}");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
