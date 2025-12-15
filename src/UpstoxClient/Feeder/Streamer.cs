using System;
using System.Threading;
using System.Threading.Tasks;
using UpstoxClient.Feeder.Listener;

namespace UpstoxClient.Feeder
{
    public abstract class Streamer
    {
        protected Feeder? Feeder;

        protected IOnOpenListener? OnOpenListener;
        protected IOnErrorListener? OnErrorListener;
        protected IOnCloseListener? OnCloseListener;
        protected IOnReconnectingListener? OnReconnectingListener;
        protected IOnAutoReconnectStoppedListener? OnAutoReconnectStoppedListener;

        protected bool DisconnectValid;
        protected bool ReconnectInProgress;
        protected bool EnableAutoReconnect = true;
        protected int IntervalSeconds = 1;
        protected int RetryCount = 5;
        protected int ReconnectAttempts;

        public void SetOnOpenListener(IOnOpenListener listener) => OnOpenListener = listener;
        public void SetOnErrorListener(IOnErrorListener listener) => OnErrorListener = listener;
        public void SetOnCloseListener(IOnCloseListener listener) => OnCloseListener = listener;
        public void SetOnReconnectingListener(IOnReconnectingListener listener) => OnReconnectingListener = listener;
        public void SetOnAutoReconnectStoppedListener(IOnAutoReconnectStoppedListener listener) => OnAutoReconnectStoppedListener = listener;

        public abstract Task ConnectAsync(CancellationToken cancellationToken = default);

        public abstract Task DisconnectAsync(CancellationToken cancellationToken = default);

        public void AutoReconnect(bool enable)
        {
            EnableAutoReconnect = enable;
            if (!enable && OnAutoReconnectStoppedListener != null)
            {
                _ = OnAutoReconnectStoppedListener.OnHaultAsync("Disabled by client");
            }
        }

        public void AutoReconnect(bool enable, int intervalSeconds, int retryCount)
        {
            EnableAutoReconnect = enable;
            IntervalSeconds = intervalSeconds;
            RetryCount = retryCount;
            if (!enable && OnAutoReconnectStoppedListener != null)
            {
                _ = OnAutoReconnectStoppedListener.OnHaultAsync("Disabled by client");
            }
        }

        protected virtual async Task HandleErrorAsync(System.Exception error, CancellationToken cancellationToken = default)
        {
            if (OnErrorListener != null)
            {
                await OnErrorListener.OnErrorAsync(error).ConfigureAwait(false);
            }

            if (EnableAutoReconnect && ReconnectInProgress && ReconnectAttempts < RetryCount)
            {
                await Task.Delay(TimeSpan.FromSeconds(IntervalSeconds), CancellationToken.None).ConfigureAwait(false);
                ReconnectAttempts++;

                if (OnReconnectingListener != null)
                {
                    await OnReconnectingListener.OnReconnectingAsync($"Auto reconnect attempt {ReconnectAttempts}/{RetryCount}")
                        .ConfigureAwait(false);
                }

                // Use CancellationToken.None for reconnection to avoid reusing cancelled/invalid tokens
                await ConnectAsync(CancellationToken.None).ConfigureAwait(false);
            }
            else if (ReconnectAttempts == RetryCount && OnAutoReconnectStoppedListener != null)
            {
                await OnAutoReconnectStoppedListener.OnHaultAsync($"retryCount of {RetryCount} exhausted").ConfigureAwait(false);
            }
        }

        protected virtual async Task HandleCloseAsync(int closeStatusCode, string closeMsg, CancellationToken cancellationToken = default)
        {
            if (!ReconnectInProgress && OnCloseListener != null)
            {
                await OnCloseListener.OnCloseAsync(closeStatusCode, closeMsg).ConfigureAwait(false);
            }

            // Only reconnect if:
            // 1. Not already reconnecting
            // 2. Not a valid disconnect (user called DisconnectAsync)
            // 3. Not a normal closure (status code 1000)
            bool shouldReconnect = !ReconnectInProgress && !DisconnectValid && closeStatusCode != 1000;
            
            if (shouldReconnect)
            {
                await LaunchAutoReconnectAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        protected virtual async Task HandleOpenAsync()
        {
            DisconnectValid = false;
            ReconnectInProgress = false;
            ReconnectAttempts = 0;

            if (OnOpenListener != null)
            {
                await OnOpenListener.OnOpenAsync().ConfigureAwait(false);
            }
        }

        private async Task LaunchAutoReconnectAsync(CancellationToken cancellationToken)
        {
            if (EnableAutoReconnect)
            {
                ReconnectInProgress = true;
                ReconnectAttempts++;

                if (OnReconnectingListener != null)
                {
                    await OnReconnectingListener.OnReconnectingAsync($"Auto reconnect attempt {ReconnectAttempts}/{RetryCount}")
                        .ConfigureAwait(false);
                }

                // Use CancellationToken.None for reconnection to avoid reusing cancelled/invalid tokens
                await ConnectAsync(CancellationToken.None).ConfigureAwait(false);
            }
        }
    }
}
