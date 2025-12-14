using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Feeder;
using UpstoxClient.Feeder.Listener;
using UpstoxClient.Feeder.Model;

namespace UpstoxClient.Test.Service
{
    /// <summary>
    /// Service for managing WebSocket connections to Upstox portfolio updates using PortfolioDataStreamer
    /// </summary>
    public class PortfolioDataWebSocketService
    {
        /// <summary>
        /// Create a simple example of how to use this service
        /// </summary>
        public static async Task RunExample(IServiceProvider services)
        {
            Console.WriteLine("=== Portfolio Data WebSocket Service Example ===");

            IWebsocketApi websocketApi = services.GetRequiredService<IWebsocketApi>();
            PortfolioDataStreamer streamer = new(websocketApi, orderUpdate: true, positionUpdate: true, holdingUpdate: true, gttUpdate: true);
            streamer.SetOnOpenListener(new OnOpenListenerImpl());
            streamer.SetOnOrderUpdateListener(new OnOrderUpdateListenerImpl());
            streamer.SetOnPositionUpdateListener(new OnPositionUpdateListenerImpl());
            streamer.SetOnHoldingUpdateListener(new OnHoldingUpdateListenerImpl());
            streamer.SetOnGttUpdateListener(new OnGttUpdateListenerImpl());
            streamer.SetOnErrorListener(new OnErrorListenerImpl());
            streamer.SetOnCloseListener(new OnCloseListenerImpl());
            streamer.SetOnReconnectingListener(new OnReconnectingListenerImpl());
            streamer.AutoReconnect(true, 1, 5);
            try
            {
                // Connect to WebSocket for portfolio updates
                await streamer.ConnectAsync();

                await Task.Delay(10000); // Wait 10 seconds to test connection stability
                await streamer.DisconnectAsync();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Example failed: {ex.Message}");
            }

            Console.WriteLine("==================");
        }

        private class OnOpenListenerImpl : IOnOpenListener
        {
            public Task OnOpenAsync()
            {
                Console.WriteLine("Portfolio WebSocket connected successfully");
                return Task.CompletedTask;
            }
        }

        private class OnOrderUpdateListenerImpl : IOnOrderUpdateListener
        {
            public Task OnUpdateAsync(OrderUpdate orderUpdate)
            {
                Console.WriteLine($"Order update: {orderUpdate}");
                return Task.CompletedTask;
            }
        }

        private class OnPositionUpdateListenerImpl : IOnPositionUpdateListener
        {
            public Task OnUpdateAsync(PositionUpdate positionUpdate)
            {
                Console.WriteLine($"Position update: {positionUpdate}");
                return Task.CompletedTask;
            }
        }

        private class OnHoldingUpdateListenerImpl : IOnHoldingUpdateListener
        {
            public Task OnUpdateAsync(HoldingUpdate holdingUpdate)
            {
                Console.WriteLine($"Holding update: {holdingUpdate}");
                return Task.CompletedTask;
            }
        }

        private class OnGttUpdateListenerImpl : IOnGttUpdateListener
        {
            public Task OnUpdateAsync(GttUpdate gttUpdate)
            {
                Console.WriteLine($"GTT update: {gttUpdate}");
                return Task.CompletedTask;
            }
        }

        private class OnErrorListenerImpl : IOnErrorListener
        {
            public Task OnErrorAsync(Exception error)
            {
                Console.WriteLine($"WebSocket error: {error.Message}");
                return Task.CompletedTask;
            }
        }

        private class OnCloseListenerImpl : IOnCloseListener
        {
            public Task OnCloseAsync(int statusCode, string reason)
            {
                Console.WriteLine($"WebSocket disconnected: {reason}");
                return Task.CompletedTask;
            }
        }

        private class OnReconnectingListenerImpl : IOnReconnectingListener
        {
            public Task OnReconnectingAsync(string message)
            {
                Console.WriteLine($"WebSocket reconnecting: {message}");
                return Task.CompletedTask;
            }
        }

        private class OnAutoReconnectStoppedListenerImpl : IOnAutoReconnectStoppedListener
        {
            public Task OnHaultAsync(string message)
            {
                Console.WriteLine($"Auto reconnect stopped: {message}");
                return Task.CompletedTask;
            }
        }
    }
}
