using System;
using System.Threading.Tasks;

namespace UpstoxClient.Feeder
{
    public abstract class Streamer
    {
        protected Feeder Feeder;
        public event Action OnOpen;
        public event Action<Exception> OnError;
        public event Action<int, string> OnClose;
        public event Action<string> OnReconnecting;
        public event Action<string> OnAutoReconnectStopped;

        protected bool DisconnectValid = false;
        protected bool ReconnectInProgress = false;
        protected bool EnableAutoReconnect = true;
        protected int Interval = 1; // Interval between reconnection attempts, in seconds
        protected int RetryCount = 5; // Maximum number of reconnection attempts
        protected int ReconnectAttempts = 0; // Current count of reconnection attempts

        protected void RaiseOnOpenEvent()
        {
            if (OnOpen != null)
            {
                OnOpen();
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
        public abstract Task Connect();

        public abstract Task Disconnect();

        public void AutoReconnect(bool enable)
        {
            EnableAutoReconnect = enable;

            if (!enable)
            {
                if (OnAutoReconnectStopped != null)
                {
                    OnAutoReconnectStopped("Disabled by client");
                }

            }
        }

        public void AutoReconnect(bool enable, int interval, int retryCount)
        {
            EnableAutoReconnect = enable;
            Interval = interval;
            RetryCount = retryCount;

            if (!enable)
            {
                if (OnAutoReconnectStopped != null)
                {
                    OnAutoReconnectStopped("Disabled by client");
                }
            }
        }

        protected async Task LaunchAutoReconnectAsync()
        {
            if (EnableAutoReconnect)
            {
                ReconnectInProgress = true;
                ReconnectAttempts++;

                if (OnReconnecting != null)
                {
                    OnReconnecting(String.Format("Auto reconnect attempt {0}/{1}", ReconnectAttempts, RetryCount));
                }
                await Connect();
            }
        }

        protected abstract void HandleOpen();

        protected void HandleError(Exception error)
        {
            if (OnError != null)
            {
                OnError(error);
            }

            if (EnableAutoReconnect && ReconnectInProgress && ReconnectAttempts < RetryCount)
            {
                Task.Delay(Interval * 1000).Wait();
                ReconnectAttempts++;
                if (OnReconnecting != null)
                {
                    OnReconnecting(String.Format("Auto reconnect attempt {0}/{1}", ReconnectAttempts, RetryCount));
                }
                Connect().Wait();
            }
            else if (ReconnectAttempts >= RetryCount)
            {
                if (OnAutoReconnectStopped != null)
                {
                    OnAutoReconnectStopped(String.Format("Retry count of {0} exhausted", RetryCount));
                }
            }
        }

        protected void HandleClose(int closeStatusCode, string closeMessage)
        {
            if (!ReconnectInProgress)
            {
                if (OnClose != null)
                {
                    OnClose(closeStatusCode, closeMessage);
                }
            }

            if (!ReconnectInProgress && !DisconnectValid && closeStatusCode != 1000) // 1000 is normal closure
            {
                LaunchAutoReconnectAsync().Wait();
            }
        }
    }
}
