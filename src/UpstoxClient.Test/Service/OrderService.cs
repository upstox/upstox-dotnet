using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class OrderService
    {
        /// <summary>
        /// Tests the order API functionality by fetching the order book
        /// </summary>
        public static async Task TestOrderBookAsync(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Order API (Order Book) ===");

            var orderApi = services.GetRequiredService<IOrderApi>();
            var orderResponse = await orderApi.GetOrderBookAsync();
            var order = orderResponse.Ok();

            if (order?.Data != null && order.Data.Count > 0)
            {
                Console.WriteLine("=== Order Book ===");
                Console.WriteLine($"Total Orders: {order.Data.Count}");
                Console.WriteLine();

                int validOrders = 0;
                foreach (var orderData in order.Data)
                {
                    try
                    {
                        Console.WriteLine($"Order ID: {orderData.OrderId}");
                        Console.WriteLine($"Trading Symbol: {orderData.TradingSymbol}");
                        Console.WriteLine($"Transaction Type: {orderData.TransactionType}");
                        Console.WriteLine($"Order Type: {orderData.OrderType}");
                        Console.WriteLine($"Quantity: {orderData.Quantity}");
                        Console.WriteLine($"Price: {orderData.Price}");
                        Console.WriteLine($"Status: {orderData.Status}");
                        Console.WriteLine($"Filled Quantity: {orderData.FilledQuantity}");
                        Console.WriteLine($"Pending Quantity: {(orderData.Quantity ?? 0) - (orderData.FilledQuantity ?? 0)}");
                        Console.WriteLine($"Average Price: {orderData.AveragePrice}");
                        Console.WriteLine($"Order Timestamp: {orderData.OrderTimestamp}");
                        Console.WriteLine($"Exchange: {orderData.Exchange}");
                        Console.WriteLine($"Product: {orderData.Product}");
                        Console.WriteLine("---");
                        validOrders++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Warning: Could not process order data - {ex.Message}");
                        Console.WriteLine("---");
                    }
                }

                Console.WriteLine($"Successfully processed {validOrders} out of {order.Data.Count} orders");
                Console.WriteLine("==================");
            }
            else
            {
                Console.WriteLine("=== Order Book ===");
                Console.WriteLine("No orders found or order book data is null");
                Console.WriteLine("==================");
            }
        }

        /// <summary>
        /// Minimal sanity check for OrderBook flow
        /// </summary>
        public static async Task SanityOrderBookTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderApi>();
            var response = await orderApi.GetOrderBookAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("OrderBook response is null");
                return;
            }

            if (result.Status != GetOrderBookResponse.StatusEnum.Success)
            {
                Console.WriteLine($"OrderBook test failed with status: {result.Status}");
                return;
            }

            if (result.Data == null)
            {
                Console.WriteLine("OrderBook data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the CancelMultiOrder API functionality
        /// </summary>
        public static async Task PrintCancelMultiOrderTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Order API (CancelMultiOrder) ===");

            var orderApi = services.GetRequiredService<IOrderApi>();
            var response = await orderApi.CancelMultiOrderAsync(
                tag: null,
                segment: "NSE_EQ"
            );
            Console.WriteLine($"Response: {response.RawContent}");
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    if (result.Data.OrderIds != null && result.Data.OrderIds.Count > 0)
                    {
                        Console.WriteLine($"  Cancelled Order IDs: {result.Data.OrderIds.Count}");
                        foreach (var orderId in result.Data.OrderIds.Take(3))
                        {
                            Console.WriteLine($"    Order ID: {orderId}");
                        }
                        if (result.Data.OrderIds.Count > 3)
                        {
                            Console.WriteLine($"    ... and {result.Data.OrderIds.Count - 3} more");
                        }
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
                Console.WriteLine("CancelMultiOrder response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityCancelMultiOrderTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderApi>();
            var response = await orderApi.CancelMultiOrderAsync(
                tag: null,
                segment: "NSE_EQ"
            );

            if (!string.IsNullOrEmpty(response.RawContent) &&
                response.RawContent.Contains("UDAPI1109", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine($"Response: {response.RawContent}");
                Console.WriteLine("CancelMultiOrder response is null");
                return;
            }

            // Check for success status
            if (result.Status != CancelOrExitMultiOrderResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("CancelMultiOrder test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("CancelMultiOrder data is null");
                return;
            }
        }


        public static async Task SanityAlgoCancelMultiOrderTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderApi>();
            var response = await orderApi.CancelMultiOrderAsync(
                tag: null,
                segment: "NSE_EQ",
                algoName: "name"
            );

            if (!string.IsNullOrEmpty(response.RawContent) &&
                response.RawContent.Contains("UDAPI1109", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine($"Response: {response.RawContent}");
                Console.WriteLine("CancelMultiOrder response is null");
                return;
            }

            // Check for success status
            if (result.Status != CancelOrExitMultiOrderResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("CancelMultiOrder test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("CancelMultiOrder data is null");
                return;
            }
        }



        /// <summary>
        /// Tests the ExitPositions API functionality
        /// </summary>
        public static async Task PrintExitPositionsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Order API (ExitPositions) ===");

            var orderApi = services.GetRequiredService<IOrderApi>();
            var response = await orderApi.ExitPositionsAsync(
                tag: null,
                segment: "NSE_EQ"
            );

            if (!string.IsNullOrEmpty(response.RawContent) &&
                response.RawContent.Contains("UDAPI1159", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    if (result.Data.OrderIds != null && result.Data.OrderIds.Count > 0)
                    {
                        Console.WriteLine($"  Exit Order IDs: {result.Data.OrderIds.Count}");
                        foreach (var orderId in result.Data.OrderIds.Take(3))
                        {
                            Console.WriteLine($"    Order ID: {orderId}");
                        }
                        if (result.Data.OrderIds.Count > 3)
                        {
                            Console.WriteLine($"    ... and {result.Data.OrderIds.Count - 3} more");
                        }
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
                Console.WriteLine("ExitPositions response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityExitPositionsTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderApi>();
            var response = await orderApi.ExitPositionsAsync(
                tag: null,
                segment: "NSE_EQ"
            );

            if (!string.IsNullOrEmpty(response.RawContent) &&
                response.RawContent.Contains("UDAPI1159", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine($"Response: {response.RawContent}");  
                Console.WriteLine("ExitPositions response is null");
                return;
            }

            // Check for success status
            if (result.Status != CancelOrExitMultiOrderResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("ExitPositions test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("ExitPositions data is null");
                return;
            }
        }

        public static async Task SanityAlgoExitPositionsTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderApi>();
            var response = await orderApi.ExitPositionsAsync(
                tag: null,
                segment: "NSE_EQ",
                algoName: "name"
            );

            if (!string.IsNullOrEmpty(response.RawContent) &&
                response.RawContent.Contains("UDAPI1159", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine($"Response: {response.RawContent}");  
                Console.WriteLine("ExitPositions response is null");
                return;
            }

            // Check for success status
            if (result.Status != CancelOrExitMultiOrderResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("ExitPositions test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("ExitPositions data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetOrderDetails API functionality
        /// </summary>
        public static async Task PrintGetOrderDetailsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Order API (GetOrderDetails) ===");

            var orderApi = services.GetRequiredService<IOrderApi>();
            var response = await orderApi.GetOrderDetailsAsync(
                orderId: "251211000278897"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    foreach (var order in result.Data)
                    {
                        Console.WriteLine($"  Order ID: {order.OrderId}");
                        Console.WriteLine($"  Trading Symbol: {order.TradingSymbol}");
                        Console.WriteLine($"  Transaction Type: {order.TransactionType}");
                        Console.WriteLine($"  Order Type: {order.OrderType}");
                        Console.WriteLine($"  Quantity: {order.Quantity}");
                        Console.WriteLine($"  Price: {order.Price}");
                        Console.WriteLine($"  Status: {order.Status}");
                        Console.WriteLine($"  Filled Quantity: {order.FilledQuantity}");
                        Console.WriteLine($"  Pending Quantity: {(order.Quantity ?? 0) - (order.FilledQuantity ?? 0)}");
                        Console.WriteLine($"  Average Price: {order.AveragePrice}");
                        Console.WriteLine($"  Order Timestamp: {order.OrderTimestamp}");
                        Console.WriteLine($"  Exchange: {order.Exchange}");
                        Console.WriteLine($"  Product: {order.Product}");
                        Console.WriteLine("  ---");
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
                Console.WriteLine("GetOrderDetails response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetOrderDetailsTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderApi>();
            var response = await orderApi.GetOrderDetailsAsync(
                orderId: "123123123",
                tag: "test_tag"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine($"Response: {response.RawContent}");
                Console.WriteLine("GetOrderDetails response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetOrderResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here for APIs that may return valid errors (like GetOrderDetails)
                Console.WriteLine("GetOrderDetails test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetOrderDetails data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetOrderStatus API functionality
        /// </summary>
        public static async Task PrintGetOrderStatusTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Order API (GetOrderStatus) ===");

            var orderApi = services.GetRequiredService<IOrderApi>();
            var response = await orderApi.GetOrderStatusAsync(
                orderId: "251211000278897"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Order ID: {result.Data.OrderId}");
                    Console.WriteLine($"  Status: {result.Data.Status}");

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
                Console.WriteLine("GetOrderStatus response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetOrderStatusTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderApi>();
            var response = await orderApi.GetOrderStatusAsync(
                orderId: "12341234"
            );

            if (!string.IsNullOrEmpty(response.RawContent) &&
                response.RawContent.Contains("UDAPI100010", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine($"Response: {response.RawContent}");
                Console.WriteLine("GetOrderStatus response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetOrderDetailsResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetOrderStatus test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetOrderStatus data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetTradeHistory API functionality
        /// </summary>
        public static async Task PrintGetTradeHistoryTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Order API (GetTradeHistory) ===");

            var orderApi = services.GetRequiredService<IOrderApi>();
            var response = await orderApi.GetTradeHistoryAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} trades");
                    foreach (var trade in result.Data.Take(3))
                    {
                        Console.WriteLine($"    Order Id: {trade.OrderId}");
                        Console.WriteLine($"    Trading Symbol: {trade.TradingSymbol}");
                        Console.WriteLine($"    Transaction Type: {trade.TransactionType}");
                        Console.WriteLine($"    Quantity: {trade.Quantity}");
                        Console.WriteLine($"    Average Price: {trade.AveragePrice}");
                        Console.WriteLine($"    Trade Date: {trade.OrderTimestamp}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no trade history found)");
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
                Console.WriteLine("GetTradeHistory response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetTradeHistoryTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderApi>();
            var response = await orderApi.GetTradeHistoryAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetTradeHistory response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetTradeResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetTradeHistory test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetTradeHistory data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetTradesByOrder API functionality
        /// </summary>
        public static async Task PrintGetTradesByOrderTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Order API (GetTradesByOrder) ===");

            var orderApi = services.GetRequiredService<IOrderApi>();
            var response = await orderApi.GetTradesByOrderAsync(
                orderId: "251211000276114"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} trades for order");
                    foreach (var trade in result.Data.Take(3))
                    {
                        Console.WriteLine($"    Trade Id: {trade.TradeId}");
                        Console.WriteLine($"    Order Id: {trade.OrderId}");
                        Console.WriteLine($"    Trading Symbol: {trade.TradingSymbol}");
                        Console.WriteLine($"    Transaction Type: {trade.TransactionType}");
                        Console.WriteLine($"    Quantity: {trade.Quantity}");
                        Console.WriteLine($"    Average Price: {trade.AveragePrice}");
                        Console.WriteLine($"    Trade Date: {trade.OrderTimestamp}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no trades found for order)");
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
                Console.WriteLine("GetTradesByOrder response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetTradesByOrderTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderApi>();
            var response = await orderApi.GetTradesByOrderAsync(
                orderId: "1324123"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine($"Response: {response.RawContent}");
                Console.WriteLine("GetTradesByOrder response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetTradeResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetTradesByOrder test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetTradesByOrder data is null");
                return;
            }
        }


        /// <summary>
        /// Tests the PlaceMultiOrder API functionality
        /// </summary>
        public static async Task PrintPlaceMultiOrderTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Order API (PlaceMultiOrder) ===");

            var orderApi = services.GetRequiredService<IOrderApi>();
            var multiOrderRequest = new List<MultiOrderRequest>
            {
                new MultiOrderRequest(
                    instrumentToken: "NSE_EQ|INE669E01016",
                    transactionType: MultiOrderRequest.TransactionTypeEnum.BUY,
                    orderType: MultiOrderRequest.OrderTypeEnum.LIMIT,
                    quantity: 1,
                    price: 1000.0f,
                    product: MultiOrderRequest.ProductEnum.I,
                    validity: MultiOrderRequest.ValidityEnum.DAY,
                    correlationId: "1",
                    tag: "test_tag",
                    slice: true,
                    disclosedQuantity: 0,
                    triggerPrice: 0.0f,
                    isAmo: true
                ),
                new MultiOrderRequest(
                    instrumentToken: "NSE_EQ|INE669E01016",
                    transactionType: MultiOrderRequest.TransactionTypeEnum.BUY,
                    orderType: MultiOrderRequest.OrderTypeEnum.LIMIT,
                    quantity: 1,
                    price: 1000.0f,
                    product: MultiOrderRequest.ProductEnum.I,
                    validity: MultiOrderRequest.ValidityEnum.DAY,
                    correlationId: "2",
                    tag: "test_tag",
                    slice: true,
                    disclosedQuantity: 0,
                    triggerPrice: 0.0f,
                    isAmo: true
                )
            };

            var response = await orderApi.PlaceMultiOrderAsync(
                multiOrderRequest,
                origin: "web"
            );
            Console.WriteLine($"Response: {response.RawContent}");
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Placed Orders: {result.Data.Count}");
                    foreach (var order in result.Data.Take(3))
                    {
                        Console.WriteLine($"    Order ID: {order.OrderId}");
                        Console.WriteLine($"    Correlation ID: {order.CorrelationId}");

                        // Print additional properties if any
                        if (order.AdditionalProperties.Count > 0)
                        {
                            Console.WriteLine("    Additional Properties:");
                            foreach (var kvp in order.AdditionalProperties)
                            {
                                Console.WriteLine($"      {kvp.Key}: {kvp.Value}");
                            }
                        }
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
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
                Console.WriteLine("PlaceMultiOrder response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityPlaceMultiOrderTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderApi>();
            var multiOrderRequest = new List<MultiOrderRequest>
            {
                new MultiOrderRequest(
                    instrumentToken: "NSE_EQ|INE669E01016",
                    transactionType: MultiOrderRequest.TransactionTypeEnum.BUY,
                    orderType: MultiOrderRequest.OrderTypeEnum.LIMIT,
                    quantity: 1,
                    price: 1000.0f,
                    product: MultiOrderRequest.ProductEnum.I,
                    validity: MultiOrderRequest.ValidityEnum.DAY,
                    correlationId: "1",
                    tag: "test_tag",
                    slice: true,
                    disclosedQuantity: 0,
                    triggerPrice: 0.0f,
                    isAmo: true
                ),
                new MultiOrderRequest(
                    instrumentToken: "NSE_EQ|INE669E01016",
                    transactionType: MultiOrderRequest.TransactionTypeEnum.BUY,
                    orderType: MultiOrderRequest.OrderTypeEnum.LIMIT,
                    quantity: 1,
                    price: 1000.0f,
                    product: MultiOrderRequest.ProductEnum.I,
                    validity: MultiOrderRequest.ValidityEnum.DAY,
                    correlationId: "2",
                    tag: "test_tag",
                    slice: true,
                    disclosedQuantity: 0,
                    triggerPrice: 0.0f,
                    isAmo: true
                )
            };

            var response = await orderApi.PlaceMultiOrderAsync(
                multiOrderRequest,
                origin: "web"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("PlaceMultiOrder response is null");
                return;
            }

            // Check for success status
            if (result.Status != MultiOrderResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("PlaceMultiOrder test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("PlaceMultiOrder data is null");
                return;
            }
        }

        public static async Task SanityAlgoPlaceMultiOrderTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderApi>();
            var multiOrderRequest = new List<MultiOrderRequest>
            {
                new MultiOrderRequest(
                    instrumentToken: "NSE_EQ|INE669E01016",
                    transactionType: MultiOrderRequest.TransactionTypeEnum.BUY,
                    orderType: MultiOrderRequest.OrderTypeEnum.LIMIT,
                    quantity: 1,
                    price: 1000.0f,
                    product: MultiOrderRequest.ProductEnum.I,
                    validity: MultiOrderRequest.ValidityEnum.DAY,
                    correlationId: "1",
                    tag: "test_tag",
                    slice: true,
                    disclosedQuantity: 0,
                    triggerPrice: 0.0f,
                    isAmo: true
                ),
                new MultiOrderRequest(
                    instrumentToken: "NSE_EQ|INE669E01016",
                    transactionType: MultiOrderRequest.TransactionTypeEnum.BUY,
                    orderType: MultiOrderRequest.OrderTypeEnum.LIMIT,
                    quantity: 1,
                    price: 1000.0f,
                    product: MultiOrderRequest.ProductEnum.I,
                    validity: MultiOrderRequest.ValidityEnum.DAY,
                    correlationId: "2",
                    tag: "test_tag",
                    slice: true,
                    disclosedQuantity: 0,
                    triggerPrice: 0.0f,
                    isAmo: true
                )
            };

            var response = await orderApi.PlaceMultiOrderAsync(
                multiOrderRequest,
                origin: "web",
                algoName: "name"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("PlaceMultiOrder response is null");
                return;
            }

            // Check for success status
            if (result.Status != MultiOrderResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("PlaceMultiOrder test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("PlaceMultiOrder data is null");
                return;
            }
        }

    }
}
