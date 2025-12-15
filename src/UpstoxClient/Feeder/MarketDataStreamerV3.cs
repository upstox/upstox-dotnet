using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using UpstoxClient.Api;
using UpstoxClient.Feeder.Constants;
using StreamerException = UpstoxClient.Feeder.Exception.StreamerException;
using UpstoxClient.Feeder.Listener;
using UpstoxClient.Feeder.Model;
using UpstoxClient.Proto;

namespace UpstoxClient.Feeder
{
    public class MarketDataStreamerV3 : Streamer
    {
        private const string SocketNotOpenError = "WebSocket is not open.";
        private const string InvalidValuesError = "Values provided are invalid.";

        private readonly IWebsocketApi _websocketApi;
        private IOnMarketUpdateV3Listener? _onMarketUpdateListener;
        private IOnOpenListener? _onOpenListener;
        private Dictionary<Mode, HashSet<string>> _subscriptions;

        public MarketDataStreamerV3(IWebsocketApi websocketApi)
        {
            _websocketApi = websocketApi ?? throw new StreamerException(InvalidValuesError);
            _subscriptions = InitializeSubscriptionMap();
        }

        public MarketDataStreamerV3(IWebsocketApi websocketApi, ISet<string> instrumentKeys, Mode mode)
        {
            if (websocketApi == null || instrumentKeys == null)
            {
                throw new StreamerException(InvalidValuesError);
            }

            _websocketApi = websocketApi;
            _subscriptions = InitializeSubscriptionMap();
            _subscriptions[mode].UnionWith(instrumentKeys);
        }

        public void SetOnMarketUpdateListener(IOnMarketUpdateV3Listener listener)
        {
            _onMarketUpdateListener = listener;
        }

        public void SetOnOpenListener(IOnOpenListener listener)
        {
            _onOpenListener = listener;
        }

        public override async Task ConnectAsync(CancellationToken cancellationToken = default)
        {
            Feeder = new MarketDataFeederV3(_websocketApi);

            // Set up listeners - Use CancellationToken.None in closures to avoid capturing the token that may be cancelled
            ((MarketDataFeederV3)Feeder).SetOnOpenListener(new OpenListener(async () => await HandleOpenAsync().ConfigureAwait(false)));
            ((MarketDataFeederV3)Feeder).SetOnMessageListener(new MessageListener(
                async update => await HandleMessageAsync(update).ConfigureAwait(false)));
            ((MarketDataFeederV3)Feeder).SetOnErrorListener(new ErrorListener(async ex => await HandleErrorAsync(ex, CancellationToken.None).ConfigureAwait(false)));
            ((MarketDataFeederV3)Feeder).SetOnCloseListener(new CloseListener(async (code, reason) => await HandleCloseAsync(code, reason, CancellationToken.None).ConfigureAwait(false)));

            await Feeder.ConnectAsync(cancellationToken).ConfigureAwait(false);
        }

        public override async Task DisconnectAsync(CancellationToken cancellationToken = default)
        {
            if (Feeder == null)
            {
                throw new StreamerException(SocketNotOpenError);
            }

            // Set flag to prevent auto-reconnection on intentional disconnect
            DisconnectValid = true;
            await Feeder.DisconnectAsync().ConfigureAwait(false);
            ClearSubscriptions();
        }

        public async Task SubscribeAsync(ISet<string> instrumentKeys, Mode mode, CancellationToken cancellationToken = default)
        {
            if (instrumentKeys == null)
            {
                await HandleErrorAsync(new StreamerException(InvalidValuesError), cancellationToken).ConfigureAwait(false);
                return;
            }

            if (Feeder is not MarketDataFeederV3 marketDataFeeder)
            {
                throw new StreamerException(SocketNotOpenError);
            }

            _subscriptions[mode].UnionWith(instrumentKeys);
            await marketDataFeeder.SubscribeAsync(instrumentKeys, mode, cancellationToken).ConfigureAwait(false);
        }

