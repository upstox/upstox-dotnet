# Market Stream Feed WebSocket Client

This .NET project demonstrates how to connect to the Upstox WebSocket API for streaming live market data. It fetches market data for a list of instrument keys. When the client receives updates from the server, it decodes the incoming protobuf data into a `FeedResponse` object.

## Getting Started

These instructions will help you run the sample v3 WebSocket client.

### Prerequisites

Before you can run this script, you need to have .NET 6.0 or later installed on your system. If you haven't installed .NET yet, you can download it from the official website:

[Download .NET](https://dotnet.microsoft.com/download)

You will also need to add several dependencies to your project, which are listed in the `.csproj` file provided:

- `Google.Protobuf`
- `System.Net.WebSockets.Client`

### Package References

Include these package references in your `.csproj` file.

```xml
<ItemGroup>
  <PackageReference Include="Google.Protobuf" Version="3.25.3" />
  <PackageReference Include="System.Net.WebSockets.Client" Version="4.3.2" />
</ItemGroup>
```

### Configuration

The script requires an Upstox API access token for authorization. You will need to specify your Upstox API access token in the Program.cs. Replace "YOUR_ACCESS_TOKEN" with your actual access token.

### Running the Script

After installing the prerequisites and setting up your access token, you can run the script using the .NET CLI or your preferred IDE.

To run the script, navigate to the project directory and use the following command:

```
dotnet run
```

## Understanding the Code

The application connects to the WebSocket server using the specified URI and access token for authorization. It sends a subscription request for "NSE_INDEX|Nifty Bank" and "NSE_INDEX|Nifty 50". Upon receiving data from the server, it decodes the protobuf data into a FeedResponse object, and prints the data to the console.

## Support

If you encounter any problems or have any questions about this project, feel free to open an issue in this repository.

## Disclaimer

This is a sample script meant for educational purposes. It may require modifications to work with your specific requirements.

Make sure to replace any placeholders (like `<ACCESS_TOKEN>`) with your actual data before using this guide.
