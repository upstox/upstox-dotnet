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
    public class PortfolioDataStreamer : Streamer
    {
        public event Action<OrderUpdate> OnOrderUpdate;

        private const string SocketNotOpenError = "WebSocket is not open.";

        public PortfolioDataStreamer()
        {
        }

        public override async Task Connect()
        {
            // Assuming MarketDataFeeder is already defined and implements necessary logic
            Feeder = new PortfolioDataFeeder(HandleOpen, HandleMessage, HandleError, HandleClose);
            await Feeder.ConnectAsync();
        }

        public override async Task Disconnect()
        {
            if (Feeder != null)
            {
                DisconnectValid = true;
                await Feeder.DisconnectAsync();
            }
            else
            {
                throw new StreamerException(SocketNotOpenError);
            }
        }

        protected override void HandleOpen()
        {
            DisconnectValid = false;
            ReconnectInProgress = false;
            ReconnectAttempts = 0;
            RaiseOnOpenEvent();
        }

        protected void HandleMessage(string data)
        {
            OrderUpdate orderUpdate = JsonConvert.DeserializeObject<OrderUpdate>(data);

            if (OnOrderUpdate != null)
            {
                OnOrderUpdate(orderUpdate);
            }
        }
    }
}
