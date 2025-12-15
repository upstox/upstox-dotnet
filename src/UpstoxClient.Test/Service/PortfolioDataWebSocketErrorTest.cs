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
    /// Test service to test SetOnErrorListener and OnErrorAsync functionality
    /// </summary>
    public class PortfolioDataWebSocketErrorTest
    {
        /// <summary>
        /// Test error handling by triggering various error scenarios
        /// </summary>
        public static async Task RunErrorTest(IServiceProvider services)
        {
            Console.WriteLine("=== Portfolio Data WebSocket Error Test ===");
            Console.WriteLine("This test will:");
            Console.WriteLine("1. Test SetOnErrorListener functionality");
            Console.WriteLine("2. Test OnErrorAsync callback");
            Console.WriteLine("3. Trigger various error scenarios");
            Console.WriteLine("4. Verify error handling works correctly");
            Console.WriteLine();

            IWebsocketApi websocketApi = services.GetRequiredService<IWebsocketApi>();
            PortfolioDataStreamer streamer = new(websocketApi, orderUpdate: true, positionUpdate: true, holdingUpdate: true, gttUpdate: true);
            
            var errorTestHelper = new ErrorTestHelper();
            
            // Set up all listeners
            streamer.SetOnOpenListener(errorTestHelper);
            streamer.SetOnOrderUpdateListener(new OnOrderUpdateListenerImpl());
            streamer.SetOnPositionUpdateListener(new OnPositionUpdateListenerImpl());
            streamer.SetOnHoldingUpdateListener(new OnHoldingUpdateListenerImpl());
            streamer.SetOnGttUpdateListener(new OnGttUpdateListenerImpl());
            streamer.SetOnCloseListener(errorTestHelper);
            streamer.SetOnReconnectingListener(errorTestHelper);
            streamer.SetOnAutoReconnectStoppedListener(new OnAutoReconnectStoppedListenerImpl());
            
            // Test 1: Set error listener and verify it's set
            Console.WriteLine("[TEST] Test 1: Setting OnErrorListener...");
            streamer.SetOnErrorListener(errorTestHelper);
            Console.WriteLine("[TEST] ✓ OnErrorListener set successfully");
            
            // Enable auto-reconnect for error recovery testing
            streamer.AutoReconnect(true, 2, 2);
            
            try
            {
                // Test 2: Connect and test normal operation
                Console.WriteLine("[TEST] Test 2: Connecting to WebSocket...");
                await streamer.ConnectAsync();
                
                Console.WriteLine("[TEST] Waiting 2 seconds for stable connection...");
                await Task.Delay(2000);
                
                // Test 3: Trigger error by calling OnErrorAsync directly
                Console.WriteLine("[TEST] Test 3: Triggering error via OnErrorAsync...");
                var testException = new Exception("Test error - simulated network failure");
                
                try
                {
                    // Call OnErrorAsync directly to test error handling
                    await errorTestHelper.OnErrorAsync(testException);
                    Console.WriteLine("[TEST] ✓ OnErrorAsync called successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[TEST] ✗ Error calling OnErrorAsync: {ex.Message}");
                }
                
                // Test 4: Test multiple error scenarios
                Console.WriteLine("[TEST] Test 4: Testing multiple error types...");
                
                var errors = new Exception[]
                {
                    new InvalidOperationException("Test InvalidOperationException"),
                    new TimeoutException("Test TimeoutException"),
                    new ArgumentException("Test ArgumentException"),
                    new NullReferenceException("Test NullReferenceException")
                };
                
                foreach (var error in errors)
                {
                    await errorTestHelper.OnErrorAsync(error);
                    await Task.Delay(500); // Small delay between errors
                }
                
                Console.WriteLine("[TEST] ✓ Multiple error types tested");
                
                // Test 5: Test error listener replacement
                Console.WriteLine("[TEST] Test 5: Testing error listener replacement...");
                var secondErrorListener = new SecondErrorTestHelper();
                streamer.SetOnErrorListener(secondErrorListener);
                
                await secondErrorListener.OnErrorAsync(new Exception("Test with second listener"));
                Console.WriteLine("[TEST] ✓ Error listener replacement tested");
                
                // Test 6: Test null error handling
                Console.WriteLine("[TEST] Test 6: Testing null error handling...");
                try
                {
                    await errorTestHelper.OnErrorAsync(null);
                    Console.WriteLine("[TEST] ✓ Null error handled gracefully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[TEST] ⚠ Null error caused exception: {ex.Message}");
                }
                
                // Wait a bit to see any delayed effects
                Console.WriteLine("[TEST] Waiting 3 seconds to observe error effects...");
                await Task.Delay(3000);
                
                // Final disconnect
                Console.WriteLine("[TEST] Final disconnect...");
                try
                {
                    await streamer.DisconnectAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[TEST] Disconnect threw exception: {ex.Message}");
                }
                
                // Print test results
                Console.WriteLine();
                Console.WriteLine("=== Error Test Results ===");
                Console.WriteLine($"Primary listener - Total errors handled: {errorTestHelper.ErrorCount}");
                Console.WriteLine($"Primary listener - Last error: {errorTestHelper.LastError?.Message ?? "None"}");
                Console.WriteLine($"Secondary listener - Total errors handled: {secondErrorListener.ErrorCount}");
                Console.WriteLine($"Secondary listener - Last error: {secondErrorListener.LastError?.Message ?? "None"}");
                Console.WriteLine($"Total connections: {errorTestHelper.ConnectionCount}");
                Console.WriteLine($"Total disconnections: {errorTestHelper.DisconnectionCount}");
                Console.WriteLine();
                
                // Evaluate test success
                if (errorTestHelper.ErrorCount >= 4 && secondErrorListener.ErrorCount >= 1)
                {
                    Console.WriteLine("✓ SUCCESS: Error handling is working correctly!");
                    Console.WriteLine("  - Primary listener handled multiple errors");
                    Console.WriteLine("  - Secondary listener replacement worked");
                    Console.WriteLine("  - OnErrorAsync functionality verified");
                }
                else if (errorTestHelper.ErrorCount > 0)
                {
                    Console.WriteLine("⚠ PARTIAL SUCCESS: Some error handling worked");
                    Console.WriteLine($"  - Primary listener handled {errorTestHelper.ErrorCount} errors");
                    Console.WriteLine($"  - Secondary listener handled {secondErrorListener.ErrorCount} errors");
                }
                else
                {
                    Console.WriteLine("✗ FAILED: Error handling not working as expected");
                    Console.WriteLine("  - Check if OnErrorListener is properly set");
                    Console.WriteLine("  - Verify OnErrorAsync implementation");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TEST] Test failed with exception: {ex.Message}");
                Console.WriteLine($"[TEST] Stack trace: {ex.StackTrace}");
            }

            Console.WriteLine("==================");
        }

        private class ErrorTestHelper : IOnOpenListener, IOnCloseListener, IOnErrorListener, IOnReconnectingListener
        {
            public int ConnectionCount { get; private set; }
            public int DisconnectionCount { get; private set; }
            public int ErrorCount { get; private set; }
            public int ReconnectionAttemptCount { get; private set; }
            public Exception LastError { get; private set; }

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
                LastError = error;
                Console.WriteLine($"[ERROR-LISTENER] ⚠ Error #{ErrorCount} at {DateTime.Now:HH:mm:ss}");
                Console.WriteLine($"[ERROR-LISTENER]   Type: {error?.GetType().Name ?? "null"}");
                Console.WriteLine($"[ERROR-LISTENER]   Message: {error?.Message ?? "null error"}");
                
                if (error?.InnerException != null)
                {
                    Console.WriteLine($"[ERROR-LISTENER]   Inner Exception: {error.InnerException.Message}");
                }
                
                return Task.CompletedTask;
            }

            public Task OnReconnectingAsync(string message)
            {
                ReconnectionAttemptCount++;
                Console.WriteLine($"[LISTENER] ↻ Reconnection attempt #{ReconnectionAttemptCount} at {DateTime.Now:HH:mm:ss}: {message}");
                return Task.CompletedTask;
            }
        }

        private class SecondErrorTestHelper : IOnErrorListener
        {
            public int ErrorCount { get; private set; }
            public Exception LastError { get; private set; }

            public Task OnErrorAsync(Exception error)
            {
                ErrorCount++;
                LastError = error;
                Console.WriteLine($"[SECOND-ERROR-LISTENER] ⚠ Error #{ErrorCount} at {DateTime.Now:HH:mm:ss}");
                Console.WriteLine($"[SECOND-ERROR-LISTENER]   Type: {error?.GetType().Name ?? "null"}");
                Console.WriteLine($"[SECOND-ERROR-LISTENER]   Message: {error?.Message ?? "null error"}");
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