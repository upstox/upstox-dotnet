using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UpstoxClient.Feeder.Exceptions;
using UpstoxClient.Feeder.Constants;
using Com.Upstox.Marketdatafeeder.Rpc.Proto;

namespace UpstoxClient.Feeder
{
    public class MarketDataFeeder : Feeder
    {
        private const string WebSocketUri = "wss://api.upstox.com/v2/feed/market-data-feed";
        private const string SocketNotOpenError = "WebSocket is not open.";

        public MarketDataFeeder(Action onOpen, Action<byte[], WebSocketReceiveResult> onMessage, Action<Exception> onError, Action<int, string> onClose)
        {
            this.Configuration = UpstoxClient.Client.Configuration.Default;
            OnOpen += onOpen;
            OnBinaryMessage += onMessage;
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

                    if (result.MessageType == WebSocketMessageType.Binary && result.Count > 0)
                    {
                        RaiseOnBinaryMessageEvent(buffer, result);
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

        public async Task SubscribeAsync(HashSet<string> instrumentKeys, Mode mode)
        {
            if (WebSocket != null && WebSocket.State == WebSocketState.Open)
            {
                string request = BuildRequest(instrumentKeys, Method.Subscribe, mode);
                byte[] binaryData = Encoding.UTF8.GetBytes(request);
                await WebSocket.SendAsync(new ArraySegment<byte>(binaryData), WebSocketMessageType.Binary, true, CancellationToken.None);
            }
            else
            {
                throw new StreamerException(SocketNotOpenError);
            }
        }

        public async Task UnsubscribeAsync(HashSet<string> instrumentKeys)
        {
            if (WebSocket != null && WebSocket.State == WebSocketState.Open)
            {
                string request = BuildRequest(instrumentKeys, Method.Unsubscribe, null);
                byte[] binaryData = Encoding.UTF8.GetBytes(request);
                await WebSocket.SendAsync(new ArraySegment<byte>(binaryData), WebSocketMessageType.Binary, true, CancellationToken.None);
            }
            else
            {
                throw new StreamerException(SocketNotOpenError);
            }
        }

        public async Task ChangeModeAsync(HashSet<string> instrumentKeys, Mode newMode)
        {
            if (WebSocket != null && WebSocket.State == WebSocketState.Open)
            {
                string request = BuildRequest(instrumentKeys, Method.ChangeMode, newMode);
                byte[] binaryData = Encoding.UTF8.GetBytes(request);
                await WebSocket.SendAsync(new ArraySegment<byte>(binaryData), WebSocketMessageType.Binary, true, CancellationToken.None);
            }
            else
            {
                throw new StreamerException(SocketNotOpenError);
            }
        }

        private string BuildRequest(HashSet<string> instrumentKeys, Method method, Mode? mode)
        {
            var requestObj = new Dictionary<string, object>
            {
                { "guid", Guid.NewGuid().ToString() },
                { "method", method.GetValue() }
            };

            var dataValue = new Dictionary<string, object>();
            dataValue.Add("instrumentKeys", instrumentKeys);

            if (mode.HasValue)
            {
                string modeStr = mode.ToString().ToLower();
                if (modeStr != null)
                {
                    dataValue.Add("mode", modeStr);
                }
            }

            requestObj.Add("data", dataValue);

            return JsonConvert.SerializeObject(requestObj);
        }
    }
}
