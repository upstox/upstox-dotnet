using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class HistoryV3Service
    {
        /// <summary>
        /// Tests the GetHistoricalCandleData API functionality
        /// </summary>
        public static async Task PrintGetHistoricalCandleDataTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing HistoryV3 API (GetHistoricalCandleData) ===");

            var historyApi = services.GetRequiredService<IHistoryV3Api>();
            var response = await historyApi.GetHistoricalCandleDataAsync(
                instrumentKey: "NSE_EQ|INE669E01016",
                unit: "days",
                interval: 1,
                toDate: "2025-12-04"
            );
            var result = response.Ok();
            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Candles != null && result.Data.Candles.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Candles.Count} historical candles");
                    foreach (var candle in result.Data.Candles.Take(3)) // Show first 3 for brevity
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
                Console.WriteLine("GetHistoricalCandleData response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetHistoricalCandleDataTest(IServiceProvider services)
        {
            var historyApi = services.GetRequiredService<IHistoryV3Api>();
            var response = await historyApi.GetHistoricalCandleDataAsync(
                instrumentKey: "NSE_EQ|INE669E01016",
                unit: "days",
                interval: 1,
                toDate: "2025-12-04"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetHistoricalCandleData response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetHistoricalCandleResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetHistoricalCandleData test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetHistoricalCandleData data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetHistoricalCandleDataWithFromDate API functionality
        /// </summary>
        public static async Task PrintGetHistoricalCandleDataWithFromDateTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing HistoryV3 API (GetHistoricalCandleDataWithFromDate) ===");

            var historyApi = services.GetRequiredService<IHistoryV3Api>();
            var response = await historyApi.GetHistoricalCandleDataWithFromDateAsync(
                instrumentKey: "NSE_EQ|INE669E01016",
                unit: "days",
                interval: 1,
                toDate: "2024-12-04",
                fromDate: "2024-11-28"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Candles != null && result.Data.Candles.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Candles.Count} historical candles");
                    foreach (var candle in result.Data.Candles.Take(3)) // Show first 3 for brevity
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
                Console.WriteLine("GetHistoricalCandleDataWithFromDate response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetHistoricalCandleDataWithFromDateTest(IServiceProvider services)
        {
            var historyApi = services.GetRequiredService<IHistoryV3Api>();
            var response = await historyApi.GetHistoricalCandleDataWithFromDateAsync(
                instrumentKey: "NSE_EQ|INE669E01016",
                unit: "days",
                interval: 1,
                toDate: "2024-12-04",
                fromDate: "2024-11-28"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetHistoricalCandleDataWithFromDate response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetHistoricalCandleResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetHistoricalCandleDataWithFromDate test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetHistoricalCandleDataWithFromDate data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetIntraDayCandleData API functionality
        /// </summary>
        public static async Task PrintGetIntraDayCandleDataTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing HistoryV3 API (GetIntraDayCandleData) ===");

            var historyApi = services.GetRequiredService<IHistoryV3Api>();
            var response = await historyApi.GetIntraDayCandleDataAsync(
                instrumentKey: "NSE_EQ|INE669E01016",
                unit: "minutes",
                interval: 1
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Candles != null && result.Data.Candles.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Candles.Count} intraday candles");
                    foreach (var candle in result.Data.Candles.Take(3)) // Show first 3 for brevity
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
                Console.WriteLine("GetIntraDayCandleData response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetIntraDayCandleDataTest(IServiceProvider services)
        {
            var historyApi = services.GetRequiredService<IHistoryV3Api>();
            var response = await historyApi.GetIntraDayCandleDataAsync(
                instrumentKey: "NSE_EQ|INE669E01016",
                unit: "minutes",
                interval: 1
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetIntraDayCandleData response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetIntraDayCandleResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetIntraDayCandleData test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetIntraDayCandleData data is null");
                return;
            }
        }
    }
}