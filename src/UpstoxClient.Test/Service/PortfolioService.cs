using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class PortfolioService
    {
        /// <summary>
        /// Tests the ConvertPositions API functionality
        /// </summary>
        public static async Task PrintConvertPositionsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Portfolio API (ConvertPositions) ===");

            var portfolioApi = services.GetRequiredService<IPortfolioApi>();
            var convertRequest = new ConvertPositionRequest(
                instrumentToken: "NSE_EQ|INE669E01016",
                newProduct: ConvertPositionRequest.NewProductEnum.D,
                oldProduct: ConvertPositionRequest.OldProductEnum.I,
                transactionType: ConvertPositionRequest.TransactionTypeEnum.BUY,
                quantity: 1
            );

            var response = await portfolioApi.ConvertPositionsAsync(convertRequest);
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Status: {result.Data.Status}");

                    // Print additional properties if any
                    if (result.Data.AdditionalProperties.Count > 0)
                    {
                        Console.WriteLine("  Additional Properties:");
                        foreach (var kvp in result.Data.AdditionalProperties)
                        {
                            Console.WriteLine($"    {kvp.Key}: {kvp.Value}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("  (null)");
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
                Console.WriteLine("ConvertPositions response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityConvertPositionsTest(IServiceProvider services)
        {
            var portfolioApi = services.GetRequiredService<IPortfolioApi>();
            var convertRequest = new ConvertPositionRequest(
                instrumentToken: "NSE_EQ|INE669E01016",
                newProduct: ConvertPositionRequest.NewProductEnum.D,
                oldProduct: ConvertPositionRequest.OldProductEnum.I,
                transactionType: ConvertPositionRequest.TransactionTypeEnum.BUY,
                quantity: 1
            );

            var response = await portfolioApi.ConvertPositionsAsync(convertRequest);
            if (!string.IsNullOrEmpty(response.RawContent) &&
                response.RawContent.Contains("UDAPI1035", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine($"Response: {response.RawContent}");
                Console.WriteLine("ConvertPositions response is null");
                return;
            }

            // Check for success status
            if (result.Status != ConvertPositionResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("ConvertPositions test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("ConvertPositions data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetHoldings API functionality
        /// </summary>
        public static async Task PrintGetHoldingsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Portfolio API (GetHoldings) ===");

            var portfolioApi = services.GetRequiredService<IPortfolioApi>();
            var response = await portfolioApi.GetHoldingsAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} holdings");
                    foreach (var holding in result.Data.Take(3)) // Show first 3 for brevity
                    {
                        Console.WriteLine($"    Instrument Token: {holding.InstrumentToken}");
                        Console.WriteLine($"    Trading Symbol: {holding.TradingSymbol}");
                        Console.WriteLine($"    Quantity: {holding.Quantity}");
                        Console.WriteLine($"    Average Price: {holding.AveragePrice}");
                        Console.WriteLine($"    Last Price: {holding.LastPrice}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no holdings found)");
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
                Console.WriteLine("GetHoldings response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetHoldingsTest(IServiceProvider services)
        {
            var portfolioApi = services.GetRequiredService<IPortfolioApi>();
            var response = await portfolioApi.GetHoldingsAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetHoldings response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetHoldingsResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetHoldings test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetHoldings data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetMtfPositions API functionality
        /// </summary>
        public static async Task PrintGetMtfPositionsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Portfolio API (GetMtfPositions) ===");

            var portfolioApi = services.GetRequiredService<IPortfolioApi>();
            var response = await portfolioApi.GetMtfPositionsAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} positions");
                    foreach (var position in result.Data.Take(3)) // Show first 3 for brevity
                    {
                        Console.WriteLine($"    Symbol: {position.TradingSymbol}, Qty: {position.Quantity}, P&L: {position.Pnl}");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no positions data found)");
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
                Console.WriteLine("GetMtfPositions response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetMtfPositionsTest(IServiceProvider services)
        {
            var portfolioApi = services.GetRequiredService<IPortfolioApi>();
            var response = await portfolioApi.GetMtfPositionsAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetMtfPositions response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetPositionResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetMtfPositions test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetMtfPositions data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetPositions API functionality
        /// </summary>
        public static async Task PrintGetPositionsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Portfolio API (GetPositions) ===");

            var portfolioApi = services.GetRequiredService<IPortfolioApi>();
            var response = await portfolioApi.GetPositionsAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} positions");
                    foreach (var position in result.Data.Take(3)) // Show first 3 for brevity
                    {
                        Console.WriteLine($"    Symbol: {position.TradingSymbol}, Qty: {position.Quantity}, P&L: {position.Pnl}");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no positions data found)");
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
                Console.WriteLine("GetPositions response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetPositionsTest(IServiceProvider services)
        {
            var portfolioApi = services.GetRequiredService<IPortfolioApi>();
            var response = await portfolioApi.GetPositionsAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetPositions response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetPositionResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetPositions test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetPositions data is null");
                return;
            }
        }
    }
}
