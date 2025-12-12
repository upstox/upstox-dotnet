using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class PostTradeService
    {
        /// <summary>
        /// Tests the GetTradesByDateRange API functionality
        /// </summary>
        public static async Task PrintGetTradesByDateRangeTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing PostTrade API (GetTradesByDateRange) ===");

            var postTradeApi = services.GetRequiredService<IPostTradeApi>();
            var response = await postTradeApi.GetTradesByDateRangeAsync(
                startDate: "2025-11-01",
                endDate: "2025-12-04",
                pageNumber: 1,
                pageSize: 20,
                segment: "EQ"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    if (result.MetaData?.Page != null)
                    {
                        Console.WriteLine($"  Page Number: {result.MetaData.Page.PageNumber}");
                        Console.WriteLine($"  Page Size: {result.MetaData.Page.PageSize}");
                        Console.WriteLine($"  Total Pages: {result.MetaData.Page.TotalPages}");
                        Console.WriteLine($"  Total Records: {result.MetaData.Page.TotalRecords}");
                    }

                    if (result.Data != null && result.Data.Count > 0)
                    {
                        Console.WriteLine($"  Trades: {result.Data.Count}");
                        foreach (var trade in result.Data.Take(3)) // Show first 3 for brevity
                        {
                            Console.WriteLine($"    Trade Id: {trade.TradeId}");
                            Console.WriteLine($"    Symbol: {trade.Symbol ?? trade.ScripName}");
                            Console.WriteLine($"    Transaction Type: {trade.TransactionType}");
                            Console.WriteLine($"    Quantity: {trade.Quantity}");
                            Console.WriteLine($"    Price: {trade.Price}");
                            Console.WriteLine($"    Trade Date: {trade.TradeDate}");
                            Console.WriteLine("    ---");
                        }
                        if (result.Data.Count > 3)
                        {
                            Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                        }
                    }
                    else
                    {
                        Console.WriteLine("  (no trades found)");
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
                Console.WriteLine("GetTradesByDateRange response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetTradesByDateRangeTest(IServiceProvider services)
        {
            var postTradeApi = services.GetRequiredService<IPostTradeApi>();
            var response = await postTradeApi.GetTradesByDateRangeAsync(
                startDate: "2025-11-01",
                endDate: "2025-12-04",
                pageNumber: 1,
                pageSize: 20,
                segment: "EQ"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine($"Response: {response.RawContent}");
                Console.WriteLine("GetTradesByDateRange response is null");
                return;
            }

            // Check for success status
            if (result.Status != TradeHistoryResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetTradesByDateRange test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetTradesByDateRange data is null");
                return;
            }
        }
    }
}
