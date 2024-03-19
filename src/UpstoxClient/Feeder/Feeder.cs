using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace UpstoxClient.Feeder
{
    public abstract class Feeder
    {
        protected UpstoxClient.Client.Configuration Configuration { get; protected set; }
        protected ClientWebSocket WebSocket { get; protected set; }

        protected event Action OnOpen;
        protected event Action<byte[], WebSocketReceiveResult> OnBinaryMessage;
        protected event Action<string> OnTextMessage;
        protected event Action<Exception> OnError;
        protected event Action<int, string> OnClose;

        public Feeder()
        {
        }
        protected void RaiseOnOpenEvent()
        {
            if (OnOpen != null)
            {
                OnOpen();
            }
        }
        protected void RaiseOnBinaryMessageEvent(byte[] message, WebSocketReceiveResult result)
        {
            if (OnBinaryMessage != null)
            {
                OnBinaryMessage(message, result);
            }
        }
        protected void RaiseOnTextMessageEvent(string message)
        {
            if (OnTextMessage != null)
            {
                OnTextMessage(message);
            }
        }
        protected void RaiseOnErrorEvent(Exception exception)
        {
            if (OnError != null)
            {
                OnError(exception);
            }
        }
        protected void RaiseOnCloseEvent(int code, string reason)
        {
            if (OnClose != null)
            {
                OnClose(code, reason);
            }
        }
        public abstract Task ConnectAsync();
        public async Task DisconnectAsync()
        {
            await WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);

            if (OnClose != null)
            {
                OnClose(1000, "User Initiated Shutdown");
            }
        }
    }
}
