
# .NET Sample Implementation

## WebSocket

### Market Stream Feed

.NET code to connect to the Upstox WebSocket API for streaming live market data. This implementation utilizes the `System.Net.WebSockets.ClientWebSocket` class to establish a WebSocket connection. It demonstrates how to authenticate, subscribe to market data streams, and handle incoming data by decoding the protobuf messages into meaningful structures.

[Market updates using Upstox's WebSocket](websocket/market_data/)

### Portfolio Stream Feed

.NET code to connect to the Upstox WebSocket API for streaming live order updates. Similar to the market stream feed implementation, this code uses the `System.Net.WebSockets.ClientWebSocket` class for WebSocket communication, focusing on receiving and processing portfolio stream feed data.

[Order updates using Upstox's WebSocket](websocket/order_updates/)
