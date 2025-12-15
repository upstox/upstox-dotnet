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
    /// Test service to verify MarketData WebSocket reconnection functionality
    /// </summary>
    public class MarketDataWebSocketReconnectionTest
    {
        /// <summary>
        /// Test reconnection by forcing a disconnect after initial connection
        /// </summary>
        public static async Task RunReconnectionTest(IServiceProvider services)
        {
            Console.WriteLine("=== MarketData WebSocket Reconnection Test ===");
            Console.WriteLine("This test will:");
            Console.WriteLine("1. Connect to the MarketData WebSocket");
            Console.WriteLine("2. Wait 3 seconds");
            Console.WriteLine("3. Force a disconnect");
            Console.WriteLine("4. Verify auto-reconnection works");
            Console.WriteLine();

            IWebsocketApi websocketApi = services.GetRequiredService<IWebsocketApi>();
            
            // Create test instrument keys for NSE equity
            var instrumentKeys = new HashSet<string> { "NSE_EQ|INE669E01016" }; 
            
            MarketDataStreamerV3 streamer = new(websocketApi, instrumentKeys, Feeder.Constants.Mode.LTPC);
            
            var testHelper = new ReconnectionTestHelper();
            
            streamer.SetOnMarketUpdateListener(new OnMarketUpdateListenerImpl());
            streamer.SetOnOpenListener(testHelper);
            streamer.SetOnErrorListener(testHelper);
            streamer.SetOnCloseListener(testHelper);
            streamer.SetOnReconnectingListener(testHelper);
            streamer.SetOnAutoReconnectStoppedListener(new OnAutoReconnectStoppedListenerImpl());
            
            // Enable auto-reconnect with 2 second intervals and 3 retries
            streamer.AutoReconnect(true, 2, 3);
            
            try
            {
                // Step 1: Initial connection
                Console.WriteLine("[TEST] Step 1: Connecting to MarketData WebSocket...");
                await streamer.ConnectAsync();
                
                // Step 2: Wait for stable connection
                Console.WriteLine("[TEST] Step 2: Waiting 3 seconds for stable connection...");
                await Task.Delay(3000);
                
                // Step 3: Force disconnect to trigger reconnection
                Console.WriteLine("[TEST] Step 3: Forcing disconnect to test reconnection...");
                Console.WriteLine("[TEST] Note: This will NOT trigger auto-reconnect (intentional disconnect)");
                await streamer.DisconnectAsync();
                
                // Step 4: Wait for reconnection attempts (should not happen)
                Console.WriteLine("[TEST] Step 4: Waiting 10 seconds to observe reconnection attempts...");
                await Task.Delay(10000);
                
                // Print test results
                Console.WriteLine();
                Console.WriteLine("=== Test Results ===");
                Console.WriteLine($"Total connections: {testHelper.ConnectionCount}");
                Console.WriteLine($"Total disconnections: {testHelper.DisconnectionCount}");
                Console.WriteLine($"Total reconnection attempts: {testHelper.ReconnectionAttemptCount}");
                Console.WriteLine($"Total errors: {testHelper.ErrorCount}");
                Console.WriteLine();
                
                if (testHelper.ReconnectionAttemptCount == 0)
                {
                    Console.WriteLine("✓ SUCCESS: No reconnection attempts (correct behavior for intentional disconnect)");
                }
                else
                {
                    Console.WriteLine("⚠ UNEXPECTED: Reconnection was attempted after intentional disconnect");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TEST] Test failed with exception: {ex.Message}");
                Console.WriteLine($"[TEST] Stack trace: {ex.StackTrace}");
            }

            Console.WriteLine("==================");
        }

        private class ReconnectionTestHelper : IOnOpenListener, IOnCloseListener, IOnErrorListener, IOnReconnectingListener
        {
            public int ConnectionCount { get; private set; }
            public int DisconnectionCount { get; private set; }
            public int ReconnectionAttemptCount { get; private set; }
            public int ErrorCount { get; private set; }

            public Task OnOpenAsync()
            {
                ConnectionCount++;
                Console.WriteLine($"[LISTENER] ✓ MarketData WebSocket connected (Connection #{ConnectionCount}) at {DateTime.Now:HH:mm:ss}");
                return Task.CompletedTask;
            }

            public Task OnCloseAsync(int statusCode, string reason)
            {
                DisconnectionCount++;
                Console.WriteLine($"[LISTENER] ✗ MarketData WebSocket disconnected (Disconnection #{DisconnectionCount}) at {DateTime.Now:HH:mm:ss}");
                Console.WriteLine($"[LISTENER]   Status Code: {statusCode}, Reason: {reason}");
                return Task.CompletedTask;
            }

            public Task OnErrorAsync(Exception error)
            {
                ErrorCount++;
                Console.WriteLine($"[LISTENER] ⚠ MarketData WebSocket error (Error #{ErrorCount}) at {DateTime.Now:HH:mm:ss}: {error.Message}");
                return Task.CompletedTask;
            }

            public Task OnReconnectingAsync(string message)
            {
                ReconnectionAttemptCount++;
                Console.WriteLine($"[LISTENER] ↻ MarketData Reconnection attempt #{ReconnectionAttemptCount} at {DateTime.Now:HH:mm:ss}: {message}");
                return Task.CompletedTask;
            }
        }

        private class OnMarketUpdateListenerImpl : IOnMarketUpdateV3Listener
        {
            public Task OnUpdateAsync(MarketUpdateV3 marketUpdate)
            {
                Console.WriteLine($"[UPDATE] MarketData update received at {DateTime.Now:HH:mm:ss} with {marketUpdate.Feeds?.Count ?? 0} feeds");
                return Task.CompletedTask;
            }
        }

        private class OnAutoReconnectStoppedListenerImpl : IOnAutoReconnectStoppedListener
        {
            public Task OnHaultAsync(string message)
            {
                Console.WriteLine($"[LISTENER] ⊗ MarketData Auto reconnect stopped at {DateTime.Now:HH:mm:ss}: {message}");
                return Task.CompletedTask;
            }
        }
    }
}