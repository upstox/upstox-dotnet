using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.WebSockets;
using UpstoxClient.Feeder.Constants;
using UpstoxClient.Feeder.Exceptions;
using Com.Upstox.Marketdatafeeder.Rpc.Proto;

namespace UpstoxClient.Feeder
{
    public class MarketDataStreamer : Streamer
    {
        public event Action<MarketUpdate> OnMarketUpdate;

        private const string SocketNotOpenError = "WebSocket is not open.";
        private const string InvalidValuesError = "Values provided are invalid.";

        private Dictionary<Mode, HashSet<string>> subscriptions = new Dictionary<Mode, HashSet<string>>();

        public MarketDataStreamer()
        {
            InitializeSubscriptions();
        }
        public MarketDataStreamer(HashSet<string> instrumentKeys, Mode mode)
        {
            InitializeSubscriptions();
            subscriptions[mode].UnionWith(instrumentKeys);
        }

        private void InitializeSubscriptions()
        {
            subscriptions.Add(Mode.Ltpc, new HashSet<string>());
            subscriptions.Add(Mode.Full, new HashSet<string>());
        }

        public override async Task Connect()
        {
            // Assuming MarketDataFeeder is already defined and implements necessary logic
            Feeder = new MarketDataFeeder(HandleOpen, HandleMessage, HandleError, HandleClose);
            await Feeder.ConnectAsync();
        }

        public override async Task Disconnect()
        {
            if (Feeder != null)
            {
                DisconnectValid = true;
                await Feeder.DisconnectAsync();
                ClearSubscriptions();
            }
            else
            {
                throw new StreamerException(SocketNotOpenError);
            }
        }

        public async Task Subscribe(HashSet<string> instrumentKeys, Mode mode)
        {
            ValidateFeeder();
            subscriptions[mode].UnionWith(instrumentKeys);

            await ((MarketDataFeeder)Feeder).SubscribeAsync(instrumentKeys, mode);
        }

        public async Task Unsubscribe(HashSet<string> instrumentKeys)
        {
            ValidateFeeder();
            foreach (var modeKeys in subscriptions.Values)
            {
                modeKeys.ExceptWith(instrumentKeys);
            }

            await ((MarketDataFeeder)Feeder).UnsubscribeAsync(instrumentKeys);
        }

        public async Task ChangeMode(HashSet<string> instrumentKeys, Mode newMode)
        {
            ValidateFeeder();
            Mode oldMode = newMode == Mode.Full ? Mode.Ltpc : Mode.Full;
            subscriptions[oldMode].ExceptWith(instrumentKeys);
            subscriptions[newMode].UnionWith(instrumentKeys);

            await ((MarketDataFeeder)Feeder).ChangeModeAsync(instrumentKeys, newMode);
        }

        private void ValidateFeeder()
        {
            if (Feeder == null || !(Feeder is MarketDataFeeder))
            {
                throw new StreamerException(SocketNotOpenError);
            }
        }

        private void ClearSubscriptions()
        {
            foreach (var modeKeys in subscriptions.Values)
            {
                modeKeys.Clear();
            }
        }

        protected override void HandleOpen()
        {
            DisconnectValid = false;
            ReconnectInProgress = false;
            ReconnectAttempts = 0;
            RaiseOnOpenEvent();
            SubscribeToInitialKeys();
        }

        private async void SubscribeToInitialKeys()
        {
            foreach (var entry in subscriptions)
            {
                if (entry.Value.Count > 0)
                {
                    await ((MarketDataFeeder)Feeder).SubscribeAsync(entry.Value, entry.Key);
                }
            }
        }

        protected void HandleMessage(byte[] data, WebSocketReceiveResult result)
        {
            try
            {
                var feedResponse = FeedResponse.Parser.ParseFrom(data, 0, result.Count);
                var jsonFormat = JsonFormatter.Default.Format(feedResponse);

                var marketUpdate = JsonConvert.DeserializeObject<MarketUpdate>(jsonFormat);

                if (OnMarketUpdate != null)
                {
                    OnMarketUpdate(marketUpdate);
                }
            }
            catch (InvalidProtocolBufferException ex)
            {
                HandleError(ex);
            }
        }
    }
}
