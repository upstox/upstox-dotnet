using System;
using System.Threading;
using System.Threading.Tasks;
using UpstoxClient.Api;
using StreamerException = UpstoxClient.Feeder.Exception.StreamerException;
using UpstoxClient.Feeder.Listener;
using UpstoxClient.Feeder.Model;

namespace UpstoxClient.Feeder
{
    public class PortfolioDataStreamer : Streamer
    {
        private const string SocketNotOpenError = "WebSocket is not open.";
        private const string InvalidValuesError = "Values provided are invalid.";
        private const string OrderUpdateListenerMissingError = "Implementation of order update listener function is missing";
        private const string PositionUpdateListenerMissingError = "Implementation of position update listener function is missing";
        private const string HoldingUpdateListenerMissingError = "Implementation of holding update listener function is missing";
        private const string GttUpdateListenerMissingError = "Implementation of gtt update listener function is missing";

        private readonly IWebsocketApi _websocketApi;

        private IOnOrderUpdateListener? _onOrderUpdateListener;
        private IOnHoldingUpdateListener? _onHoldingUpdateListener;
        private IOnPositionUpdateListener? _onPositionUpdateListener;
        private IOnGttUpdateListener? _onGttUpdateListener;

        private readonly bool _orderUpdate;
        private readonly bool _holdingUpdate;
        private readonly bool _positionUpdate;
        private readonly bool _gttUpdate;

        public PortfolioDataStreamer(IWebsocketApi websocketApi)
        {
            _websocketApi = websocketApi ?? throw new StreamerException(InvalidValuesError);
            _orderUpdate = true;
            _holdingUpdate = false;
            _positionUpdate = false;
            _gttUpdate = false;
        }

        public PortfolioDataStreamer(IWebsocketApi websocketApi, bool orderUpdate, bool positionUpdate, bool holdingUpdate)
        {
            _websocketApi = websocketApi ?? throw new StreamerException(InvalidValuesError);
            _orderUpdate = orderUpdate;
            _positionUpdate = positionUpdate;
            _holdingUpdate = holdingUpdate;
            _gttUpdate = false;
        }

        public PortfolioDataStreamer(IWebsocketApi websocketApi, bool orderUpdate, bool positionUpdate, bool holdingUpdate, bool gttUpdate)
        {
            _websocketApi = websocketApi ?? throw new StreamerException(InvalidValuesError);
            _orderUpdate = orderUpdate;
            _positionUpdate = positionUpdate;
            _holdingUpdate = holdingUpdate;
            _gttUpdate = gttUpdate;
        }

        public void SetOnOrderUpdateListener(IOnOrderUpdateListener listener) => _onOrderUpdateListener = listener;
        public void SetOnHoldingUpdateListener(IOnHoldingUpdateListener listener) => _onHoldingUpdateListener = listener;
        public void SetOnPositionUpdateListener(IOnPositionUpdateListener listener) => _onPositionUpdateListener = listener;
        public void SetOnGttUpdateListener(IOnGttUpdateListener listener) => _onGttUpdateListener = listener;

        public override async Task ConnectAsync(CancellationToken cancellationToken = default)
        {
            ValidateListeners();

            Feeder = new PortfolioDataFeeder(
                _websocketApi,
                new OpenListener(async () => await HandleOpenAsync().ConfigureAwait(false)),
                new PositionMessageListener(async update =>
                {
                    // No-op hook for additional position message handling
                    await Task.CompletedTask;
                }),
                new ErrorListener(async ex => await HandleErrorAsync(ex, cancellationToken).ConfigureAwait(false)),
                new CloseListener(async (code, reason) => await HandleCloseAsync(code, reason, cancellationToken).ConfigureAwait(false)),
                _orderUpdate,
                _holdingUpdate,
                _positionUpdate,
                _gttUpdate,
                _onOrderUpdateListener,
                _onHoldingUpdateListener,
                _onPositionUpdateListener,
                _onGttUpdateListener);

            await Feeder.ConnectAsync(cancellationToken).ConfigureAwait(false);
        }

        public override async Task DisconnectAsync(CancellationToken cancellationToken = default)
        {
            if (Feeder == null)
            {
                throw new StreamerException(SocketNotOpenError);
            }

            DisconnectValid = true;
            await Feeder.DisconnectAsync().ConfigureAwait(false);
        }

        private void ValidateListeners()
        {
            if (_orderUpdate && _onOrderUpdateListener == null) throw new StreamerException(OrderUpdateListenerMissingError);
            if (_holdingUpdate && _onHoldingUpdateListener == null) throw new StreamerException(HoldingUpdateListenerMissingError);
            if (_positionUpdate && _onPositionUpdateListener == null) throw new StreamerException(PositionUpdateListenerMissingError);
            if (_gttUpdate && _onGttUpdateListener == null) throw new StreamerException(GttUpdateListenerMissingError);
        }

        private sealed class OpenListener : IOnOpenListener
        {
            private readonly Func<Task> _handler;
            public OpenListener(Func<Task> handler) => _handler = handler;
            public Task OnOpenAsync() => _handler();
        }

        private sealed class PositionMessageListener : IOnPositionMessageListener
        {
            private readonly Func<PositionUpdate, Task> _handler;
            public PositionMessageListener(Func<PositionUpdate, Task> handler) => _handler = handler;
            public Task OnMessageAsync(PositionUpdate update) => _handler(update);
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
