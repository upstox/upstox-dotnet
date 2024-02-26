using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Com.Upstox.Marketdatafeeder.Rpc.Proto;

class WebSocketClientExample
{
    private const string WebSocketUri = "wss://api.upstox.com/v2/feed/market-data-feed";
    private const string AccessToken = <ACCESS_TOKEN>;
    static async Task Main(string[] args)
    {
        using (ClientWebSocket webSocket = new ClientWebSocket())
        {
            // Configure the WebSocket headers as needed for authorization
            webSocket.Options.SetRequestHeader("Authorization", $"Bearer {AccessToken}");

            // Connect to the WebSocket server
            Uri serverUri = new Uri(WebSocketUri);
            await webSocket.ConnectAsync(serverUri, CancellationToken.None);
            Console.WriteLine("Connected to the server");

            // Send subscription message
            await SendSubscriptionMessage(webSocket);

            // Receive data
            await ReceiveData(webSocket);

            // Close the WebSocket connection
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
        }
    }

    static async Task SendSubscriptionMessage(ClientWebSocket webSocket)
    {
        var message = new
        {
            guid = "someguid",
            method = "sub",
            data = new
            {
                mode = "full",
                instrumentKeys = new[] { "NSE_INDEX|Nifty Bank", "NSE_INDEX|Nifty 50" }
            }
        };

        string messageJson = System.Text.Json.JsonSerializer.Serialize(message);
        byte[] messageBytes = Encoding.UTF8.GetBytes(messageJson);
        await webSocket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Binary, true, CancellationToken.None);
        Console.WriteLine("Subscription message sent");
    }

    static async Task ReceiveData(ClientWebSocket webSocket)
    {
        var buffer = new byte[1024 * 4]; // Adjust the buffer size as needed

        try
        {
            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Binary && result.Count > 0)
                {
                    var feedResponse = FeedResponse.Parser.ParseFrom(buffer, 0, result.Count);
                    Console.WriteLine(feedResponse);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                    Console.WriteLine("WebSocket connection closed.");
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception in ReceiveData: " + ex.Message);
        }
    }
}
