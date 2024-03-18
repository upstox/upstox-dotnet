using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UpstoxClient.Feeder.Exceptions;
using UpstoxClient.Feeder.Constants;

namespace UpstoxClient.Feeder
{
    public class PortfolioDataFeeder : Feeder
    {
        private const string WebSocketUri = "wss://api.upstox.com/v2/feed/portfolio-stream-feed";
        private const string SocketNotOpenError = "WebSocket is not open.";

        public PortfolioDataFeeder(Action onOpen, Action<string> onMessage, Action<Exception> onError, Action<int, string> onClose)
        {
            this.Configuration = UpstoxClient.Client.Configuration.Default;
            OnOpen += onOpen;
            OnTextMessage += onMessage;
            OnError += onError;
            OnClose += onClose;
        }

        public override async Task ConnectAsync()
        {

            if (WebSocket != null && WebSocket.State != WebSocketState.None)
            {
                return;
            }

            using (WebSocket = new ClientWebSocket())
            {
                // Configure the WebSocket headers as needed for authorization
                WebSocket.Options.SetRequestHeader("Authorization", String.Format("Bearer {0}", this.Configuration.AccessToken));

                try
                {
                    // Connect to the WebSocket server
                    Uri serverUri = new Uri(WebSocketUri);
                    await WebSocket.ConnectAsync(serverUri, CancellationToken.None);
                    RaiseOnOpenEvent();
                    await ReceiveMessagesAsync();
                }
                catch (Exception ex)
                {
                    RaiseOnErrorEvent(ex);
                }
            }
        }

        private async Task ReceiveMessagesAsync()
        {
            var buffer = new byte[4096];

            try
            {
                while (WebSocket.State == WebSocketState.Open)
                {
                    var result = await WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        string message = System.Text.Encoding.UTF8.GetString(buffer, 0, result.Count);
                        RaiseOnTextMessageEvent(message);
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        int closeStatusCode = (int)WebSocket.CloseStatus.Value;
                        string closeStatusDescription = WebSocket.CloseStatusDescription;
                        RaiseOnCloseEvent(closeStatusCode, closeStatusDescription);
                        await WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                RaiseOnErrorEvent(ex);
            }
        }
    }
}
