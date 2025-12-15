using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using UpstoxClient.Api;
using UpstoxClient.Client;
using StreamerException = UpstoxClient.Feeder.Exception.StreamerException;
using UpstoxClient.Feeder.Listener;
using UpstoxClient.Model;
using UpstoxClient.Feeder.Model;

namespace UpstoxClient.Feeder
{
    public class PortfolioDataFeeder : Feeder
    {
        private readonly bool _orderUpdate;
        private readonly bool _holdingUpdate;
        private readonly bool _positionUpdate;
        private readonly bool _gttUpdate;

        private readonly IOnOrderUpdateListener? _onOrderUpdateListener;
        private readonly IOnHoldingUpdateListener? _onHoldingUpdateListener;
        private readonly IOnPositionUpdateListener? _onPositionUpdateListener;
        private readonly IOnGttUpdateListener? _onGttUpdateListener;
        private readonly IOnPositionMessageListener _onPositionMessageListener;
        
        private Task? _receiveLoopTask;
        private CancellationTokenSource? _receiveLoopCts;

        public PortfolioDataFeeder(
            IWebsocketApi websocketApi,
            IOnOpenListener onOpenListener,
            IOnPositionMessageListener onPositionMessageListener,
            IOnErrorListener onErrorListener,
            IOnCloseListener onCloseListener,
            bool orderUpdate,
            bool holdingUpdate,
            bool positionUpdate,
            bool gttUpdate,
            IOnOrderUpdateListener? onOrderUpdateListener,
            IOnHoldingUpdateListener? onHoldingUpdateListener,
            IOnPositionUpdateListener? onPositionUpdateListener,
            IOnGttUpdateListener? onGttUpdateListener) : base(websocketApi)
        {
            OnOpenListener = onOpenListener;
            OnErrorListener = onErrorListener;
            OnCloseListener = onCloseListener;
            _orderUpdate = orderUpdate;
            _holdingUpdate = holdingUpdate;
            _positionUpdate = positionUpdate;
            _gttUpdate = gttUpdate;
            _onOrderUpdateListener = onOrderUpdateListener;
            _onHoldingUpdateListener = onHoldingUpdateListener;
            _onPositionUpdateListener = onPositionUpdateListener;
            _onGttUpdateListener = onGttUpdateListener;
            _onPositionMessageListener = onPositionMessageListener;
        }

        public override async Task ConnectAsync(CancellationToken cancellationToken = default)
        {
            // Cancel and wait for old receive loop to complete
            if (_receiveLoopCts != null)
            {
                _receiveLoopCts.Cancel();
                if (_receiveLoopTask != null)
                {
                    try
                    {
                        await _receiveLoopTask.ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                    }
                    catch (System.Exception ex)
                    {
                        if (OnErrorListener != null)
                        {
                            _ = Task.Run(() => OnErrorListener.OnErrorAsync(ex));
                        }
                    }
                }
                _receiveLoopCts?.Dispose();
                _receiveLoopCts = null;
                _receiveLoopTask = null;
            }

            // Dispose old WebSocket if it exists to prevent resource leaks during reconnection
            if (WebSocket != null)
            {
                try
                {
                    if (WebSocket.State == WebSocketState.Open || WebSocket.State == WebSocketState.CloseReceived)
                    {
                        await WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "reconnecting", CancellationToken.None)
                            .ConfigureAwait(false);
                    }
                }
                catch (System.Exception ex)
                {
                    if (OnErrorListener != null)
                    {
                        _ = Task.Run(() => OnErrorListener.OnErrorAsync(ex));
                    }
                }
                finally
                {
                    WebSocket.Dispose();
                    WebSocket = null;
                }
            }

            var serverUri = await GetAuthorizedWebSocketUriAsync(cancellationToken).ConfigureAwait(false);

            WebSocket = new ClientWebSocket();
            await WebSocket.ConnectAsync(serverUri, cancellationToken).ConfigureAwait(false);

            if (OnOpenListener != null)
            {
                await OnOpenListener.OnOpenAsync().ConfigureAwait(false);
            }

            // Create new cancellation token source for the receive loop
            _receiveLoopCts = new CancellationTokenSource();
            _receiveLoopTask = Task.Run(() => ReceiveLoopAsync(_receiveLoopCts.Token), _receiveLoopCts.Token);
        }

        public override async Task DisconnectAsync()
        {
            // Cancel the receive loop
            if (_receiveLoopCts != null)
            {
                _receiveLoopCts.Cancel();
            }

            if (WebSocket != null && WebSocket.State == WebSocketState.Open)
            {
                await WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "client disconnect", CancellationToken.None)
                    .ConfigureAwait(false);
            }

