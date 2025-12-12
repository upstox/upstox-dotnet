# MarketDataWebSocketService

A simple service for connecting to Upstox market data WebSocket feeds using the `MarketDataStreamerV3` class.

## Features

- **WebSocket Connection Management**: Connect and disconnect from market data feeds
- **Instrument Subscription**: Subscribe to specific instruments with different modes
- **Real-time Data**: Receive live market data updates
- **Event-driven Architecture**: Handle connection events, data updates, and errors
- **Multiple Subscription Modes**: Support for LTPC, FULL, FULL_D30, and OPTION_GREEKS modes

## Usage

### Basic Setup

```csharp
using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Test.Service;

// In your service setup
var websocketService = new MarketDataWebSocketService(services);

// Subscribe to events
websocketService.OnConnected += (sender, e) => Console.WriteLine("Connected!");
websocketService.OnMarketDataReceived += (sender, update) => {
    Console.WriteLine($"Received {update.Feeds?.Count} market updates");
};
websocketService.OnError += (sender, ex) => Console.WriteLine($"Error: {ex.Message}");
```

### Connecting and Subscribing

```csharp
// Connect to WebSocket
await websocketService.ConnectAsync();

// Subscribe to instruments
var instruments = new HashSet<string> {
    "NSE_INDEX|Nifty 50",
    "NSE_EQ|INE669E01016"  // RELIANCE
};

await websocketService.SubscribeAsync(instruments, Mode.LTPC);
```

### Subscription Modes

- **LTPC**: Last Traded Price and Quantity
- **FULL**: Complete market data including OHLC
- **FULL_D30**: Full data with 30-day history
- **OPTION_GREEKS**: Options data with Greeks calculations

### Managing Subscriptions

```csharp
// Change subscription mode
await websocketService.ChangeModeAsync(instruments, Mode.FULL);

// Unsubscribe from instruments
await websocketService.UnsubscribeAsync(instruments);

// Disconnect
await websocketService.DisconnectAsync();
```

### Complete Example

```csharp
public static async Task RunMarketDataExample(IServiceProvider services)
{
    var websocketService = new MarketDataWebSocketService(services);

    websocketService.OnMarketDataReceived += (sender, update) => {
        foreach (var feed in update.Feeds ?? new List<Feed>())
        {
            Console.WriteLine($"Symbol: {feed.Symbol}, LTP: {feed.Ltp}");
        }
    };

    try
    {
        await websocketService.ConnectAsync();

        var instruments = new HashSet<string> { "NSE_INDEX|Nifty 50" };
        await websocketService.SubscribeAsync(instruments, Mode.LTPC);

        // Keep connection alive for 30 seconds
        await Task.Delay(30000);

        await websocketService.DisconnectAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"WebSocket error: {ex.Message}");
    }
}
```

## Events

- **OnConnected**: Fired when WebSocket connection is established
- **OnDisconnected**: Fired when WebSocket connection is closed
- **OnMarketDataReceived**: Fired when market data updates are received
- **OnError**: Fired when errors occur during connection or data processing

## Error Handling

The service includes comprehensive error handling:
- Connection failures
- Subscription errors
- Data processing errors
- Network interruptions

All errors are logged to console and raised through the `OnError` event.

## Dependencies

- `IWebsocketApi`: Injected via dependency injection
- `MarketDataStreamerV3`: Core WebSocket streaming class
- `MarketUpdateV3`: Data model for market updates

## Notes

- Requires valid Upstox API authentication token
- Works in both sandbox and production environments
- Automatically handles WebSocket reconnection logic through the underlying streamer
- Thread-safe for concurrent operations