        public async Task UnsubscribeAsync(ISet<string> instrumentKeys, CancellationToken cancellationToken = default)
        {
            if (instrumentKeys == null)
            {
                await HandleErrorAsync(new StreamerException(InvalidValuesError), cancellationToken).ConfigureAwait(false);
                return;
            }

            if (Feeder is not MarketDataFeederV3 marketDataFeeder)
            {
                throw new StreamerException(SocketNotOpenError);
            }

            foreach (var entry in _subscriptions.Values)
            {
                entry.ExceptWith(instrumentKeys);
            }

            await marketDataFeeder.UnsubscribeAsync(instrumentKeys, cancellationToken).ConfigureAwait(false);
        }

        public async Task ChangeModeAsync(ISet<string> instrumentKeys, Mode newMode, CancellationToken cancellationToken = default)
        {
            if (instrumentKeys == null)
            {
                await HandleErrorAsync(new StreamerException(InvalidValuesError), cancellationToken).ConfigureAwait(false);
                return;
            }

            if (Feeder is not MarketDataFeederV3 marketDataFeeder)
            {
                throw new StreamerException(SocketNotOpenError);
            }

            foreach (var entry in _subscriptions.Values)
            {
                entry.ExceptWith(instrumentKeys);
            }

            _subscriptions[newMode].UnionWith(instrumentKeys);

            await marketDataFeeder.ChangeModeAsync(instrumentKeys, newMode, cancellationToken).ConfigureAwait(false);
        }

        private Dictionary<Mode, HashSet<string>> InitializeSubscriptionMap()
        {
            return new Dictionary<Mode, HashSet<string>>
            {
                { Mode.LTPC, new HashSet<string>() },
                { Mode.FULL, new HashSet<string>() },
                { Mode.FULL_D30, new HashSet<string>() },
                { Mode.OPTION_GREEKS, new HashSet<string>() }
            };
        }

        private async Task HandleMessageAsync(MarketUpdateV3 marketUpdate)
        {
            try
            {
                if (marketUpdate != null && _onMarketUpdateListener != null)
                {
                    await _onMarketUpdateListener.OnUpdateAsync(marketUpdate).ConfigureAwait(false);
                }
            }
            catch (System.Exception ex)
            {
                await HandleErrorAsync(ex).ConfigureAwait(false);
            }
        }

        protected override async Task HandleOpenAsync()
        {
            await base.HandleOpenAsync().ConfigureAwait(false);

            if (_onOpenListener != null)
            {
                await _onOpenListener.OnOpenAsync().ConfigureAwait(false);
            }

            await SubscribeToInitialKeysAsync().ConfigureAwait(false);
        }

        private async Task SubscribeToInitialKeysAsync()
        {
            if (Feeder is not MarketDataFeederV3 marketDataFeeder)
            {
                return;
            }

            foreach (var entry in _subscriptions)
            {
                if (entry.Value.Count == 0)
                {
                    continue;
                }

                await marketDataFeeder.SubscribeAsync(entry.Value, entry.Key).ConfigureAwait(false);
            }
        }

        private void ClearSubscriptions()
        {
            foreach (var entry in _subscriptions.Values)
            {
                entry.Clear();
            }
        }

        private sealed class OpenListener : IOnOpenListener
        {
            private readonly Func<Task> _handler;
            public OpenListener(Func<Task> handler) => _handler = handler;
            public Task OnOpenAsync() => _handler();
        }

        private sealed class MessageListener : IOnMessageListener
        {
            private readonly Func<MarketUpdateV3, Task> _onUpdate;

            public MessageListener(Func<MarketUpdateV3, Task> onUpdate)
            {
                _onUpdate = onUpdate;
            }

            public Task OnMessageAsync(MarketUpdateV3 update) => _onUpdate(update);
        }

        private sealed class ErrorListener : IOnErrorListener
        {
            private readonly Func<System.Exception, Task> _handler;
            public ErrorListener(Func<System.Exception, Task> handler) => _handler = handler;
            public Task OnErrorAsync(System.Exception error) => _handler(error);
        }

        private sealed class CloseListener : IOnCloseListener
        {
            private readonly Func<int, string, Task> _handler;
            public CloseListener(Func<int, string, Task> handler) => _handler = handler;
            public Task OnCloseAsync(int statusCode, string reason) => _handler(statusCode, reason);
        }
    }
}
