using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class MutualFundService
    {
        /// <summary>
        /// Tests the GetMutualFundHoldings API functionality
        /// </summary>
        public static async Task PrintGetMutualFundHoldingsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MutualFund API (GetMutualFundHoldings) ===");

            var mutualFundApi = services.GetRequiredService<IMutualFundApi>();
            var response = await mutualFundApi.GetMutualFundHoldingsAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} holdings");
                    foreach (var item in result.Data.Take(3))
                    {
                        Console.WriteLine($"    Fund: {item.Fund}");
                        Console.WriteLine($"    Folio: {item.Folio}");
                        Console.WriteLine($"    InstrumentKey: {item.InstrumentKey}");
                        Console.WriteLine($"    Quantity: {item.Quantity}");
                        Console.WriteLine($"    AveragePrice: {item.AveragePrice}");
                        Console.WriteLine($"    LastPrice: {item.LastPrice}");
                        Console.WriteLine($"    LastPriceDate: {item.LastPriceDate}");
                        Console.WriteLine($"    Pnl: {item.Pnl}");
                        Console.WriteLine($"    PledgedQuantity: {item.PledgedQuantity}");
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
                Console.WriteLine("GetMutualFundHoldings response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetMutualFundHoldingsTest(IServiceProvider services)
        {
            var mutualFundApi = services.GetRequiredService<IMutualFundApi>();
            var response = await mutualFundApi.GetMutualFundHoldingsAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetMutualFundHoldings response is null");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetMutualFundHoldings data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetMutualFundOrders API functionality
        /// </summary>
        public static async Task PrintGetMutualFundOrdersTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MutualFund API (GetMutualFundOrders) ===");

            var mutualFundApi = services.GetRequiredService<IMutualFundApi>();
            var response = await mutualFundApi.GetMutualFundOrdersAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} orders");
                    foreach (var item in result.Data.Take(3))
                    {
                        Console.WriteLine($"    OrderId: {item.OrderId}");
                        Console.WriteLine($"    Fund: {item.Fund}");
                        Console.WriteLine($"    Status: {item.Status}");
                        Console.WriteLine($"    Folio: {item.Folio}");
                        Console.WriteLine($"    Variety: {item.Variety}");
                        Console.WriteLine($"    TransactionType: {item.TransactionType}");
                        Console.WriteLine($"    PurchaseType: {item.PurchaseType}");
                        Console.WriteLine($"    Amount: {item.Amount}");
                        Console.WriteLine($"    Quantity: {item.Quantity}");
                        Console.WriteLine($"    Price: {item.Price}");
                        Console.WriteLine($"    ExchangeOrderId: {item.ExchangeOrderId}");
                        Console.WriteLine($"    InstrumentKey: {item.InstrumentKey}");
                        Console.WriteLine($"    StatusMessage: {item.StatusMessage}");
                        Console.WriteLine($"    OrderTimestamp: {item.OrderTimestamp}");
                        Console.WriteLine($"    ExchangeTimestamp: {item.ExchangeTimestamp}");
                        Console.WriteLine($"    SettlementId: {item.SettlementId}");
                        Console.WriteLine($"    LastPrice: {item.LastPrice}");
                        Console.WriteLine($"    AveragePrice: {item.AveragePrice}");
                        Console.WriteLine($"    LastPriceDate: {item.LastPriceDate}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no orders found)");
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
                Console.WriteLine("GetMutualFundOrders response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetMutualFundOrdersTest(IServiceProvider services)
        {
            var mutualFundApi = services.GetRequiredService<IMutualFundApi>();
            var response = await mutualFundApi.GetMutualFundOrdersAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetMutualFundOrders response is null");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetMutualFundOrders data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetMutualFundSips API functionality
        /// </summary>
        public static async Task PrintGetMutualFundSipsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MutualFund API (GetMutualFundSips) ===");

            var mutualFundApi = services.GetRequiredService<IMutualFundApi>();
            var response = await mutualFundApi.GetMutualFundSipsAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} SIPs");
                    foreach (var item in result.Data.Take(3))
                    {
                        Console.WriteLine($"    SipId: {item.SipId}");
                        Console.WriteLine($"    Fund: {item.Fund}");
                        Console.WriteLine($"    Status: {item.Status}");
                        Console.WriteLine($"    Frequency: {item.Frequency}");
                        Console.WriteLine($"    InstalmentAmount: {item.InstalmentAmount}");
                        Console.WriteLine($"    NextInstalment: {item.NextInstalment}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no SIPs found)");
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
                Console.WriteLine("GetMutualFundSips response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetMutualFundSipsTest(IServiceProvider services)
        {
            var mutualFundApi = services.GetRequiredService<IMutualFundApi>();
            var response = await mutualFundApi.GetMutualFundSipsAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetMutualFundSips response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetMutualFundSipsResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetMutualFundSips test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetMutualFundSips data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetMutualFundOrder API functionality
        /// </summary>
        public static async Task PrintGetMutualFundOrderTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MutualFund API (GetMutualFundOrder) ===");

            var mutualFundApi = services.GetRequiredService<IMutualFundApi>();

            // First fetch orders to get a valid order id
            var ordersResponse = await mutualFundApi.GetMutualFundOrdersAsync();
            var orders = ordersResponse.Ok();

            if (orders?.Data == null || orders.Data.Count == 0)
            {
                Console.WriteLine("No mutual fund orders found, skipping GetMutualFundOrder test");
                Console.WriteLine("==================");
                return;
            }

            var firstOrderId = orders.Data[0].OrderId;
            Console.WriteLine($"Fetching details for order id: {firstOrderId}");

            var response = await mutualFundApi.GetMutualFundOrderAsync(orderId: firstOrderId);
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  OrderId: {result.Data.OrderId}");
                    Console.WriteLine($"  Fund: {result.Data.Fund}");
                    Console.WriteLine($"  Status: {result.Data.Status}");
                    Console.WriteLine($"  TransactionType: {result.Data.TransactionType}");
                    Console.WriteLine($"  Amount: {result.Data.Amount}");
                    Console.WriteLine($"  OrderTimestamp: {result.Data.OrderTimestamp}");
                    Console.WriteLine($"  StatusMessage: {result.Data.StatusMessage}");
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
                Console.WriteLine("GetMutualFundOrder response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetMutualFundOrderTest(IServiceProvider services)
        {
            var mutualFundApi = services.GetRequiredService<IMutualFundApi>();

            // First fetch orders to get a valid order id
            var ordersResponse = await mutualFundApi.GetMutualFundOrdersAsync();
            var orders = ordersResponse.Ok();

            if (orders?.Data == null || orders.Data.Count == 0)
            {
                Console.WriteLine("No mutual fund orders found, skipping GetMutualFundOrder sanity test");
                return;
            }

            var firstOrderId = orders.Data[0].OrderId;
            var response = await mutualFundApi.GetMutualFundOrderAsync(orderId: firstOrderId);
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetMutualFundOrder response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetMutualFundOrderDetailsResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetMutualFundOrder test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetMutualFundOrder data is null");
                return;
            }
        }
    }
}
