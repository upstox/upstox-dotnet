using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class MarketQuoteService
    {
        /// <summary>
        /// Tests the GetFullMarketQuote API functionality
        /// </summary>
        public static async Task PrintGetFullMarketQuoteTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketQuote API (GetFullMarketQuote) ===");

            var marketApi = services.GetRequiredService<IMarketQuoteApi>();
            var response = await marketApi.GetFullMarketQuoteAsync(
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} market quotes");
                    foreach (var quote in result.Data.Take(1)) // Show first 1 for brevity
                    {
                        Console.WriteLine($"    Instrument Token: {quote.Value.InstrumentToken}");
                        Console.WriteLine($"    Last Price: {quote.Value.LastPrice}");
                        Console.WriteLine($"    OHLC: O={quote.Value.Ohlc?.Open}, H={quote.Value.Ohlc?.High}, L={quote.Value.Ohlc?.Low}, C={quote.Value.Ohlc?.Close}");
                        Console.WriteLine($"    Volume: {quote.Value.Volume}");
                        Console.WriteLine($"    Average Price: {quote.Value.AveragePrice}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 1)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 1} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no market quote data found)");
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
                Console.WriteLine("GetFullMarketQuote response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetFullMarketQuoteTest(IServiceProvider services)
        {
            var marketApi = services.GetRequiredService<IMarketQuoteApi>();
            var response = await marketApi.GetFullMarketQuoteAsync(
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetFullMarketQuote response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetFullMarketQuoteResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetFullMarketQuote test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetFullMarketQuote data is null");
                return;
            }
        }

    }
}
