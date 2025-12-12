using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class MarketQuoteV3Service
    {
        /// <summary>
        /// Tests the GetLtp API functionality
        /// </summary>
        public static async Task PrintGetLtpTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketQuoteV3 API (GetLtp) ===");

            var marketApi = services.GetRequiredService<IMarketQuoteV3Api>();
            var response = await marketApi.GetLtpAsync(
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} LTP quotes");
                    foreach (var kvp in result.Data.Take(1)) // Show first 1 for brevity
                    {
                        Console.WriteLine($"    Instrument Key: {kvp.Key}");
                        Console.WriteLine($"    Last Price: {kvp.Value.LastPrice}");
                        Console.WriteLine($"    Volume: {kvp.Value.Volume}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 1)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 1} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no LTP data found)");
                }

                // Print response additional properties if any
                if (result.AdditionalProperties.Count > 0)
                {
                    Console.WriteLine("Response Additional Properties:");
                    foreach (var kvp in result.AdditionalProperties)
                    {
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                    }
                }
            }
            else
            {
                Console.WriteLine("GetLtp response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetLtpTest(IServiceProvider services)
        {
            var marketApi = services.GetRequiredService<IMarketQuoteV3Api>();
            var response = await marketApi.GetLtpAsync(
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetLtp response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetMarketQuoteLastTradedPriceResponseV3.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetLtp test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetLtp data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetMarketQuoteOHLCV3 API functionality
        /// </summary>
        public static async Task PrintGetMarketQuoteOHLCV3Test(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketQuoteV3 API (GetMarketQuoteOHLCV3) ===");

            var marketApi = services.GetRequiredService<IMarketQuoteV3Api>();
            var response = await marketApi.GetMarketQuoteOHLCV3Async(
                interval: "I1",
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} OHLC quotes");
                    foreach (var kvp in result.Data.Take(1)) // Show first 1 for brevity
                    {
                        Console.WriteLine($"    Instrument Key: {kvp.Key}");
                        Console.WriteLine($"    OHLC: O={kvp.Value.LiveOhlc?.Open}, H={kvp.Value.LiveOhlc?.High}, L={kvp.Value.LiveOhlc?.Low}, C={kvp.Value.LiveOhlc?.Close}");
                        Console.WriteLine($"    Volume: {kvp.Value.LiveOhlc?.Volume}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 1)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 1} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no OHLC data found)");
                }

                // Print response additional properties if any
                if (result.AdditionalProperties.Count > 0)
                {
                    Console.WriteLine("Response Additional Properties:");
                    foreach (var kvp in result.AdditionalProperties)
                    {
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                    }
                }
            }
            else
            {
                Console.WriteLine("GetMarketQuoteOHLCV3 response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetMarketQuoteOHLCV3Test(IServiceProvider services)
        {
            var marketApi = services.GetRequiredService<IMarketQuoteV3Api>();
            var response = await marketApi.GetMarketQuoteOHLCV3Async(
                interval: "I1",
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetMarketQuoteOHLCV3 response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetMarketQuoteOHLCResponseV3.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetMarketQuoteOHLCV3 test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetMarketQuoteOHLCV3 data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetMarketQuoteOptionGreek API functionality
        /// </summary>
        public static async Task PrintGetMarketQuoteOptionGreekTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketQuoteV3 API (GetMarketQuoteOptionGreek) ===");

            var marketApi = services.GetRequiredService<IMarketQuoteV3Api>();
            var response = await marketApi.GetMarketQuoteOptionGreekAsync(
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} option greek quotes");
                    foreach (var kvp in result.Data.Take(1)) // Show first 1 for brevity
                    {
                        Console.WriteLine($"    Instrument Key: {kvp.Key}");
                        Console.WriteLine($"    Delta: {kvp.Value.Delta}");
                        Console.WriteLine($"    Gamma: {kvp.Value.Gamma}");
                        Console.WriteLine($"    Theta: {kvp.Value.Theta}");
                        Console.WriteLine($"    Vega: {kvp.Value.Vega}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 1)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 1} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no option greek data found)");
                }

                // Print response additional properties if any
                if (result.AdditionalProperties.Count > 0)
                {
                    Console.WriteLine("Response Additional Properties:");
                    foreach (var kvp in result.AdditionalProperties)
                    {
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                    }
                }
            }
            else
            {
                Console.WriteLine("GetMarketQuoteOptionGreek response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetMarketQuoteOptionGreekTest(IServiceProvider services)
        {
            var marketApi = services.GetRequiredService<IMarketQuoteV3Api>();
            var response = await marketApi.GetMarketQuoteOptionGreekAsync(
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetMarketQuoteOptionGreek response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetMarketQuoteOptionGreekResponseV3.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetMarketQuoteOptionGreek test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetMarketQuoteOptionGreek data is null");
                return;
            }
        }
    }
}
