
# Portfolio Stream Feed WebSocket Client

This .NET project demonstrates how to connect to the Upstox WebSocket API for streaming live order updates. It fetches the order updates and prints them to the console.

## Getting Started

These instructions will help you run the sample WebSocket client.

### Prerequisites

Before you can run this script, you need to have .NET Core 3.1 or later installed on your system.

You will also need to add several dependencies to your project, including `System.Net.WebSockets.Client` for WebSocket support.

#### Package References

Add these package references to your `.csproj` file.

```xml
<ItemGroup>
  <PackageReference Include="System.Net.WebSockets.Client" Version="4.3.2" />
</ItemGroup>
```

### Configuration

The script requires an Upstox API access token for authorization. You will need to specify your Upstox API access token in the WebSocketClientExample class. Look for the line below and replace `<ACCESS_TOKEN>` with your actual access token.

```csharp
private const string AccessToken = "<ACCESS_TOKEN>";
```

### Running the Script

After installing the prerequisites and setting up your access token, you can run the script. Use your preferred IDE or the command line to run the .NET project.

## Understanding the Code

The script first sets up a `ClientWebSocket` instance and configures the WebSocket headers for authorization with the access token. It then connects to the WebSocket server at the specified URI.

Once connected, the script enters a loop to receive data continuously until the WebSocket is closed. It prints each received message to the console.

## Support

If you encounter any problems or have any questions about this project, feel free to open an issue in this repository.

## Disclaimer

This is a sample script meant for educational purposes. It may require modifications to work with your specific requirements.

Please replace `<ACCESS_TOKEN>` with your actual access token. Modify any other details as needed to fit your project.
