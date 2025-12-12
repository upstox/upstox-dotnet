using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class TradeProfitAndLossService
    {
        /// <summary>
        /// Tests the GetProfitAndLossCharges API functionality
        /// </summary>
        public static async Task PrintGetProfitAndLossChargesTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing TradeProfitAndLoss API (GetProfitAndLossCharges) ===");

            var tradeApi = services.GetRequiredService<ITradeProfitAndLossApi>();
            var response = await tradeApi.GetProfitAndLossChargesAsync(
                segment: "EQ",
                financialYear: "2526",
                fromDate: "01-04-2025",
                toDate: "04-12-2025"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Total Charges: {result.Data.ChargesBreakdown?.Total}");
                    Console.WriteLine($"  Brokerage: {result.Data.ChargesBreakdown?.Brokerage}");

                    if (result.Data.ChargesBreakdown?.Charges != null)
                    {
                        Console.WriteLine("  Charges Breakdown:");
                        Console.WriteLine($"    Transaction: {result.Data.ChargesBreakdown.Charges.Transaction}");
                        Console.WriteLine($"    Clearing: {result.Data.ChargesBreakdown.Charges.Clearing}");
                        Console.WriteLine($"    IPFT: {result.Data.ChargesBreakdown.Charges.Ipft}");
                        Console.WriteLine($"    Others: {result.Data.ChargesBreakdown.Charges.Others}");
                        Console.WriteLine($"    SEBI Turnover: {result.Data.ChargesBreakdown.Charges.SebiTurnover}");
                        Console.WriteLine($"    Demat Transaction: {result.Data.ChargesBreakdown.Charges.DematTransaction}");
                    }

                    // Print additional properties if any
                    if (result.Data.AdditionalProperties.Count > 0)
                    {
                        Console.WriteLine("  Data Additional Properties:");
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
                Console.WriteLine($"Response: {response.RawContent}");
                Console.WriteLine("GetProfitAndLossCharges response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetProfitAndLossChargesTest(IServiceProvider services)
        {
            var tradeApi = services.GetRequiredService<ITradeProfitAndLossApi>();
            var response = await tradeApi.GetProfitAndLossChargesAsync(
                segment: "EQ",
                financialYear: "2526",
                fromDate: "01-04-2025",
                toDate: "04-12-2025"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetProfitAndLossCharges response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetProfitAndLossChargesResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetProfitAndLossCharges test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetProfitAndLossCharges data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetTradeWiseProfitAndLossData API functionality
        /// </summary>
        public static async Task PrintGetTradeWiseProfitAndLossDataTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing TradeProfitAndLoss API (GetTradeWiseProfitAndLossData) ===");

            var tradeApi = services.GetRequiredService<ITradeProfitAndLossApi>();
            var response = await tradeApi.GetTradeWiseProfitAndLossDataAsync(
                segment: "EQ",
                pageNumber: 1,
                pageSize: 20,
                financialYear: "2526",
                fromDate: "01-04-2025",
                toDate: "04-12-2025"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Page Number: {result.Metadata?.Page?.PageNumber}");
                    Console.WriteLine($"  Page Size: {result.Metadata?.Page?.PageSize}");

                    if (result.Data.Count > 0)
                    {
                        Console.WriteLine($"  Profit/Loss Records: {result.Data.Count}");
                        foreach (var record in result.Data.Take(3))
                        {
                            Console.WriteLine($"    Symbol: {record.ScripName}");
                            Console.WriteLine($"    Quantity: {record.Quantity}");
                            Console.WriteLine($"    Buy Amount: {record.BuyAmount}");
                            Console.WriteLine($"    Sell Amount: {record.SellAmount}");
                            Console.WriteLine($"    Trade Type: {record.TradeType}");
                            Console.WriteLine("    ---");
                        }
                        if (result.Data.Count > 3)
                        {
                            Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                        }
                    }
                    else
                    {
                        Console.WriteLine("  (no profit/loss data found)");
                    }

                    // Print metadata additional properties if any
                    if (result.Metadata?.Page?.AdditionalProperties.Count > 0)
                    {
                        Console.WriteLine("  Metadata Additional Properties:");
                        foreach (var kvp in result.Metadata.Page.AdditionalProperties)
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
                Console.WriteLine("GetTradeWiseProfitAndLossData response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetTradeWiseProfitAndLossDataTest(IServiceProvider services)
        {
            var tradeApi = services.GetRequiredService<ITradeProfitAndLossApi>();
            var response = await tradeApi.GetTradeWiseProfitAndLossDataAsync(
                segment: "EQ",
                pageNumber: 1,
                pageSize: 20,
                financialYear: "2526",
                fromDate: "01-04-2025",
                toDate: "04-12-2025"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetTradeWiseProfitAndLossData response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetTradeWiseProfitAndLossDataResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetTradeWiseProfitAndLossData test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetTradeWiseProfitAndLossData data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetTradeWiseProfitAndLossMetaData API functionality
        /// </summary>
        public static async Task PrintGetTradeWiseProfitAndLossMetaDataTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing TradeProfitAndLoss API (GetTradeWiseProfitAndLossMetaData) ===");

            var tradeApi = services.GetRequiredService<ITradeProfitAndLossApi>();
            var response = await tradeApi.GetTradeWiseProfitAndLossMetaDataAsync(
                segment: "EQ",
                financialYear: "2526",
                fromDate: "01-04-2025",
                toDate: "04-12-2025"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Trades Count: {result.Data.TradesCount}");
                    Console.WriteLine($"  Page Size Limit: {result.Data.PageSizeLimit}");

                    // Print additional properties if any
                    if (result.Data.AdditionalProperties.Count > 0)
                    {
                        Console.WriteLine("  Data Additional Properties:");
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
                Console.WriteLine("GetTradeWiseProfitAndLossMetaData response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetTradeWiseProfitAndLossMetaDataTest(IServiceProvider services)
        {
            var tradeApi = services.GetRequiredService<ITradeProfitAndLossApi>();
            var response = await tradeApi.GetTradeWiseProfitAndLossMetaDataAsync(
                segment: "EQ",
                financialYear: "2526",
                fromDate: "01-04-2025",
                toDate: "04-12-2025"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetTradeWiseProfitAndLossMetaData response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetTradeWiseProfitAndLossMetaDataResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetTradeWiseProfitAndLossMetaData test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetTradeWiseProfitAndLossMetaData data is null");
                return;
            }
        }
    }
}
