using System.Net.WebSockets;
using System.Text;
public class WebsocketClientExample
{
    private const string WebSocketUri = "wss://api.upstox.com/v2/feed/portfolio-stream-feed";
    private const string AccessToken = "eyJ0eXAiOiJKV1QiLCJrZXlfaWQiOiJza192MS4wIiwiYWxnIjoiSFMyNTYifQ.eyJzdWIiOiI3UEJDNkQiLCJqdGkiOiI2NWRjMjQ4NjI3ZWFkOTMzYjUzODhmYWQiLCJpc011bHRpQ2xpZW50IjpmYWxzZSwiaXNBY3RpdmUiOnRydWUsInNjb3BlIjpbImludGVyYWN0aXZlIiwiaGlzdG9yaWNhbCJdLCJpYXQiOjE3MDg5MjYwODYsImlzcyI6InVkYXBpLWdhdGV3YXktc2VydmljZSIsImV4cCI6MTcwODk4NDgwMH0.ICP337V_C5u0Mucb5EoTIeILd2oAiYfQ5Gofx8SrRr4";
    
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

            // Receive data
            await ReceiveData(webSocket);

            // Close the WebSocket connection
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
        }
    }

    static async Task ReceiveData(ClientWebSocket webSocket)
    {
        try
        {
            while (webSocket.State == WebSocketState.Open)
            {
                ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result = webSocket.ReceiveAsync(buffer, CancellationToken.None).Result;
                byte[] byteArray = new byte[buffer.Count];
                Array.Copy(buffer.Array, buffer.Offset, byteArray, 0, buffer.Count);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string message = System.Text.Encoding.UTF8.GetString(byteArray, 0, result.Count);
                    Console.WriteLine("Received: " + message);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception in ReceiveData: " + ex.Message);
        }
    }
}


