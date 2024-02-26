
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;
using System.Net.WebSockets;
namespace Example
{
    public class Example
    {
        public static void Main(string[] args)
        {
        Configuration.Default.AccessToken = "eyJ0eXAiOiJKV1QiLCJrZXlfaWQiOiJza192MS4wIiwiYWxnIjoiSFMyNTYifQ.eyJzdWIiOiI3UEJDNkQiLCJqdGkiOiI2NWQ5ZmM3YTI3ZWFkOTMzYjUzODZjYTUiLCJpc011bHRpQ2xpZW50IjpmYWxzZSwiaXNBY3RpdmUiOnRydWUsInNjb3BlIjpbImludGVyYWN0aXZlIiwiaGlzdG9yaWNhbCJdLCJpYXQiOjE3MDg3ODQ3NjIsImlzcyI6InVkYXBpLWdhdGV3YXktc2VydmljZSIsImV4cCI6MTcwODgxMjAwMH0.Fqhwz87ltH26Q_2hBcyuo53F6keWDVOL5PSLXdDUAtI";
        
        WebFun().GetAwaiter().GetResult();

        }
        public static async Task WebFun()
        {
            var apiInstance = new WebsocketApi();
            try
            {
                WebsocketAuthRedirectResponse result = apiInstance.GetPortfolioStreamFeedAuthorize("2.0");

                String u = result.Data.AuthorizedRedirectUri;
                try
                {
                    // Connect to the WebSocket server
                    ClientWebSocket webSocket = new ClientWebSocket();
                    try{
                        await webSocket.ConnectAsync(new Uri(u), CancellationToken.None);
                    }
                    catch (Exception e){
                        Console.WriteLine("got exception= " + e);
                    }
                    // Start receiving messages in a loop
                    while (webSocket.State == WebSocketState.Open)
                    {
                        ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
                        WebSocketReceiveResult result1 = webSocket.ReceiveAsync(buffer, CancellationToken.None).Result;
                        byte[] byteArray = new byte[buffer.Count];
                        Array.Copy(buffer.Array, buffer.Offset, byteArray, 0, buffer.Count);

                        if (result1.MessageType == WebSocketMessageType.Text)
                        {
                            string message = System.Text.Encoding.UTF8.GetString(byteArray, 0, result1.Count);
                            Console.WriteLine("Received: " + message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("in catch");
                    Console.WriteLine("WebSocket error: " + ex);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception when calling WebsocketApi.GetPortfolioStreamFeed: " + e);
            }
        }
    }
}

