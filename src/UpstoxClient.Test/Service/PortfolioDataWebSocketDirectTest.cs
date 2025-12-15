using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Feeder;
using UpstoxClient.Feeder.Listener;
using UpstoxClient.Feeder.Model;

namespace UpstoxClient.Test.Service
{
    /// <summary>
    /// Test service to directly call HandleCloseAsync to test reconnection
    /// </summary>
    public class PortfolioDataWebSocketDirectTest
    {
        /// <summary>
        /// Test reconnection by directly calling HandleCloseAsync
        /// </summary>
        public static async Task RunDirectTest(IServiceProvider services)
        {
            Console.WriteLine("=== Portfolio Data WebSocket Direct Test ===");
            Console.WriteLine("This test will:");
            Console.WriteLine("1. Connect to the WebSocket");
            Console.WriteLine("2. Wait 3 seconds");
            Console.WriteLine("3. Directly call HandleCloseAsync with status code 1006");
            Console.WriteLine("4. Verify auto-reconnection works");
            Console.WriteLine();

            IWebsocketApi websocketApi = services.GetRequiredService<IWebsocketApi>();
            PortfolioDataStreamer streamer = new(websocketApi, orderUpdate: true, positionUpdate: true, holdingUpdate: true, gttUpdate: true);
            
            var testHelper = new ReconnectionTestHelper();
            
            streamer.SetOnOpenListener(testHelper);
            streamer.SetOnOrderUpdateListener(new OnOrderUpdateListenerImpl());
            streamer.SetOnPositionUpdateListener(new OnPositionUpdateListenerImpl());
            streamer.SetOnHoldingUpdateListener(new OnHoldingUpdateListenerImpl());
            streamer.SetOnGttUpdateListener(new OnGttUpdateListenerImpl());
            streamer.SetOnErrorListener(testHelper);
            streamer.SetOnCloseListener(testHelper);
            streamer.SetOnReconnectingListener(testHelper);
            streamer.SetOnAutoReconnectStoppedListener(new OnAutoReconnectStoppedListenerImpl());
            
            // Enable auto-reconnect with 2 second intervals and 3 retries
            streamer.AutoReconnect(true, 2, 3);
            
            try
            {
                // Step 1: Initial connection
                Console.WriteLine("[TEST] Step 1: Connecting to WebSocket...");
                await streamer.ConnectAsync();
                
                // Step 2: Wait for stable connection
                Console.WriteLine("[TEST] Step 2: Waiting 3 seconds for stable connection...");
                await Task.Delay(3000);
                
                // Step 3: Directly call HandleCloseAsync
                Console.WriteLine("[TEST] Step 3: Directly calling HandleCloseAsync...");
                Console.WriteLine("[TEST] Simulating abnormal closure (status code 1006)");
                
                try
                {
                    // Use reflection to call the protected HandleCloseAsync method
                    var handleCloseMethod = typeof(Streamer).GetMethod("HandleCloseAsync", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (handleCloseMethod != null)
                    {
                        Console.WriteLine("[TEST] Calling HandleCloseAsync via reflection...");
                        var task = (Task)handleCloseMethod.Invoke(streamer, new object[] { 1006, "Direct test - abnormal closure", System.Threading.CancellationToken.None });
                        await task;
                        Console.WriteLine("[TEST] HandleCloseAsync completed");
                    }
                    else
                    {
                        Console.WriteLine("[TEST] Could not find HandleCloseAsync method");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[TEST] Error calling HandleCloseAsync: {ex.Message}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"[TEST] Inner exception: {ex.InnerException.Message}");
                    }
                }
                
                // Step 4: Wait for reconnection attempts
                Console.WriteLine("[TEST] Step 4: Waiting 10 seconds to observe reconnection attempts...");
                await Task.Delay(10000);
                
                // Step 5: Final disconnect
                Console.WriteLine("[TEST] Step 5: Final disconnect...");
                try
                {
                    await streamer.DisconnectAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[TEST] Disconnect threw exception (may be expected): {ex.Message}");
                }
                
                // Print test results
                Console.WriteLine();
                Console.WriteLine("=== Test Results ===");
                Console.WriteLine($"Total connections: {testHelper.ConnectionCount}");
                Console.WriteLine($"Total disconnections: {testHelper.DisconnectionCount}");
                Console.WriteLine($"Total reconnection attempts: {testHelper.ReconnectionAttemptCount}");
                Console.WriteLine($"Total errors: {testHelper.ErrorCount}");
                Console.WriteLine();
                
                if (testHelper.ConnectionCount >= 2)
                {
                    Console.WriteLine("✓ SUCCESS: Reconnection is working! Connected at least twice.");
                }
                else if (testHelper.ReconnectionAttemptCount > 0)
                {
                    Console.WriteLine("⚠ PARTIAL: Reconnection was attempted but may not have completed.");
                    Console.WriteLine("  Check if there were errors during reconnection.");
                }
                else
                {
                    Console.WriteLine("✗ FAILED: No reconnection attempts detected.");
                    Console.WriteLine("  Check the debug logs from HandleCloseAsync.");
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
                Console.WriteLine($"[LISTENER] ✓ WebSocket connected (Connection #{ConnectionCount}) at {DateTime.Now:HH:mm:ss}");
                return Task.CompletedTask;
            }

            public Task OnCloseAsync(int statusCode, string reason)
            {
                DisconnectionCount++;
                Console.WriteLine($"[LISTENER] ✗ WebSocket disconnected (Disconnection #{DisconnectionCount}) at {DateTime.Now:HH:mm:ss}");
                Console.WriteLine($"[LISTENER]   Status Code: {statusCode}, Reason: {reason}");
                return Task.CompletedTask;
            }

            public Task OnErrorAsync(Exception error)
            {
                ErrorCount++;
                Console.WriteLine($"[LISTENER] ⚠ WebSocket error (Error #{ErrorCount}) at {DateTime.Now:HH:mm:ss}: {error.Message}");
                return Task.CompletedTask;
            }

            public Task OnReconnectingAsync(string message)
            {
                ReconnectionAttemptCount++;
                Console.WriteLine($"[LISTENER] ↻ Reconnection attempt #{ReconnectionAttemptCount} at {DateTime.Now:HH:mm:ss}: {message}");
                return Task.CompletedTask;
            }
        }

        private class OnOrderUpdateListenerImpl : IOnOrderUpdateListener
        {
            public Task OnUpdateAsync(OrderUpdate orderUpdate)
            {
                Console.WriteLine($"[UPDATE] Order update received at {DateTime.Now:HH:mm:ss}");
                return Task.CompletedTask;
            }
        }

        private class OnPositionUpdateListenerImpl : IOnPositionUpdateListener
        {
            public Task OnUpdateAsync(PositionUpdate positionUpdate)
            {
                Console.WriteLine($"[UPDATE] Position update received at {DateTime.Now:HH:mm:ss}");
                return Task.CompletedTask;
            }
        }

        private class OnHoldingUpdateListenerImpl : IOnHoldingUpdateListener
        {
            public Task OnUpdateAsync(HoldingUpdate holdingUpdate)
            {
                Console.WriteLine($"[UPDATE] Holding update received at {DateTime.Now:HH:mm:ss}");
                return Task.CompletedTask;
            }
        }

        private class OnGttUpdateListenerImpl : IOnGttUpdateListener
        {
            public Task OnUpdateAsync(GttUpdate gttUpdate)
            {
                Console.WriteLine($"[UPDATE] GTT update received at {DateTime.Now:HH:mm:ss}");
                return Task.CompletedTask;
            }
        }

        private class OnAutoReconnectStoppedListenerImpl : IOnAutoReconnectStoppedListener
        {
            public Task OnHaultAsync(string message)
            {
                Console.WriteLine($"[LISTENER] ⊗ Auto reconnect stopped at {DateTime.Now:HH:mm:ss}: {message}");
                return Task.CompletedTask;
            }
        }
    }
}