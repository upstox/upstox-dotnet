using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class OrderV3Service
    {
        /// <summary>
        /// Tests the place order v3 API functionality
        /// </summary>
        public static async Task TestPlaceOrderV3Async(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Order V3 API ===");

            // Example: Place a market buy order for RELIANCE
            await PlaceOrderAsync(services,
                instrumentToken: "NSE_EQ|INE669E01016", // RELIANCE
                quantity: 1,
                transactionType: PlaceOrderV3Request.TransactionTypeEnum.BUY,
                orderType: PlaceOrderV3Request.OrderTypeEnum.LIMIT,
                product: PlaceOrderV3Request.ProductEnum.I, // Intraday
                price: 1200f // Required for LIMIT orders
            );
        }

        /// <summary>
        /// Minimal sanity check for PlaceOrder V3 flow
        /// </summary>
        public static async Task SanityPlaceOrderV3Test(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderV3Api>();

            var orderRequest = new PlaceOrderV3Request(
                quantity: 1,
                product: PlaceOrderV3Request.ProductEnum.I,
                validity: PlaceOrderV3Request.ValidityEnum.DAY,
                price: 12f,
                instrumentToken: "NSE_EQ|INE669E01016",
                orderType: PlaceOrderV3Request.OrderTypeEnum.LIMIT,
                transactionType: PlaceOrderV3Request.TransactionTypeEnum.BUY,
                disclosedQuantity: 0,
                triggerPrice: 0.0f,
                isAmo: true,
                tag: "sanity_place_order_v3"
            );

            var response = await orderApi.PlaceOrderAsync(orderRequest);
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("PlaceOrderV3 response is null");
                return;
            }

            if (result.Status != PlaceOrderV3Response.StatusEnum.Success)
            {
                Console.WriteLine($"PlaceOrderV3 test failed with status: {result.Status}");
                return;
            }

            if (result.Data == null || result.Data.OrderIds == null || result.Data.OrderIds.Count == 0)
            {
                Console.WriteLine("PlaceOrderV3 data is missing order ids");
                return;
            }

        }

        /// <summary>
        /// Places an order with the specified parameters
        /// </summary>
        /// <param name="services">Service provider to get the order API</param>
        /// <param name="instrumentToken">Instrument token (e.g., "NSE_EQ|INE669E01016")</param>
        /// <param name="quantity">Quantity to buy/sell</param>
        /// <param name="transactionType">BUY or SELL</param>
        /// <param name="orderType">MARKET, LIMIT, SL, SL-M</param>
        /// <param name="product">I (Intraday) or D (Delivery)</param>
        /// <param name="price">Price for limit orders (use 0 for market orders)</param>
        /// <param name="triggerPrice">Trigger price for stop loss orders</param>
        /// <param name="validity">DAY or IOC</param>
        /// <param name="disclosedQuantity">Disclosed quantity (0 for none)</param>
        /// <param name="isAmo">After Market Order flag</param>
        /// <param name="tag">Optional tag for the order</param>
        private static async Task PlaceOrderAsync(
            IServiceProvider services,
            string instrumentToken,
            int quantity,
            PlaceOrderV3Request.TransactionTypeEnum transactionType,
            PlaceOrderV3Request.OrderTypeEnum orderType,
            PlaceOrderV3Request.ProductEnum product,
            float price = 0.0f,
            float triggerPrice = 0.0f,
            PlaceOrderV3Request.ValidityEnum validity = PlaceOrderV3Request.ValidityEnum.DAY,
            int disclosedQuantity = 0,
            bool isAmo = true,
            string? tag = null)
        {
            var orderApi = services.GetRequiredService<IOrderV3Api>();

            // Create order request
            var orderRequest = new PlaceOrderV3Request(
                quantity: quantity,
                product: product,
                validity: validity,
                price: price,
                instrumentToken: instrumentToken,
                orderType: orderType,
                transactionType: transactionType,
                disclosedQuantity: disclosedQuantity,
                triggerPrice: triggerPrice,
                isAmo: isAmo,
                tag: tag
            );

            // Validate parameters based on order type
            if (orderType == PlaceOrderV3Request.OrderTypeEnum.LIMIT && price <= 0)
            {
                Console.WriteLine("❌ Error: Price must be greater than 0 for LIMIT orders");
                return;
            }

            if ((orderType == PlaceOrderV3Request.OrderTypeEnum.SL || orderType == PlaceOrderV3Request.OrderTypeEnum.SLM) && triggerPrice <= 0)
            {
                Console.WriteLine("❌ Error: Trigger price must be greater than 0 for stop loss orders");
                return;
            }

            try
            {
                Console.WriteLine($"Placing {transactionType} order for {instrumentToken}...");
                Console.WriteLine($"Quantity: {quantity}, Order Type: {orderType}, Product: {product}, Price: {price}, Trigger Price: {triggerPrice}");

                // Place the order
                Console.WriteLine("Sending order request to API...");
                var orderResponse = await orderApi.PlaceOrderAsync(orderRequest);
                Console.WriteLine($"Received response from API: {orderResponse.GetType().Name}");

                // Handle successful response
                if (orderResponse.Ok() is { } orderResult)
                {
                    Console.WriteLine("✅ Order placed successfully!");
                    Console.WriteLine($"Status: {orderResult.Status}");

                    if (orderResult.Data?.OrderIds != null && orderResult.Data.OrderIds.Count > 0)
                    {
                        Console.WriteLine($"Order ID(s): {string.Join(", ", orderResult.Data.OrderIds)}");
                    }
                    else
                    {
                        Console.WriteLine("No order IDs returned");
                    }
                }
                else if (orderResponse.BadRequest() is { } badRequest)
                {
                    Console.WriteLine($"❌ Bad Request Error: {badRequest.Errors?.FirstOrDefault()?.Message ?? "Unknown error"}");
                }
                else if (orderResponse.UnprocessableContent() is { } unprocessable)
                {
                    Console.WriteLine($"❌ Validation Error: {unprocessable.Errors?.FirstOrDefault()?.Message ?? "Validation failed"}");
                }
                else if (orderResponse.TooManyRequests() is { } rateLimit)
                {
                    Console.WriteLine($"❌ Rate Limit Error: {rateLimit.Errors?.FirstOrDefault()?.Message ?? "Too many requests"}");
                }
                else if (orderResponse.InternalServerError() is { } serverError)
                {
                    Console.WriteLine($"❌ Server Error: {serverError.Errors?.FirstOrDefault()?.Message ?? "Internal server error"}");
                }
                else if (orderResponse.MethodNotAllowed() is { } methodNotAllowed)
                {
                    Console.WriteLine($"❌ Method Not Allowed: {methodNotAllowed.Errors?.FirstOrDefault()?.Message ?? "Method not allowed"}");
                }
                else if (orderResponse.Locked() is { } locked)
                {
                    Console.WriteLine($"❌ Account Locked: {locked.Errors?.FirstOrDefault()?.Message ?? "Account is locked"}");
                }
                else
                {
                    Console.WriteLine("❌ Order placement failed with unknown error");

                    // Debug information for unknown errors
                    PrintDetailedErrorInfo(orderResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Exception occurred while placing order: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }

        /// <summary>
        /// Prints detailed error information for debugging unknown API errors
        /// </summary>
        private static void PrintDetailedErrorInfo(dynamic orderResponse)
        {
            Console.WriteLine("🔍 Detailed Error Information:");

            try
            {
                Console.WriteLine($"- Response type: {orderResponse.GetType().Name}");
                Console.WriteLine($"- Response object: {orderResponse}");

                // Try to get HTTP status code if available
                var statusCodeProperty = orderResponse.GetType().GetProperty("StatusCode");
                if (statusCodeProperty != null)
                {
                    var statusCode = statusCodeProperty.GetValue(orderResponse);
                    Console.WriteLine($"- HTTP Status Code: {statusCode}");
                }

                // Try to get raw content if available
                var rawContentProperty = orderResponse.GetType().GetProperty("RawContent");
                if (rawContentProperty != null)
                {
                    var rawContent = rawContentProperty.GetValue(orderResponse);
                    Console.WriteLine($"- Raw Content: {rawContent}");
                }

                // Check all possible error response methods
                var methods = new[] { "Ok", "BadRequest", "UnprocessableContent", "TooManyRequests", "InternalServerError", "MethodNotAllowed", "Locked" };
                foreach (var method in methods)
                {
                    var methodInfo = orderResponse.GetType().GetMethod(method);
                    if (methodInfo != null)
                    {
                        try
                        {
                            var result = methodInfo.Invoke(orderResponse, null);
                            Console.WriteLine($"- {method}(): {result}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"- {method}(): Error calling method - {ex.Message}");
                        }
                    }
                }

                // Try to serialize the response
                try
                {
                    var json = System.Text.Json.JsonSerializer.Serialize(orderResponse);
                    Console.WriteLine($"- Serialized response: {json}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"- Could not serialize response: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"- Error getting debug info: {ex.Message}");
                Console.WriteLine($"- Stack trace: {ex.StackTrace}");
            }
        }

        /// <summary>
        /// Tests the CancelGTTOrder API functionality
        /// </summary>
        public static async Task PrintCancelGTTOrderTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing OrderV3 API (CancelGTTOrder) ===");

            var orderApi = services.GetRequiredService<IOrderV3Api>();
            var cancelRequest = new GttCancelOrderRequest(
                gttOrderId: "GTT-C25211100025395"
            );

            var response = await orderApi.CancelGTTOrderAsync(
                cancelRequest,
                origin: "web"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  GTT Order Ids: {string.Join(", ", result.Data.GttOrderIds ?? new List<string>())}");

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
                Console.WriteLine("CancelGTTOrder response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityCancelGTTOrderTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderV3Api>();
            var cancelRequest = new GttCancelOrderRequest(
                gttOrderId: "GTT-123412342"
            );

            var response = await orderApi.CancelGTTOrderAsync(
                cancelRequest,
                origin: "web"
            );

            if (!string.IsNullOrEmpty(response.RawContent) &&
                response.RawContent.Contains("UDAPI100010", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("CancelGTTOrder response is null");
                return;
            }

            // Check for success status
            if (result.Status != GttTriggerOrderResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("CancelGTTOrder test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("CancelGTTOrder data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the CancelOrder API functionality
        /// </summary>
        public static async Task PrintCancelOrderTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing OrderV3 API (CancelOrder) ===");

            var orderApi = services.GetRequiredService<IOrderV3Api>();
            var response = await orderApi.CancelOrderAsync(
                orderId: "251211000484254"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Order Id: {result.Data.OrderId}");

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
                Console.WriteLine("CancelOrder response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityCancelOrderTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderV3Api>();
            var response = await orderApi.CancelOrderAsync(
                orderId: "23421342"
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
                Console.WriteLine("CancelOrder response is null");
                return;
            }

            // Check for success status
            if (result.Status != CancelOrderV3Response.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("CancelOrder test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("CancelOrder data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetGttOrderDetails API functionality
        /// </summary>
        public static async Task PrintGetGttOrderDetailsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing OrderV3 API (GetGttOrderDetails) ===");

            var orderApi = services.GetRequiredService<IOrderV3Api>();
            var response = await orderApi.GetGttOrderDetailsAsync(
                gttOrderId: "GTT-C25111200275518"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  GTT Orders Count: {result.Data.Count}");
                    var firstOrder = result.Data[0];
                    Console.WriteLine($"  First GTT Order Id: {firstOrder.GttOrderId}");
                    Console.WriteLine($"  Type: {firstOrder.Type}");
                    Console.WriteLine($"  Instrument Token: {firstOrder.InstrumentToken}");

                    if (firstOrder.Rules != null && firstOrder.Rules.Count > 0)
                    {
                        Console.WriteLine($"  Rules: {firstOrder.Rules.Count}");
                        foreach (var rule in firstOrder.Rules.Take(2))
                        {
                            Console.WriteLine($"    Strategy: {rule.Strategy}");
                            Console.WriteLine($"    Trigger Type: {rule.TriggerType}");
                            Console.WriteLine($"    Trigger Price: {rule.TriggerPrice}");
                            Console.WriteLine($"    Transaction Type: {rule.TransactionType}");
                        }
                    }

                    // Print additional properties if any
                    if (firstOrder.AdditionalProperties.Count > 0)
                    {
                        Console.WriteLine("  Data Additional Properties:");
                        foreach (var kvp in firstOrder.AdditionalProperties)
                        {
                            Console.WriteLine($"    {kvp.Key}: {kvp.Value}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("  (null or empty)");
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
                Console.WriteLine("GetGttOrderDetails response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetGttOrderDetailsTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderV3Api>();
            var response = await orderApi.GetGttOrderDetailsAsync(
                gttOrderId: "GTT-1234234"
            );

            if (!string.IsNullOrEmpty(response.RawContent) &&
                response.RawContent.Contains("UDAPI100010", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetGttOrderDetails response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetGttOrderResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetGttOrderDetails test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetGttOrderDetails data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the ModifyGTTOrder API functionality
        /// </summary>
        public static async Task PrintModifyGTTOrderTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing OrderV3 API (ModifyGTTOrder) ===");

            var orderApi = services.GetRequiredService<IOrderV3Api>();
            var rules = new List<GttRule>
            {
                new GttRule(
                    strategy: GttRule.StrategyEnum.ENTRY,
                    triggerType: GttRule.TriggerTypeEnum.ABOVE,
                    triggerPrice: 2
                )
            };
            var modifyRequest = new GttModifyOrderRequest(
                rules: rules,
                type: GttModifyOrderRequest.TypeEnum.SINGLE,
                quantity: 1,
                gttOrderId: "GTT-C25111200273527"
            );

            var response = await orderApi.ModifyGTTOrderAsync(
                modifyRequest,
                origin: "web"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  GTT Order Ids: {string.Join(", ", result.Data.GttOrderIds ?? new List<string>())}");

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
                Console.WriteLine("ModifyGTTOrder response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityModifyGTTOrderTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderV3Api>();
            var rules = new List<GttRule>
            {
                new GttRule(
                    strategy: GttRule.StrategyEnum.ENTRY,
                    triggerType: GttRule.TriggerTypeEnum.ABOVE,
                    triggerPrice: 950.0
                )
            };
            var modifyRequest = new GttModifyOrderRequest(
                rules: rules,
                type: GttModifyOrderRequest.TypeEnum.SINGLE,
                quantity: 1,
                gttOrderId: "GTT-C25111200273"
            );

            var response = await orderApi.ModifyGTTOrderAsync(
                modifyRequest,
                origin: "web"
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
                Console.WriteLine("ModifyGTTOrder response is null");
                return;
            }

            // Check for success status
            if (result.Status != GttTriggerOrderResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("ModifyGTTOrder test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("ModifyGTTOrder data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the ModifyOrder API functionality
        /// </summary>
        public static async Task PrintModifyOrderTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing OrderV3 API (ModifyOrder) ===");

            var orderApi = services.GetRequiredService<IOrderV3Api>();
            var modifyRequest = new ModifyOrderRequest(
                quantity: 1,
                price: 1.5f,
                orderId: "251211000484254",
                orderType: ModifyOrderRequest.OrderTypeEnum.LIMIT,
                triggerPrice: 0.0f,
                disclosedQuantity: 0,
                validity: ModifyOrderRequest.ValidityEnum.DAY
            );

            var response = await orderApi.ModifyOrderAsync(modifyRequest);
            var result = response.Ok();
            Console.WriteLine($"Response: {response.RawContent}");
            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Order Id: {result.Data.OrderId}");

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
                Console.WriteLine("ModifyOrder response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityModifyOrderTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderV3Api>();
            var modifyRequest = new ModifyOrderRequest(
                quantity: 1,
                price: 1.5f,
                orderId: "123242314",
                orderType: ModifyOrderRequest.OrderTypeEnum.LIMIT,
                triggerPrice: 0.0f,
                disclosedQuantity: 0,
                validity: ModifyOrderRequest.ValidityEnum.DAY
            );

            var response = await orderApi.ModifyOrderAsync(modifyRequest);
            if (!string.IsNullOrEmpty(response.RawContent) &&
                response.RawContent.Contains("UDAPI100010", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine($"Response: {response.RawContent}");
                Console.WriteLine("ModifyOrder response is null");
                return;
            }

            // Check for success status
            if (result.Status != ModifyOrderV3Response.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("ModifyOrder test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("ModifyOrder data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the PlaceGTTOrder API functionality
        /// </summary>
        public static async Task PrintPlaceGTTOrderTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing OrderV3 API (PlaceGTTOrder) ===");

            var orderApi = services.GetRequiredService<IOrderV3Api>();
            var rules = new List<GttRule>
            {
                new GttRule(
                    strategy: GttRule.StrategyEnum.ENTRY,
                    triggerType: GttRule.TriggerTypeEnum.ABOVE,
                    triggerPrice: 950.0
                )
            };
            var placeRequest = new GttPlaceOrderRequest(
                rules: rules,
                type: GttPlaceOrderRequest.TypeEnum.SINGLE,
                quantity: 1,
                product: GttPlaceOrderRequest.ProductEnum.I,
                instrumentToken: "NSE_EQ|INE669E01016",
                transactionType: GttPlaceOrderRequest.TransactionTypeEnum.BUY
            );

            var response = await orderApi.PlaceGTTOrderAsync(
                placeRequest,
                origin: "web"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  GTT Order Ids: {string.Join(", ", result.Data.GttOrderIds ?? new List<string>())}");

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
                Console.WriteLine("PlaceGTTOrder response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityPlaceGTTOrderTest(IServiceProvider services)
        {
            var orderApi = services.GetRequiredService<IOrderV3Api>();
            var rules = new List<GttRule>
            {
                new GttRule(
                    strategy: GttRule.StrategyEnum.ENTRY,
                    triggerType: GttRule.TriggerTypeEnum.ABOVE,
                    triggerPrice: 950.0
                )
            };
            var placeRequest = new GttPlaceOrderRequest(
                rules: rules,
                type: GttPlaceOrderRequest.TypeEnum.SINGLE,
                quantity: 1,
                product: GttPlaceOrderRequest.ProductEnum.I,
                instrumentToken: "NSE_EQ|INE669E01016",
                transactionType: GttPlaceOrderRequest.TransactionTypeEnum.BUY
            );

            var response = await orderApi.PlaceGTTOrderAsync(
                placeRequest,
                origin: "web"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine($"Response: {response.RawContent}");
                Console.WriteLine("PlaceGTTOrder response is null");
                return;
            }

            // Check for success status
            if (result.Status != GttTriggerOrderResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("PlaceGTTOrder test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("PlaceGTTOrder data is null");
                return;
            }
        }
    }
}
