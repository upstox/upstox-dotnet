using System;
using System.Buffers;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using UpstoxClient.Api;
using UpstoxClient.Feeder.Constants;
using StreamerException = UpstoxClient.Feeder.Exception.StreamerException;
using UpstoxClient.Feeder.Listener;
using UpstoxClient.Feeder.Model;
using UpstoxClient.Model;
using UpstoxClient.Proto;

namespace UpstoxClient.Feeder
{
    public class MarketDataFeederV3 : Feeder
    {
        private const string SocketNotOpenError = "WebSocket is not open.";
        private const string InvalidValuesError = "Values provided are invalid.";

        private CancellationTokenSource? _pingCancellationSource;
        private Task? _pingTask;
        private Task? _receiveLoopTask;
        private CancellationTokenSource? _receiveLoopCts;

        public MarketDataFeederV3(IWebsocketApi websocketApi) : base(websocketApi)
        {
        }

        public void SetOnOpenListener(IOnOpenListener listener)
        {
            OnOpenListener = listener;
        }

        public void SetOnMessageListener(IOnMessageListener listener)
        {
            OnMessageListener = listener;
        }

        public void SetOnErrorListener(IOnErrorListener listener)
        {
            OnErrorListener = listener;
        }

        public void SetOnCloseListener(IOnCloseListener listener)
        {
            OnCloseListener = listener;
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
                        // Expected when cancelled
                    }
                    catch (System.Exception ex)
                    {
                        // Log but don't throw - we want cleanup to continue
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

            // Stop old ping task
            if (_pingCancellationSource != null)
            {
                _pingCancellationSource.Cancel();
                if (_pingTask != null)
                {
                    try
                    {
                        await _pingTask.ConfigureAwait(false);
                    }
                    catch (TaskCanceledException)
                    {
                        // Expected when cancelled
                    }
                    catch (System.Exception ex)
                    {
                        // Log but don't throw - we want cleanup to continue
                        if (OnErrorListener != null)
                        {
                            _ = Task.Run(() => OnErrorListener.OnErrorAsync(ex));
                        }
                    }
                }
                _pingCancellationSource?.Dispose();
                _pingCancellationSource = null;
                _pingTask = null;
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
                    // Log but don't throw - we want cleanup to continue
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

            // Start ping task to keep connection alive
            _pingCancellationSource = new CancellationTokenSource();
            _pingTask = Task.Run(() => PingLoopAsync(_pingCancellationSource.Token), _pingCancellationSource.Token);
        }

        public override async Task DisconnectAsync()
        {
            // Cancel the receive loop
            if (_receiveLoopCts != null)
            {
                _receiveLoopCts.Cancel();
            }

            // Stop ping task
            if (_pingCancellationSource != null)
            {
                _pingCancellationSource.Cancel();
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
                }
                catch (System.Exception ex)
                {
                    // Log but don't throw - we want disconnect to complete
                    if (OnErrorListener != null)
                    {
                        _ = Task.Run(() => OnErrorListener.OnErrorAsync(ex));
                    }
                }
            }

            // Wait for ping task to complete
            if (_pingTask != null)
            {
                try
                {
                    await _pingTask.ConfigureAwait(false);
                }
                catch (TaskCanceledException)
                {
                    // Expected when cancelled
                }
                catch (System.Exception ex)
                {
                    // Log but don't throw - we want disconnect to complete
                    if (OnErrorListener != null)
                    {
                        _ = Task.Run(() => OnErrorListener.OnErrorAsync(ex));
                    }
                }
            }
        }

        public async Task SubscribeAsync(ISet<string> instrumentKeys, Mode mode, CancellationToken cancellationToken = default)
        {
            if (instrumentKeys == null)
            {
                throw new StreamerException(InvalidValuesError);
            }

            await SendRequestAsync(instrumentKeys, Method.SUBSCRIBE, mode, cancellationToken).ConfigureAwait(false);
        }

        public async Task UnsubscribeAsync(ISet<string> instrumentKeys, CancellationToken cancellationToken = default)
        {
            if (instrumentKeys == null)
            {
                throw new StreamerException(InvalidValuesError);
            }

            await SendRequestAsync(instrumentKeys, Method.UNSUBSCRIBE, null, cancellationToken).ConfigureAwait(false);
        }

