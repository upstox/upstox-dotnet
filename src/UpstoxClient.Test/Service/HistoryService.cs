using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class HistoryService
    {
        /// <summary>
        /// Tests the GetHistoricalCandleData2 API functionality (no fromDate)
        /// </summary>
        public static async Task PrintGetHistoricalCandleData2Test(IServiceProvider services)
        {
            Console.WriteLine("=== Testing History API (GetHistoricalCandleData2) ===");

            var historyApi = services.GetRequiredService<IHistoryApi>();
            var response = await historyApi.GetHistoricalCandleData2Async(
                instrumentKey: "NSE_EQ|INE040A01034",
                interval: "1day",
                toDate: "2025-01-25"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Candles != null && result.Data.Candles.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Candles.Count} historical candles (showing first 3):");
                    foreach (var candle in result.Data.Candles.Take(3))
                    {
                        Console.WriteLine($"    Timestamp: {candle[0]}");
                        Console.WriteLine($"    Open: {candle[1]}");
                        Console.WriteLine($"    High: {candle[2]}");
                        Console.WriteLine($"    Low: {candle[3]}");
                        Console.WriteLine($"    Close: {candle[4]}");
                        Console.WriteLine($"    Volume: {candle[5]}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Candles.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Candles.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no candle data found)");
                }

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
                Console.WriteLine("GetHistoricalCandleData2 response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetHistoricalCandleData2Test(IServiceProvider services)
        {
            var historyApi = services.GetRequiredService<IHistoryApi>();
            var response = await historyApi.GetHistoricalCandleData2Async(
                instrumentKey: "NSE_EQ|INE040A01034",
                interval: "1day",
                toDate: "2025-01-25"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetHistoricalCandleData2 response is null");
                return;
            }

            if (result.Data == null)
            {
                Console.WriteLine("GetHistoricalCandleData2 data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetHistoricalCandleData3 API functionality (with fromDate)
        /// </summary>
        public static async Task PrintGetHistoricalCandleData3Test(IServiceProvider services)
        {
            Console.WriteLine("=== Testing History API (GetHistoricalCandleData3) ===");

            var historyApi = services.GetRequiredService<IHistoryApi>();
            var response = await historyApi.GetHistoricalCandleData3Async(
                instrumentKey: "NSE_EQ|INE040A01034",
                interval: "1day",
                toDate: "2025-01-25",
                fromDate: "2025-01-01"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Candles != null && result.Data.Candles.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Candles.Count} historical candles (showing first 3):");
                    foreach (var candle in result.Data.Candles.Take(3))
                    {
                        Console.WriteLine($"    Timestamp: {candle[0]}");
                        Console.WriteLine($"    Open: {candle[1]}");
                        Console.WriteLine($"    High: {candle[2]}");
                        Console.WriteLine($"    Low: {candle[3]}");
                        Console.WriteLine($"    Close: {candle[4]}");
                        Console.WriteLine($"    Volume: {candle[5]}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Candles.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Candles.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no candle data found)");
                }

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
                Console.WriteLine("GetHistoricalCandleData3 response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetHistoricalCandleData3Test(IServiceProvider services)
        {
            var historyApi = services.GetRequiredService<IHistoryApi>();
            var response = await historyApi.GetHistoricalCandleData3Async(
                instrumentKey: "NSE_EQ|INE040A01034",
                interval: "1day",
                toDate: "2025-01-25",
                fromDate: "2025-01-01"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetHistoricalCandleData3 response is null");
                return;
            }

            if (result.Data == null)
            {
                Console.WriteLine("GetHistoricalCandleData3 data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetIntraDayCandleData1 API functionality
        /// </summary>
        public static async Task PrintGetIntraDayCandleData1Test(IServiceProvider services)
        {
            Console.WriteLine("=== Testing History API (GetIntraDayCandleData1) ===");

            var historyApi = services.GetRequiredService<IHistoryApi>();
            var response = await historyApi.GetIntraDayCandleData1Async(
                instrumentKey: "NSE_EQ|INE040A01034",
                interval: "1minute"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Candles != null && result.Data.Candles.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Candles.Count} intra-day candles (showing first 3):");
                    foreach (var candle in result.Data.Candles.Take(3))
                    {
                        Console.WriteLine($"    Timestamp: {candle[0]}");
                        Console.WriteLine($"    Open: {candle[1]}");
                        Console.WriteLine($"    High: {candle[2]}");
                        Console.WriteLine($"    Low: {candle[3]}");
                        Console.WriteLine($"    Close: {candle[4]}");
                        Console.WriteLine($"    Volume: {candle[5]}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Candles.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Candles.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no intra-day candle data found)");
                }

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
                Console.WriteLine("GetIntraDayCandleData1 response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetIntraDayCandleData1Test(IServiceProvider services)
        {
            var historyApi = services.GetRequiredService<IHistoryApi>();
            var response = await historyApi.GetIntraDayCandleData1Async(
                instrumentKey: "NSE_EQ|INE040A01034",
                interval: "1minute"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetIntraDayCandleData1 response is null");
                return;
            }

            if (result.Data == null)
            {
                Console.WriteLine("GetIntraDayCandleData1 data is null");
                return;
            }
        }
    }
}
