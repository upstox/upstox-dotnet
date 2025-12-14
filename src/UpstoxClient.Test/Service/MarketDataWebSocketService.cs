using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Feeder;
using UpstoxClient.Feeder.Constants;
using UpstoxClient.Feeder.Listener;
using UpstoxClient.Feeder.Model;
using UpstoxClient.Proto;

namespace UpstoxClient.Test.Service
{
    /// <summary>
    /// Service for managing WebSocket connections to Upstox market data feeds using MarketDataFeederV3
    /// </summary>
    public class MarketDataWebSocketService{

        /// <summary>
        /// Create a simple example of how to use this service
        /// </summary>
        public static async Task RunExample(IServiceProvider services)
        {
            Console.WriteLine("=== Market Data WebSocket Service Example ===");

            IWebsocketApi _websocketApi = services.GetRequiredService<IWebsocketApi>();
            MarketDataFeederV3 feeder = new(_websocketApi);
            feeder.SetOnOpenListener(new OnOpenListenerImpl());
            feeder.SetOnMessageListener(new OnMessageListenerImpl());
            feeder.SetOnErrorListener(new OnErrorListenerImpl());
            feeder.SetOnCloseListener(new OnCloseListenerImpl());
            var connectionStartTime = DateTime.Now;

            try
            {
                // Connect to WebSocket
                await feeder.ConnectAsync();

                // Subscribe to some instruments (example instruments)
                var instruments = new HashSet<string>
                {
                    "NSE_INDEX|Nifty 50",
                    "NSE_EQ|INE669E01016",
                    "MCX_FO|472849" 
                };

                var instruments2 = new HashSet<string>
                {
                    "NSE_FO|57005"
                };

                await feeder.SubscribeAsync(instruments, Mode.FULL);

                // Unsubscribe and disconnect
                // await websocketService.UnsubscribeAsync(instruments);

                await Task.Delay(10000); // Wait 10 seconds to test connection stability
                await feeder.SubscribeAsync(instruments, Mode.LTPC);
                await Task.Delay(10000); // Wait 10 seconds to test connection stability
                await feeder.SubscribeAsync(instruments2, Mode.OPTION_GREEKS);
                await Task.Delay(20000);
                await feeder.UnsubscribeAsync(instruments);
                await Task.Delay(20000);
                await feeder.DisconnectAsync();
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
                Console.WriteLine("WebSocket connected successfully");
                return Task.CompletedTask;
            }
        }
        private class OnMessageListenerImpl : IOnMessageListener
        {
            public Task OnMessageAsync(MarketUpdateV3 update)
            {
                // Handle the parsed market update object
                Console.WriteLine($"Received market update: {update}");

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
    }
}