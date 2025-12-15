using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Feeder;
using UpstoxClient.Feeder.Listener;
using UpstoxClient.Feeder.Model;

namespace UpstoxClient.Test.Service
{
    /// <summary>
    /// Basic MarketData WebSocket connection test
    /// </summary>
    public class MarketDataWebSocketBasicTest
    {
        /// <summary>
        /// Create a simple example of how to use MarketData service
        /// </summary>
        public static async Task RunExample(IServiceProvider services)
        {
            Console.WriteLine("=== MarketData WebSocket Service Example ===");

            IWebsocketApi websocketApi = services.GetRequiredService<IWebsocketApi>();
            
            // Create test instrument keys for NSE equity
            var instrumentKeys = new HashSet<string> { "NSE_EQ|INE669E01016" }; // Reliance Industries
            
            MarketDataStreamerV3 streamer = new(websocketApi, instrumentKeys, Feeder.Constants.Mode.LTPC);
            
            streamer.SetOnMarketUpdateListener(new OnMarketUpdateListenerImpl());
            streamer.SetOnOpenListener(new OnOpenListenerImpl());
            streamer.SetOnErrorListener(new OnErrorListenerImpl());
            streamer.SetOnCloseListener(new OnCloseListenerImpl());
            streamer.SetOnReconnectingListener(new OnReconnectingListenerImpl());
            streamer.AutoReconnect(true, 1, 5);
            
            try
            {
                // Connect to WebSocket for market data updates
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
                Console.WriteLine("MarketData WebSocket connected successfully");
                return Task.CompletedTask;
            }
        }

        private class OnMarketUpdateListenerImpl : IOnMarketUpdateV3Listener
        {
            public Task OnUpdateAsync(MarketUpdateV3 marketUpdate)
            {
                Console.WriteLine($"MarketData update: Type={marketUpdate.UpdateType}, Feeds={marketUpdate.Feeds?.Count ?? 0}");
                return Task.CompletedTask;
            }
        }

        private class OnErrorListenerImpl : IOnErrorListener
        {
            public Task OnErrorAsync(Exception error)
            {
                Console.WriteLine($"MarketData WebSocket error: {error.Message}");
                return Task.CompletedTask;
            }
        }

        private class OnCloseListenerImpl : IOnCloseListener
        {
            public Task OnCloseAsync(int statusCode, string reason)
            {
                Console.WriteLine($"MarketData WebSocket disconnected: {reason}");
                return Task.CompletedTask;
            }
        }

        private class OnReconnectingListenerImpl : IOnReconnectingListener
        {
            public Task OnReconnectingAsync(string message)
            {
                Console.WriteLine($"MarketData WebSocket reconnecting: {message}");
                return Task.CompletedTask;
            }
        }

        private class OnAutoReconnectStoppedListenerImpl : IOnAutoReconnectStoppedListener
        {
            public Task OnHaultAsync(string message)
            {
                Console.WriteLine($"MarketData Auto reconnect stopped: {message}");
                return Task.CompletedTask;
            }
        }
    }
}