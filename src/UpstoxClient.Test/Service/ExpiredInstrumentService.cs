using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class ExpiredInstrumentService
    {
        /// <summary>
        /// Tests the GetExpiredFutureContracts API functionality
        /// </summary>
        public static async Task PrintGetExpiredFutureContractsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing ExpiredInstrument API (GetExpiredFutureContracts) ===");

            var expiredInstrumentApi = services.GetRequiredService<IExpiredInstrumentApi>();
            var response = await expiredInstrumentApi.GetExpiredFutureContractsAsync(
                instrumentKey: "NSE_INDEX|Nifty 50",
                expiryDate: "2025-12-09"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} expired future contracts");
                    foreach (var contract in result.Data.Take(3)) // Show first 3 for brevity
                    {
                        Console.WriteLine($"    Instrument Key: {contract.InstrumentKey}");
                        Console.WriteLine($"    Trading Symbol: {contract.TradingSymbol}");
                        Console.WriteLine($"    Name: {contract.Name}");
                        Console.WriteLine($"    Expiry: {contract.Expiry}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no contracts found)");
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
                Console.WriteLine("GetExpiredFutureContracts response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetExpiredFutureContractsTest(IServiceProvider services)
        {
            var expiredInstrumentApi = services.GetRequiredService<IExpiredInstrumentApi>();
            var response = await expiredInstrumentApi.GetExpiredFutureContractsAsync(
                instrumentKey: "NSE_INDEX|Nifty 50",
                expiryDate: "2025-12-09"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetExpiredFutureContracts response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetExpiredFuturesContractResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetExpiredFutureContracts test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetExpiredFutureContracts data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetExpiredHistoricalCandleData API functionality
        /// </summary>
        public static async Task PrintGetExpiredHistoricalCandleDataTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing ExpiredInstrument API (GetExpiredHistoricalCandleData) ===");

            var expiredInstrumentApi = services.GetRequiredService<IExpiredInstrumentApi>();
            var response = await expiredInstrumentApi.GetExpiredHistoricalCandleDataAsync(
                expiredInstrumentKey: "NSE_INDEX|Nifty 50",
                interval: "day",
                toDate: "2023-12-27",
                fromDate: "2023-12-20"
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
                Console.WriteLine("GetExpiredHistoricalCandleData response is null");
            }
            Console.WriteLine("==================");
        }
            // NSE_FO|73507|24-04-2025/30minute/2025-04-24/2020-02-24
        public static async Task SanityGetExpiredHistoricalCandleDataTest(IServiceProvider services)
        {
            var expiredInstrumentApi = services.GetRequiredService<IExpiredInstrumentApi>();
            var response = await expiredInstrumentApi.GetExpiredHistoricalCandleDataAsync(
                expiredInstrumentKey: "NSE_FO|73507|24-04-2025",
                interval: "30minute",
                toDate: "2025-04-24",
                fromDate: "2020-02-24"
            );
            var result = response.Ok();
            if (result == null)
            {
                Console.WriteLine("GetExpiredHistoricalCandleData response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetHistoricalCandleResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetExpiredHistoricalCandleData test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null || result.Data.Candles == null)
            {
                Console.WriteLine("GetExpiredHistoricalCandleData data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetExpiredOptionContracts API functionality
        /// </summary>
        public static async Task PrintGetExpiredOptionContractsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing ExpiredInstrument API (GetExpiredOptionContracts) ===");

            var expiredInstrumentApi = services.GetRequiredService<IExpiredInstrumentApi>();
            var response = await expiredInstrumentApi.GetExpiredOptionContractsAsync(
                instrumentKey: "NSE_INDEX|Nifty 50",
                expiryDate: "2023-12-28"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} expired option contracts");
                    foreach (var contract in result.Data.Take(3)) // Show first 3 for brevity
                    {
                        Console.WriteLine($"    Instrument Key: {contract.InstrumentKey}");
                        Console.WriteLine($"    Trading Symbol: {contract.TradingSymbol}");
                        Console.WriteLine($"    Name: {contract.Name}");
                        Console.WriteLine($"    Expiry: {contract.Expiry}");
                        Console.WriteLine($"    Strike Price: {contract.StrikePrice}");
                        Console.WriteLine($"    Security Type: {contract.SecurityType}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no contracts found)");
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
                Console.WriteLine("GetExpiredOptionContracts response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetExpiredOptionContractsTest(IServiceProvider services)
        {
            var expiredInstrumentApi = services.GetRequiredService<IExpiredInstrumentApi>();
            var response = await expiredInstrumentApi.GetExpiredOptionContractsAsync(
                instrumentKey: "NSE_INDEX|Nifty 50",
                expiryDate: "2023-12-28"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetExpiredOptionContracts response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetOptionContractResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetExpiredOptionContracts test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetExpiredOptionContracts data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetExpiriesResponse API functionality
        /// </summary>
        public static async Task PrintGetExpiriesResponseTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing ExpiredInstrument API (GetExpiriesResponse) ===");

            var expiredInstrumentApi = services.GetRequiredService<IExpiredInstrumentApi>();
            var response = await expiredInstrumentApi.GetExpiriesResponseAsync(
                instrumentKey: "NSE_INDEX|Nifty 50"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} expiry dates");
                    foreach (var expiry in result.Data.Take(5)) // Show first 5 for brevity
                    {
                        Console.WriteLine($"    Expiry: {expiry}");
                    }
                    if (result.Data.Count > 5)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 5} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no expiry dates found)");
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
                Console.WriteLine("GetExpiriesResponse response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetExpiriesResponseTest(IServiceProvider services)
        {
            var expiredInstrumentApi = services.GetRequiredService<IExpiredInstrumentApi>();
            var response = await expiredInstrumentApi.GetExpiriesResponseAsync(
                instrumentKey: "NSE_INDEX|Nifty 50"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetExpiriesResponse response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetExpiriesResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetExpiriesResponse test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetExpiriesResponse data is null");
                return;
            }
        }
    }
}