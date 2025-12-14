using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using UpstoxClient.Api;
using UpstoxClient.Feeder.Listener;

namespace UpstoxClient.Feeder
{
    public abstract class Feeder
    {
        protected readonly IWebsocketApi WebsocketApi;
        protected ClientWebSocket? WebSocket;

        protected IOnOpenListener? OnOpenListener;
        protected IOnMessageListener? OnMessageListener;
        protected IOnErrorListener? OnErrorListener;
        protected IOnCloseListener? OnCloseListener;

        protected Feeder(IWebsocketApi websocketApi)
        {
            WebsocketApi = websocketApi;
        }

        public abstract Task ConnectAsync(CancellationToken cancellationToken = default);

        public virtual async Task DisconnectAsync()
        {
            if (WebSocket != null)
            {
                await WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "client disconnect", CancellationToken.None)
                    .ConfigureAwait(false);
            }
        }
    }
}