            // Wait for receive loop to complete
            if (_receiveLoopTask != null)
            {
                try
                {
                    await _receiveLoopTask.ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    // Expected when cancelled
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Receive loop cancelled during DisconnectAsync (expected)");
                }
                catch (System.Exception ex)
                {
                    if (OnErrorListener != null)
                    {
                        _ = Task.Run(() => OnErrorListener.OnErrorAsync(ex));
                    }
                }
            }
        }

        private async Task ReceiveLoopAsync(CancellationToken cancellationToken)
        {
            if (WebSocket == null)
            {
                return;
            }

            var buffer = new byte[8192];
            var builder = new StringBuilder();

            try
            {
                while (WebSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
                {
                    builder.Clear();
                    WebSocketReceiveResult result;

                    do
                    {
                        result = await WebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken).ConfigureAwait(false);
                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            if (OnCloseListener != null)
                            {
                                await OnCloseListener.OnCloseAsync((int)result.CloseStatus.GetValueOrDefault(), result.CloseStatusDescription ?? string.Empty).ConfigureAwait(false);
                            }
                            return;
                        }

                        builder.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));
                    } while (!result.EndOfMessage);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        await HandleMessageAsync(builder.ToString()).ConfigureAwait(false);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Cancellation requested - this is a normal disconnect
                // Don't call OnCloseListener as this is handled by DisconnectAsync
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] ReceiveLoop cancelled (normal disconnect)");
            }
            catch (WebSocketException ex)
            {
                // WebSocket error - this is an abnormal disconnect, trigger reconnection
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] ReceiveLoop WebSocket error: {ex.Message}");
                if (OnCloseListener != null)
                {
                    await OnCloseListener.OnCloseAsync(0, $"WebSocket error: {ex.Message}").ConfigureAwait(false);
                }
            }
            catch (SystemException ex)
            {
                // Other error
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] ReceiveLoop unexpected error: {ex.Message}");
                if (OnErrorListener != null)
                {
                    await OnErrorListener.OnErrorAsync(ex).ConfigureAwait(false);
                }
            }
        }

        private async Task<Uri> GetAuthorizedWebSocketUriAsync(CancellationToken cancellationToken)
        {
            var updateTypes = BuildUpdateTypes();
            var response = await WebsocketApi.GetPortfolioStreamFeedAuthorizeAsync(new Option<string?>(updateTypes), cancellationToken)
                .ConfigureAwait(false);
            var redirectResponse = response.Ok();

            if (redirectResponse?.DataOption.IsSet == true && redirectResponse.Data?.AuthorizedRedirectUri is string uri)
            {
                return new Uri(uri);
            }

            throw new StreamerException("Failed to obtain authorized websocket URI");
        }

        private string BuildUpdateTypes()
        {
            var updates = new List<string>();
            if (_orderUpdate) updates.Add("order");
            if (_holdingUpdate) updates.Add("holding");
            if (_positionUpdate) updates.Add("position");
            if (_gttUpdate) updates.Add("gtt_order");

            if (updates.Count == 0)
            {
                throw new StreamerException("At least one update type must be enabled");
            }

            return string.Join(",", updates);
        }

        private async Task HandleMessageAsync(string message)
        {
            try
            {
                using var document = JsonDocument.Parse(message);
                if (!document.RootElement.TryGetProperty("update_type", out var typeElement))
                {
                    return;
                }

                var updateType = typeElement.GetString();
                switch (updateType)
                {
                    case "order":
                        if (_orderUpdate && _onOrderUpdateListener != null)
                        {
                            var order = JsonSerializer.Deserialize<OrderUpdate>(message);
                            if (order != null)
                            {
                                await _onOrderUpdateListener.OnUpdateAsync(order).ConfigureAwait(false);
                            }
                        }
                        break;
                    case "position":
                        if (_positionUpdate)
                        {
                            var position = JsonSerializer.Deserialize<PositionUpdate>(message);
                            if (position != null)
                            {
                                if (_onPositionUpdateListener != null)
                                {
                                    await _onPositionUpdateListener.OnUpdateAsync(position).ConfigureAwait(false);
                                }

                                await _onPositionMessageListener.OnMessageAsync(position).ConfigureAwait(false);
                            }
                        }
                        break;
                    case "holding":
                        if (_holdingUpdate && _onHoldingUpdateListener != null)
                        {
                            var holding = JsonSerializer.Deserialize<HoldingUpdate>(message);
                            if (holding != null)
                            {
                                await _onHoldingUpdateListener.OnUpdateAsync(holding).ConfigureAwait(false);
                            }
                        }
                        break;
                    case "gtt_order":
                        if (_gttUpdate && _onGttUpdateListener != null)
                        {
                            var gtt = JsonSerializer.Deserialize<GttUpdate>(message);
                            if (gtt != null)
                            {
                                await _onGttUpdateListener.OnUpdateAsync(gtt).ConfigureAwait(false);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (System.Exception ex)
            {
                if (OnErrorListener != null)
                {
                    await OnErrorListener.OnErrorAsync(ex).ConfigureAwait(false);
                }
            }
        }
    }
}