        public async Task ChangeModeAsync(ISet<string> instrumentKeys, Mode newMode, CancellationToken cancellationToken = default)
        {
            if (instrumentKeys == null)
            {
                throw new StreamerException(InvalidValuesError);
            }

            await SendRequestAsync(instrumentKeys, Method.CHANGE_METHOD, newMode, cancellationToken).ConfigureAwait(false);
        }

        private async Task SendRequestAsync(ISet<string> instrumentKeys, Method method, Mode? mode, CancellationToken cancellationToken)
        {
            if (WebSocket == null || WebSocket.State != WebSocketState.Open)
            {
                throw new StreamerException(SocketNotOpenError);
            }

            var requestObj = new
            {
                guid = Guid.NewGuid().ToString(),
                method = method.GetValue(),
                data = new
                {
                    instrumentKeys,
                    mode = mode?.ToString().ToLowerInvariant()
                }
            };

            var json = JsonSerializer.Serialize(requestObj);
            var binaryData = Encoding.UTF8.GetBytes(json);
            await WebSocket.SendAsync(binaryData, WebSocketMessageType.Binary, true, cancellationToken).ConfigureAwait(false);
        }

        private async Task ReceiveLoopAsync(CancellationToken cancellationToken)
        {
            if (WebSocket == null)
            {
                return;
            }

            var buffer = ArrayPool<byte>.Shared.Rent(8192);
            try
            {
                while (WebSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
                {
                    var segment = new ArraySegment<byte>(buffer);
                    WebSocketReceiveResult result;
                    try
                    {
                        result = await WebSocket.ReceiveAsync(segment, cancellationToken).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        // Cancellation requested - this is a normal disconnect
                        break;
                    }
                    catch (WebSocketException ex)
                    {
                        // WebSocket error - this is an abnormal disconnect, trigger reconnection
                        if (OnCloseListener != null)
                        {
                            await OnCloseListener.OnCloseAsync(0, $"WebSocket error: {ex.Message}").ConfigureAwait(false);
                        }
                        break;
                    }
                    catch (System.Exception ex)
                    {
                        // Other error
                        if (OnErrorListener != null)
                        {
                            await OnErrorListener.OnErrorAsync(ex).ConfigureAwait(false);
                        }
                        break;
                    }

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        if (OnCloseListener != null)
                        {
                            await OnCloseListener.OnCloseAsync((int)result.CloseStatus.GetValueOrDefault(), result.CloseStatusDescription ?? string.Empty).ConfigureAwait(false);
                        }
                        break;
                    }

                    var messageBytes = new ReadOnlyMemory<byte>(buffer, 0, result.Count);
                    if (OnMessageListener != null)
                    {
                        try
                        {
                            // Parse protobuf message
                            var feedResponse = FeedResponse.Parser.ParseFrom(messageBytes.ToArray());

                            // Convert to MarketUpdateV3
                            var marketUpdate = ConvertFeedResponseToMarketUpdateV3(feedResponse);

                            // Call listener with the converted object
                            await OnMessageListener.OnMessageAsync(marketUpdate).ConfigureAwait(false);
                        }
                        catch (System.Exception ex)
                        {
                            // If parsing fails, call error listener if available
                            if (OnErrorListener != null)
                            {
                                await OnErrorListener.OnErrorAsync(ex).ConfigureAwait(false);
                            }
                        }
                    }
                }
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        private async Task<Uri> GetAuthorizedWebSocketUriAsync(CancellationToken cancellationToken)
        {
            var response = await WebsocketApi.AuthorizeMarketDataFeedAsync(cancellationToken).ConfigureAwait(false);

            var redirectResponse = response.Ok();

            if (redirectResponse == null)
            {
                throw new StreamerException("Failed to obtain authorized websocket URI status code: " + response.StatusCode + ", message: " + response.RawContent);
            }

            if (redirectResponse?.DataOption.IsSet == true && redirectResponse.Data?.AuthorizedRedirectUri is string uri)
            {
                return new Uri(uri);
            }

            throw new StreamerException("Failed to obtain authorized websocket URI status code: " + response.StatusCode + ", message: " + response.RawContent);
        }

        private async Task PingLoopAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested && WebSocket != null && WebSocket.State == WebSocketState.Open)
                {
                    try
                    {
                        // Send ping every 30 seconds to keep connection alive
                        await Task.Delay(TimeSpan.FromSeconds(30), cancellationToken).ConfigureAwait(false);

                        if (WebSocket.State == WebSocketState.Open)
                        {
                            await WebSocket.SendAsync(new ArraySegment<byte>(Array.Empty<byte>()), WebSocketMessageType.Binary, true, cancellationToken).ConfigureAwait(false);
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (System.Exception)
                    {
                        // Don't break the loop, continue trying
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Expected when cancelled
            }
        }

        private MarketUpdateV3 ConvertFeedResponseToMarketUpdateV3(FeedResponse feedResponse)
        {
            var marketUpdate = new MarketUpdateV3
            {
                UpdateType = ConvertProtoTypeToModelType(feedResponse.Type),
                CurrentTs = feedResponse.CurrentTs,
                Feeds = new Dictionary<string, MarketUpdateV3.Feed>(),
                Info = feedResponse.MarketInfo != null ? ConvertProtoMarketInfoToModel(feedResponse.MarketInfo) : null
            };

            if (feedResponse.Feeds != null)
            {
                foreach (var feed in feedResponse.Feeds)
                {
                    marketUpdate.Feeds[feed.Key] = ConvertProtoFeedToModelFeed(feed.Value);
                }
            }

            return marketUpdate;
        }

        private MarketUpdateV3.Type ConvertProtoTypeToModelType(UpstoxClient.Proto.Type protoType)
        {
            return protoType switch
            {
                UpstoxClient.Proto.Type.InitialFeed => MarketUpdateV3.Type.initial_feed,
                UpstoxClient.Proto.Type.LiveFeed => MarketUpdateV3.Type.live_feed,
                UpstoxClient.Proto.Type.MarketInfo => MarketUpdateV3.Type.market_info,
                _ => throw new ArgumentOutOfRangeException(nameof(protoType), protoType, null)
            };
        }

        private MarketUpdateV3.Feed ConvertProtoFeedToModelFeed(UpstoxClient.Proto.Feed protoFeed)
        {
            var modelFeed = new MarketUpdateV3.Feed
            {
                Mode = ConvertProtoRequestModeToModel(protoFeed.RequestMode)
            };

            // Handle the oneof union
            switch (protoFeed.FeedUnionCase)
            {
                case UpstoxClient.Proto.Feed.FeedUnionOneofCase.Ltpc:
                    modelFeed.Ltpc = ConvertProtoLtpcToModel(protoFeed.Ltpc);
                    break;
                case UpstoxClient.Proto.Feed.FeedUnionOneofCase.FullFeed:
                    modelFeed.FullFeed = ConvertProtoFullFeedToModel(protoFeed.FullFeed);
                    break;
                case UpstoxClient.Proto.Feed.FeedUnionOneofCase.FirstLevelWithGreeks:
                    modelFeed.FirstLevelWithGreeks = ConvertProtoFirstLevelWithGreeksToModel(protoFeed.FirstLevelWithGreeks);
                    break;
            }

            return modelFeed;
        }

        private MarketUpdateV3.RequestMode ConvertProtoRequestModeToModel(UpstoxClient.Proto.RequestMode protoMode)
        {
            return protoMode switch
            {
                UpstoxClient.Proto.RequestMode.Ltpc => MarketUpdateV3.RequestMode.ltpc,
                UpstoxClient.Proto.RequestMode.FullD5 => MarketUpdateV3.RequestMode.full_d5,
                UpstoxClient.Proto.RequestMode.OptionGreeks => MarketUpdateV3.RequestMode.option_greeks,
                UpstoxClient.Proto.RequestMode.FullD30 => MarketUpdateV3.RequestMode.full_d30,
                _ => throw new ArgumentOutOfRangeException(nameof(protoMode), protoMode, null)
            };
        }

        private MarketUpdateV3.LTPC ConvertProtoLtpcToModel(UpstoxClient.Proto.LTPC protoLtpc)
        {
            return new MarketUpdateV3.LTPC
            {
                Ltp = protoLtpc.Ltp,
                Ltt = protoLtpc.Ltt,
                Ltq = protoLtpc.Ltq,
                Cp = protoLtpc.Cp
            };
        }

        private MarketUpdateV3.FullFeed ConvertProtoFullFeedToModel(UpstoxClient.Proto.FullFeed protoFullFeed)
        {
            var modelFullFeed = new MarketUpdateV3.FullFeed();

            switch (protoFullFeed.FullFeedUnionCase)
            {
                case UpstoxClient.Proto.FullFeed.FullFeedUnionOneofCase.MarketFF:
                    modelFullFeed.MarketFF = ConvertProtoMarketFullFeedToModel(protoFullFeed.MarketFF);
                    break;
                case UpstoxClient.Proto.FullFeed.FullFeedUnionOneofCase.IndexFF:
                    modelFullFeed.IndexFF = ConvertProtoIndexFullFeedToModel(protoFullFeed.IndexFF);
                    break;
            }

            return modelFullFeed;
        }

        private MarketUpdateV3.MarketFullFeed ConvertProtoMarketFullFeedToModel(UpstoxClient.Proto.MarketFullFeed protoMarketFF)
        {
            return new MarketUpdateV3.MarketFullFeed
            {
                Ltpc = protoMarketFF.Ltpc != null ? ConvertProtoLtpcToModel(protoMarketFF.Ltpc) : null,
                MarketLevel = protoMarketFF.MarketLevel != null ? ConvertProtoMarketLevelToModel(protoMarketFF.MarketLevel) : null,
                OptionGreeks = protoMarketFF.OptionGreeks != null ? ConvertProtoOptionGreeksToModel(protoMarketFF.OptionGreeks) : null,
                MarketOHLC = protoMarketFF.MarketOHLC != null ? ConvertProtoMarketOHLCToModel(protoMarketFF.MarketOHLC) : null,
                Atp = protoMarketFF.Atp,
                Vtt = protoMarketFF.Vtt,
                Oi = protoMarketFF.Oi,
                Iv = protoMarketFF.Iv,
                Tbq = protoMarketFF.Tbq,
                Tsq = protoMarketFF.Tsq
            };
        }

        private MarketUpdateV3.IndexFullFeed ConvertProtoIndexFullFeedToModel(UpstoxClient.Proto.IndexFullFeed protoIndexFF)
        {
            return new MarketUpdateV3.IndexFullFeed
            {
                Ltpc = protoIndexFF.Ltpc != null ? ConvertProtoLtpcToModel(protoIndexFF.Ltpc) : null,
                MarketOHLC = protoIndexFF.MarketOHLC != null ? ConvertProtoMarketOHLCToModel(protoIndexFF.MarketOHLC) : null
            };
        }

        private MarketUpdateV3.FirstLevelWithGreeks ConvertProtoFirstLevelWithGreeksToModel(UpstoxClient.Proto.FirstLevelWithGreeks protoFLWG)
        {
            return new MarketUpdateV3.FirstLevelWithGreeks
            {
                Ltpc = protoFLWG.Ltpc != null ? ConvertProtoLtpcToModel(protoFLWG.Ltpc) : null,
                FirstDepth = protoFLWG.FirstDepth != null ? ConvertProtoQuoteToModel(protoFLWG.FirstDepth) : null,
                OptionGreeks = protoFLWG.OptionGreeks != null ? ConvertProtoOptionGreeksToModel(protoFLWG.OptionGreeks) : null,
                Vtt = protoFLWG.Vtt,
                Oi = protoFLWG.Oi,
                Iv = protoFLWG.Iv
            };
        }

        private MarketUpdateV3.MarketLevel ConvertProtoMarketLevelToModel(UpstoxClient.Proto.MarketLevel protoMarketLevel)
        {
            var bidAskList = new List<MarketUpdateV3.Quote>();
            if (protoMarketLevel.BidAskQuote != null)
            {
                foreach (var quote in protoMarketLevel.BidAskQuote)
                {
                    bidAskList.Add(ConvertProtoQuoteToModel(quote));
                }
            }

            return new MarketUpdateV3.MarketLevel { BidAskQuote = bidAskList };
        }

        private MarketUpdateV3.MarketOHLC ConvertProtoMarketOHLCToModel(UpstoxClient.Proto.MarketOHLC protoMarketOHLC)
        {
            var ohlcList = new List<MarketUpdateV3.OHLC>();
            if (protoMarketOHLC.Ohlc != null)
            {
                foreach (var ohlc in protoMarketOHLC.Ohlc)
                {
                    ohlcList.Add(ConvertProtoOHLCToModel(ohlc));
                }
            }

            return new MarketUpdateV3.MarketOHLC { Ohlc = ohlcList };
        }

        private MarketUpdateV3.Quote ConvertProtoQuoteToModel(UpstoxClient.Proto.Quote protoQuote)
        {
            return new MarketUpdateV3.Quote
            {
                BidQ = protoQuote.BidQ,
                BidP = protoQuote.BidP,
                AskQ = protoQuote.AskQ,
                AskP = protoQuote.AskP
            };
        }

        private MarketUpdateV3.OptionGreeks ConvertProtoOptionGreeksToModel(UpstoxClient.Proto.OptionGreeks protoOptionGreeks)
        {
            return new MarketUpdateV3.OptionGreeks
            {
                Delta = protoOptionGreeks.Delta,
                Theta = protoOptionGreeks.Theta,
                Gamma = protoOptionGreeks.Gamma,
                Vega = protoOptionGreeks.Vega,
                Rho = protoOptionGreeks.Rho
            };
        }

        private MarketUpdateV3.OHLC ConvertProtoOHLCToModel(UpstoxClient.Proto.OHLC protoOHLC)
        {
            return new MarketUpdateV3.OHLC
            {
                Interval = protoOHLC.Interval,
                Open = protoOHLC.Open,
                High = protoOHLC.High,
                Low = protoOHLC.Low,
                Close = protoOHLC.Close,
                Vol = protoOHLC.Vol,
                Ts = protoOHLC.Ts
            };
        }

        private MarketUpdateV3.MarketInfo ConvertProtoMarketInfoToModel(UpstoxClient.Proto.MarketInfo protoMarketInfo)
        {
            var modelMarketInfo = new MarketUpdateV3.MarketInfo
            {
                SegmentStatus = new Dictionary<string, MarketUpdateV3.MarketStatus>()
            };

            if (protoMarketInfo.SegmentStatus != null)
            {
                foreach (var status in protoMarketInfo.SegmentStatus)
                {
                    modelMarketInfo.SegmentStatus[status.Key] = ConvertProtoMarketStatusToModel(status.Value);
                }
            }

            return modelMarketInfo;
        }

        private MarketUpdateV3.MarketStatus ConvertProtoMarketStatusToModel(UpstoxClient.Proto.MarketStatus protoStatus)
        {
            return protoStatus switch
            {
                UpstoxClient.Proto.MarketStatus.PreOpenStart => MarketUpdateV3.MarketStatus.PRE_OPEN_START,
                UpstoxClient.Proto.MarketStatus.PreOpenEnd => MarketUpdateV3.MarketStatus.PRE_OPEN_END,
                UpstoxClient.Proto.MarketStatus.NormalOpen => MarketUpdateV3.MarketStatus.NORMAL_OPEN,
                UpstoxClient.Proto.MarketStatus.NormalClose => MarketUpdateV3.MarketStatus.NORMAL_CLOSE,
                UpstoxClient.Proto.MarketStatus.ClosingStart => MarketUpdateV3.MarketStatus.CLOSING_START,
                UpstoxClient.Proto.MarketStatus.ClosingEnd => MarketUpdateV3.MarketStatus.CLOSING_END,
                _ => throw new ArgumentOutOfRangeException(nameof(protoStatus), protoStatus, null)
            };
        }
    }
}
