## Get access token using auth code

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
    var response = await apiInstance.TokenAsync(code: "{authorization_code}", clientId: "{client_id}", clientSecret: "{client_secret}", redirectUri: "{redirect_uri}", grantType: "authorization_code");
    Console.WriteLine(response.Ok());
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
await host.StopAsync();
```
