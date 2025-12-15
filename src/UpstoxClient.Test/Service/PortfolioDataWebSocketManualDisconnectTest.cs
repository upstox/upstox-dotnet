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
    /// Test service to manually trigger reconnection by simulating server disconnect
    /// </summary>
    public class PortfolioDataWebSocketManualDisconnectTest
    {
        /// <summary>
        /// Test reconnection by manually triggering the close event
        /// </summary>
        public static async Task RunManualDisconnectTest(IServiceProvider services)
        {
            Console.WriteLine("=== Portfolio Data WebSocket Manual Disconnect Test ===");
            Console.WriteLine("This test will:");
            Console.WriteLine("1. Connect to the WebSocket");
            Console.WriteLine("2. Wait 3 seconds");
            Console.WriteLine("3. Manually trigger a server disconnect event (status code 1006)");
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
                
                // Step 3: Manually trigger server disconnect
                Console.WriteLine("[TEST] Step 3: Manually triggering server disconnect event...");
                Console.WriteLine("[TEST] Simulating abnormal closure (status code 1006 - Connection closed abnormally)");
                
                // Access the internal feeder and trigger its close listener
                try
                {
                    var feederField = typeof(Streamer).GetField("Feeder", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    if (feederField != null)
                    {
                        var feeder = feederField.GetValue(streamer);
                        if (feeder != null)
                        {
                            var onCloseListenerField = feeder.GetType().BaseType?.GetField("OnCloseListener", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                            if (onCloseListenerField != null)
                            {
                                var onCloseListener = onCloseListenerField.GetValue(feeder) as IOnCloseListener;
                                if (onCloseListener != null)
                                {
                                    Console.WriteLine("[TEST] Triggering internal close listener...");
                                    await onCloseListener.OnCloseAsync(1006, "Connection closed abnormally - simulated server disconnect");
                                }
                                else
                                {
                                    Console.WriteLine("[TEST] Could not access internal close listener");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[TEST] Error accessing internal close listener: {ex.Message}");
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
                    Console.WriteLine("  Check if HandleCloseAsync is being called correctly.");
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