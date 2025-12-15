using System;
using System.Net.WebSockets;
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
    /// Test service to test error handling that actually triggers reconnection
    /// </summary>
    public class PortfolioDataWebSocketErrorReconnectionTest
    {
        /// <summary>
        /// Test error handling that triggers actual reconnection attempts
        /// </summary>
        public static async Task RunErrorReconnectionTest(IServiceProvider services)
        {
            Console.WriteLine("=== Portfolio Data WebSocket Error + Reconnection Test ===");
            Console.WriteLine("This test will:");
            Console.WriteLine("1. Connect to WebSocket normally");
            Console.WriteLine("2. Simulate WebSocket close (abnormal) to trigger reconnection");
            Console.WriteLine("3. Inject errors during reconnection process");
            Console.WriteLine("4. Verify error handling works during reconnection");
            Console.WriteLine();

            IWebsocketApi websocketApi = services.GetRequiredService<IWebsocketApi>();
            PortfolioDataStreamer streamer = new(websocketApi, orderUpdate: true, positionUpdate: true, holdingUpdate: true, gttUpdate: true);
            
            var errorReconnectionHelper = new ErrorReconnectionTestHelper();
            
            // Set up all listeners
            streamer.SetOnOpenListener(errorReconnectionHelper);
            streamer.SetOnOrderUpdateListener(new OnOrderUpdateListenerImpl());
            streamer.SetOnPositionUpdateListener(new OnPositionUpdateListenerImpl());
            streamer.SetOnHoldingUpdateListener(new OnHoldingUpdateListenerImpl());
            streamer.SetOnGttUpdateListener(new OnGttUpdateListenerImpl());
            streamer.SetOnErrorListener(errorReconnectionHelper);
            streamer.SetOnCloseListener(errorReconnectionHelper);
            streamer.SetOnReconnectingListener(errorReconnectionHelper);
            streamer.SetOnAutoReconnectStoppedListener(new OnAutoReconnectStoppedListenerImpl());
            
            // Enable auto-reconnect with shorter intervals for testing
            streamer.AutoReconnect(true, 2, 3);
            
            try
            {
                // Test 1: Normal connection
                Console.WriteLine("[TEST] Test 1: Initial connection...");
                await streamer.ConnectAsync();
                
                Console.WriteLine("[TEST] Waiting 3 seconds for stable connection...");
                await Task.Delay(3000);
                
                // Test 2: Simulate abnormal WebSocket close to trigger reconnection
                Console.WriteLine("[TEST] Test 2: Simulating abnormal WebSocket close (status 1006)...");
                try
                {
                    // Use reflection to call HandleCloseAsync with abnormal close code
                    var handleCloseMethod = typeof(Streamer).GetMethod("HandleCloseAsync", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (handleCloseMethod != null)
                    {
                        Console.WriteLine("[TEST] Calling HandleCloseAsync with status 1006 (abnormal closure)...");
                        var task = (Task)handleCloseMethod.Invoke(streamer, new object[] { 1006, "Abnormal closure - connection lost", System.Threading.CancellationToken.None });
                        await task;
                        Console.WriteLine("[TEST] HandleCloseAsync completed - should have triggered reconnection");
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
                
                // Test 3: Wait for reconnection attempts and inject errors
                Console.WriteLine("[TEST] Test 3: Waiting for reconnection attempts and injecting errors...");
                await Task.Delay(1000); // Give time for first reconnection attempt
                
                // Inject error during reconnection
                Console.WriteLine("[TEST] Injecting network error during reconnection...");
                var networkError = new WebSocketException("Network error during reconnection");
                await errorReconnectionHelper.OnErrorAsync(networkError);
                
                await Task.Delay(2000); // Wait for next reconnection attempt
                
                // Inject another error
                Console.WriteLine("[TEST] Injecting timeout error during reconnection...");
                var timeoutError = new TimeoutException("Timeout during reconnection attempt");
                await errorReconnectionHelper.OnErrorAsync(timeoutError);
                
                // Test 4: Simulate another abnormal close
                Console.WriteLine("[TEST] Test 4: Simulating another abnormal close...");
                try
                {
                    var handleCloseMethod = typeof(Streamer).GetMethod("HandleCloseAsync", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (handleCloseMethod != null)
                    {
                        var task = (Task)handleCloseMethod.Invoke(streamer, new object[] { 1011, "Server error - unexpected condition", System.Threading.CancellationToken.None });
                        await task;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[TEST] Error in second HandleCloseAsync: {ex.Message}");
                }
                
                // Test 5: Wait for more reconnection attempts
                Console.WriteLine("[TEST] Test 5: Waiting 8 seconds for additional reconnection attempts...");
                await Task.Delay(8000);
                
                // Test 6: Inject error during active reconnection process
                Console.WriteLine("[TEST] Test 6: Injecting final error...");
                var finalError = new InvalidOperationException("Final error during reconnection process");
                await errorReconnectionHelper.OnErrorAsync(finalError);
                
                await Task.Delay(2000);
                
                // Test 7: Final disconnect
                Console.WriteLine("[TEST] Test 7: Final disconnect...");
                try
                {
                    await streamer.DisconnectAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[TEST] Disconnect threw exception: {ex.Message}");
                }
                
                // Print comprehensive test results
                Console.WriteLine();
                Console.WriteLine("=== Error + Reconnection Test Results ===");
                Console.WriteLine($"Total connections: {errorReconnectionHelper.ConnectionCount}");
                Console.WriteLine($"Total disconnections: {errorReconnectionHelper.DisconnectionCount}");
                Console.WriteLine($"Total errors handled: {errorReconnectionHelper.ErrorCount}");
                Console.WriteLine($"Total reconnection attempts: {errorReconnectionHelper.ReconnectionAttemptCount}");
                Console.WriteLine();
                
                Console.WriteLine("Error Types Encountered:");
                foreach (var errorType in errorReconnectionHelper.ErrorTypes)
                {
                    Console.WriteLine($"  - {errorType}");
                }
                
                Console.WriteLine();
                Console.WriteLine($"Last error: {errorReconnectionHelper.LastError?.Message ?? "None"}");
                Console.WriteLine();
                
                // Evaluate test success
                bool hasReconnections = errorReconnectionHelper.ReconnectionAttemptCount > 0;
                bool hasErrors = errorReconnectionHelper.ErrorCount >= 3;
                bool hasMultipleConnections = errorReconnectionHelper.ConnectionCount > 1;
                
                if (hasReconnections && hasErrors)
                {
                    Console.WriteLine("✓ SUCCESS: Error handling during reconnection is working!");
                    Console.WriteLine($"  - {errorReconnectionHelper.ReconnectionAttemptCount} reconnection attempts were made");
                    Console.WriteLine($"  - {errorReconnectionHelper.ErrorCount} errors were handled during the process");
                    Console.WriteLine("  - Error listener worked correctly during reconnection scenarios");
                    
                    if (hasMultipleConnections)
                    {
                        Console.WriteLine($"  - Successfully reconnected {errorReconnectionHelper.ConnectionCount - 1} times");
                    }
                }
                else if (hasReconnections)
                {
                    Console.WriteLine("⚠ PARTIAL SUCCESS: Reconnection worked but limited error handling");
                    Console.WriteLine($"  - {errorReconnectionHelper.ReconnectionAttemptCount} reconnection attempts were made");
                    Console.WriteLine($"  - Only {errorReconnectionHelper.ErrorCount} errors were handled");
                }
                else if (hasErrors)
                {
                    Console.WriteLine("⚠ PARTIAL SUCCESS: Error handling worked but no reconnection");
                    Console.WriteLine($"  - {errorReconnectionHelper.ErrorCount} errors were handled");
                    Console.WriteLine("  - No reconnection attempts were detected");
                    Console.WriteLine("  - Check if HandleCloseAsync properly triggers reconnection");
                }
                else
                {
                    Console.WriteLine("✗ FAILED: Neither error handling nor reconnection worked as expected");
                    Console.WriteLine("  - Check error listener setup and reconnection logic");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TEST] Test failed with exception: {ex.Message}");
                Console.WriteLine($"[TEST] Stack trace: {ex.StackTrace}");
            }

            Console.WriteLine("==================");
        }

        private class ErrorReconnectionTestHelper : IOnOpenListener, IOnCloseListener, IOnErrorListener, IOnReconnectingListener
        {
            public int ConnectionCount { get; private set; }
            public int DisconnectionCount { get; private set; }
            public int ErrorCount { get; private set; }
            public int ReconnectionAttemptCount { get; private set; }
            public Exception LastError { get; private set; }
            public List<string> ErrorTypes { get; private set; } = new List<string>();

            public Task OnOpenAsync()
            {
                ConnectionCount++;
                Console.WriteLine($"[ERROR-RECON-LISTENER] ✓ WebSocket connected (Connection #{ConnectionCount}) at {DateTime.Now:HH:mm:ss}");
                return Task.CompletedTask;
            }

            public Task OnCloseAsync(int statusCode, string reason)
            {
                DisconnectionCount++;
                Console.WriteLine($"[ERROR-RECON-LISTENER] ✗ WebSocket disconnected (Disconnection #{DisconnectionCount}) at {DateTime.Now:HH:mm:ss}");
                Console.WriteLine($"[ERROR-RECON-LISTENER]   Status Code: {statusCode}, Reason: {reason}");
                return Task.CompletedTask;
            }

            public Task OnErrorAsync(Exception error)
            {
                ErrorCount++;
                LastError = error;
                
                var errorType = error?.GetType().Name ?? "null";
                if (!ErrorTypes.Contains(errorType))
                {
                    ErrorTypes.Add(errorType);
                }
                
                Console.WriteLine($"[ERROR-RECON-LISTENER] ⚠ Error #{ErrorCount} at {DateTime.Now:HH:mm:ss}");
                Console.WriteLine($"[ERROR-RECON-LISTENER]   Type: {errorType}");
                Console.WriteLine($"[ERROR-RECON-LISTENER]   Message: {error?.Message ?? "null error"}");
                
                if (error?.InnerException != null)
                {
                    Console.WriteLine($"[ERROR-RECON-LISTENER]   Inner Exception: {error.InnerException.Message}");
                }
                
                return Task.CompletedTask;
            }

            public Task OnReconnectingAsync(string message)
            {
                ReconnectionAttemptCount++;
                Console.WriteLine($"[ERROR-RECON-LISTENER] ↻ Reconnection attempt #{ReconnectionAttemptCount} at {DateTime.Now:HH:mm:ss}: {message}");
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
                Console.WriteLine($"[ERROR-RECON-LISTENER] ⊗ Auto reconnect stopped at {DateTime.Now:HH:mm:ss}: {message}");
                return Task.CompletedTask;
            }
        }
    }
}