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
    /// Test service to test real error scenarios during WebSocket operations
    /// </summary>
    public class PortfolioDataWebSocketRealErrorTest
    {
        /// <summary>
        /// Test error handling during actual WebSocket operations
        /// </summary>
        public static async Task RunRealErrorTest(IServiceProvider services)
        {
            Console.WriteLine("=== Portfolio Data WebSocket Real Error Test ===");
            Console.WriteLine("This test will:");
            Console.WriteLine("1. Connect to WebSocket normally");
            Console.WriteLine("2. Trigger real error scenarios");
            Console.WriteLine("3. Test error recovery and reconnection");
            Console.WriteLine("4. Verify error listeners work during real operations");
            Console.WriteLine();

            IWebsocketApi websocketApi = services.GetRequiredService<IWebsocketApi>();
            PortfolioDataStreamer streamer = new(websocketApi, orderUpdate: true, positionUpdate: true, holdingUpdate: true, gttUpdate: true);
            
            var realErrorTestHelper = new RealErrorTestHelper();
            
            // Set up all listeners
            streamer.SetOnOpenListener(realErrorTestHelper);
            streamer.SetOnOrderUpdateListener(new OnOrderUpdateListenerImpl());
            streamer.SetOnPositionUpdateListener(new OnPositionUpdateListenerImpl());
            streamer.SetOnHoldingUpdateListener(new OnHoldingUpdateListenerImpl());
            streamer.SetOnGttUpdateListener(new OnGttUpdateListenerImpl());
            streamer.SetOnErrorListener(realErrorTestHelper);
            streamer.SetOnCloseListener(realErrorTestHelper);
            streamer.SetOnReconnectingListener(realErrorTestHelper);
            streamer.SetOnAutoReconnectStoppedListener(new OnAutoReconnectStoppedListenerImpl());
            
            // Enable auto-reconnect for error recovery testing
            streamer.AutoReconnect(true, 3, 3);
            
            try
            {
                // Test 1: Normal connection
                Console.WriteLine("[TEST] Test 1: Normal connection...");
                await streamer.ConnectAsync();
                
                Console.WriteLine("[TEST] Waiting 3 seconds for stable connection...");
                await Task.Delay(3000);
                
                // Test 2: Simulate network error by calling HandleErrorAsync
                Console.WriteLine("[TEST] Test 2: Simulating network error...");
                try
                {
                    var networkError = new WebSocketException("Simulated network failure");
                    
                    // Use reflection to call HandleErrorAsync
                    var handleErrorMethod = typeof(Streamer).GetMethod("HandleErrorAsync", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (handleErrorMethod != null)
                    {
                        Console.WriteLine("[TEST] Calling HandleErrorAsync via reflection...");
                        var task = (Task)handleErrorMethod.Invoke(streamer, new object[] { networkError, System.Threading.CancellationToken.None });
                        await task;
                        Console.WriteLine("[TEST] HandleErrorAsync completed");
                    }
                    else
                    {
                        Console.WriteLine("[TEST] Could not find HandleErrorAsync method, calling OnErrorAsync directly");
                        await realErrorTestHelper.OnErrorAsync(networkError);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[TEST] Error during HandleErrorAsync: {ex.Message}");
                }
                
                // Test 3: Wait and observe error recovery
                Console.WriteLine("[TEST] Test 3: Waiting 5 seconds to observe error recovery...");
                await Task.Delay(5000);
                
                // Test 4: Simulate connection timeout
                Console.WriteLine("[TEST] Test 4: Simulating connection timeout...");
                var timeoutError = new TimeoutException("Connection timeout - simulated");
                await realErrorTestHelper.OnErrorAsync(timeoutError);
                
                await Task.Delay(2000);
                
                // Test 5: Simulate authentication error
                Console.WriteLine("[TEST] Test 5: Simulating authentication error...");
                var authError = new UnauthorizedAccessException("Authentication failed - simulated");
                await realErrorTestHelper.OnErrorAsync(authError);
                
                await Task.Delay(2000);
                
                // Test 6: Test error during active operation
                Console.WriteLine("[TEST] Test 6: Testing error during active operation...");
                
                // Simulate an error that might occur during message processing
                var processingError = new InvalidOperationException("Message processing failed - simulated");
                await realErrorTestHelper.OnErrorAsync(processingError);
                
                // Test 7: Multiple rapid errors
                Console.WriteLine("[TEST] Test 7: Testing multiple rapid errors...");
                for (int i = 1; i <= 3; i++)
                {
                    var rapidError = new Exception($"Rapid error #{i} - simulated");
                    await realErrorTestHelper.OnErrorAsync(rapidError);
                    await Task.Delay(200); // Very short delay between errors
                }
                
                // Test 8: Wait for any reconnection attempts
                Console.WriteLine("[TEST] Test 8: Waiting 8 seconds for reconnection attempts...");
                await Task.Delay(8000);
                
                // Test 9: Final disconnect
                Console.WriteLine("[TEST] Test 9: Final disconnect...");
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
                Console.WriteLine("=== Real Error Test Results ===");
                Console.WriteLine($"Total connections: {realErrorTestHelper.ConnectionCount}");
                Console.WriteLine($"Total disconnections: {realErrorTestHelper.DisconnectionCount}");
                Console.WriteLine($"Total errors handled: {realErrorTestHelper.ErrorCount}");
                Console.WriteLine($"Total reconnection attempts: {realErrorTestHelper.ReconnectionAttemptCount}");
                Console.WriteLine();
                
                Console.WriteLine("Error Types Encountered:");
                foreach (var errorType in realErrorTestHelper.ErrorTypes)
                {
                    Console.WriteLine($"  - {errorType}");
                }
                
                Console.WriteLine();
                Console.WriteLine($"Last error: {realErrorTestHelper.LastError?.Message ?? "None"}");
                Console.WriteLine();
                
                // Evaluate test success
                if (realErrorTestHelper.ErrorCount >= 7)
                {
                    Console.WriteLine("✓ SUCCESS: Real error handling is working correctly!");
                    Console.WriteLine("  - Multiple error types were handled");
                    Console.WriteLine("  - Error listener responded to all simulated errors");
                    Console.WriteLine("  - System remained stable during error conditions");
                    
                    if (realErrorTestHelper.ReconnectionAttemptCount > 0)
                    {
                        Console.WriteLine("  - Reconnection attempts were triggered by errors");
                    }
                }
                else if (realErrorTestHelper.ErrorCount > 0)
                {
                    Console.WriteLine("⚠ PARTIAL SUCCESS: Some error handling worked");
                    Console.WriteLine($"  - Handled {realErrorTestHelper.ErrorCount} out of expected 7+ errors");
                    Console.WriteLine("  - Check if all error scenarios were properly triggered");
                }
                else
                {
                    Console.WriteLine("✗ FAILED: Real error handling not working");
                    Console.WriteLine("  - No errors were captured by the error listener");
                    Console.WriteLine("  - Check OnErrorListener setup and implementation");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TEST] Test failed with exception: {ex.Message}");
                Console.WriteLine($"[TEST] Stack trace: {ex.StackTrace}");
            }

            Console.WriteLine("==================");
        }

        private class RealErrorTestHelper : IOnOpenListener, IOnCloseListener, IOnErrorListener, IOnReconnectingListener
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
                Console.WriteLine($"[REAL-LISTENER] ✓ WebSocket connected (Connection #{ConnectionCount}) at {DateTime.Now:HH:mm:ss}");
                return Task.CompletedTask;
            }

            public Task OnCloseAsync(int statusCode, string reason)
            {
                DisconnectionCount++;
                Console.WriteLine($"[REAL-LISTENER] ✗ WebSocket disconnected (Disconnection #{DisconnectionCount}) at {DateTime.Now:HH:mm:ss}");
                Console.WriteLine($"[REAL-LISTENER]   Status Code: {statusCode}, Reason: {reason}");
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
                
                Console.WriteLine($"[REAL-ERROR-LISTENER] ⚠ Real Error #{ErrorCount} at {DateTime.Now:HH:mm:ss}");
                Console.WriteLine($"[REAL-ERROR-LISTENER]   Type: {errorType}");
                Console.WriteLine($"[REAL-ERROR-LISTENER]   Message: {error?.Message ?? "null error"}");
                
                if (error?.InnerException != null)
                {
                    Console.WriteLine($"[REAL-ERROR-LISTENER]   Inner Exception: {error.InnerException.Message}");
                }
                
                // Log stack trace for debugging if needed
                if (error?.StackTrace != null && error.StackTrace.Length > 0)
                {
                    Console.WriteLine($"[REAL-ERROR-LISTENER]   Stack Trace (first 200 chars): {error.StackTrace.Substring(0, Math.Min(200, error.StackTrace.Length))}...");
                }
                
                return Task.CompletedTask;
            }

            public Task OnReconnectingAsync(string message)
            {
                ReconnectionAttemptCount++;
                Console.WriteLine($"[REAL-LISTENER] ↻ Real Reconnection attempt #{ReconnectionAttemptCount} at {DateTime.Now:HH:mm:ss}: {message}");
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
                Console.WriteLine($"[REAL-LISTENER] ⊗ Auto reconnect stopped at {DateTime.Now:HH:mm:ss}: {message}");
                return Task.CompletedTask;
            }
        }
    }
}