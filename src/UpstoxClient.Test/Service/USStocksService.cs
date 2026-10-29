using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    /// <summary>
    /// Tests for the US Stocks APIs (orders, charges, portfolio, funds, market holidays/timings).
    /// </summary>
    public class USStocksService
    {
        private const string InstrumentKey = "US_EQ|AAPL";

        /// <summary>Place/modify/cancel hit a real account, so they run only with UPSTOX_ENABLE_US_ORDER_WRITE_TESTS=true.</summary>
        private static readonly bool EnableStateChangingUsOrderTests =
            Environment.GetEnvironmentVariable("UPSTOX_ENABLE_US_ORDER_WRITE_TESTS") == "true";

        private static string Today => DateTime.Today.ToString("yyyy-MM-dd");

        private static void PrintAdditional(IDictionary<string, System.Text.Json.JsonElement> props, string indent)
        {
            if (props.Count == 0) return;
            Console.WriteLine($"{indent}AdditionalProperties:");
            foreach (var kvp in props)
                Console.WriteLine($"{indent}  {kvp.Key}: {kvp.Value}");
        }

        private static void PrintOrderBookData(UsOrderBookData? d, string indent)
        {
            if (d == null) { Console.WriteLine($"{indent}(null)"); return; }
            Console.WriteLine($"{indent}OrderId: {d.OrderId}");
            Console.WriteLine($"{indent}Status: {d.Status}");
            Console.WriteLine($"{indent}OrderType: {d.OrderType}");
            Console.WriteLine($"{indent}Name: {d.Name}");
            Console.WriteLine($"{indent}Exchange: {d.Exchange}");
            Console.WriteLine($"{indent}Product: {d.Product}");
            Console.WriteLine($"{indent}Validity: {d.Validity}");
            Console.WriteLine($"{indent}Price: {d.Price}");
            Console.WriteLine($"{indent}Quantity: {d.Quantity}");
            Console.WriteLine($"{indent}Amount: {d.Amount}");
            Console.WriteLine($"{indent}Fractionable: {d.Fractionable}");
            Console.WriteLine($"{indent}Variety: {d.Variety}");
            Console.WriteLine($"{indent}Tag: {d.Tag}");
            Console.WriteLine($"{indent}InstrumentKey: {d.InstrumentKey}");
            Console.WriteLine($"{indent}TradingSymbol: {d.TradingSymbol}");
            Console.WriteLine($"{indent}TransactionType: {d.TransactionType}");
            Console.WriteLine($"{indent}AveragePrice: {d.AveragePrice}");
            Console.WriteLine($"{indent}FilledQuantity: {d.FilledQuantity}");
            Console.WriteLine($"{indent}PendingQuantity: {d.PendingQuantity}");
            Console.WriteLine($"{indent}StatusMessage: {d.StatusMessage}");
            Console.WriteLine($"{indent}StatusMessageRaw: {d.StatusMessageRaw}");
            Console.WriteLine($"{indent}OrderTimestamp: {d.OrderTimestamp}");
            Console.WriteLine($"{indent}ExchangeTimestamp: {d.ExchangeTimestamp}");
            Console.WriteLine($"{indent}IsAmo: {d.IsAmo}");
            PrintAdditional(d.AdditionalProperties, indent);
        }

        private static void PrintHolidays(List<UsHolidayData>? data)
        {
            if (data == null || data.Count == 0) { Console.WriteLine("  (no holidays found)"); return; }
            foreach (var h in data)
            {
                Console.WriteLine($"    Date: {h.Date}");
                Console.WriteLine($"    Description: {h.Description}");
                Console.WriteLine($"    HolidayType: {h.HolidayType}");
                PrintAdditional(h.AdditionalProperties, "    ");
                Console.WriteLine("    ---");
            }
        }

        private static void ThrowIfNull(object? result, UpstoxClient.Client.IApiResponse response, string name)
        {
            if (result != null) return;
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception("Invalid access token");
            throw new Exception($"{name} failed with HTTP {(int)response.StatusCode}: {response.RawContent}");
        }

        private static UsPlaceOrderRequest BuildPlaceRequest() => new UsPlaceOrderRequest(
            quantity: 1m,
            price: 1m,
            validity: UsPlaceOrderRequest.ValidityEnum.DAY,
            tag: "sdk-test",
            instrumentKey: InstrumentKey,
            transactionType: UsPlaceOrderRequest.TransactionTypeEnum.BUY,
            orderType: UsPlaceOrderRequest.OrderTypeEnum.LIMIT);

        private static UsOrderEstimateRequest BuildEstimateRequest() => new UsOrderEstimateRequest(
            quantity: 1m,
            price: 180m,
            instrumentKey: InstrumentKey,
            transactionType: UsOrderEstimateRequest.TransactionTypeEnum.BUY,
            orderType: UsOrderEstimateRequest.OrderTypeEnum.LIMIT);

        /// <summary>Resolves an order id from UPSTOX_TEST_US_ORDER_ID or the first order in the book.</summary>
        private static async Task<string?> ResolveOrderIdAsync(IUSStocksOrderApi api)
        {
            var fromEnv = Environment.GetEnvironmentVariable("UPSTOX_TEST_US_ORDER_ID");
            if (!string.IsNullOrWhiteSpace(fromEnv)) return fromEnv;
            var book = (await api.GetUsOrderBookAsync()).Ok();
            return book?.Data?.FirstOrDefault()?.OrderId;
        }

        // ------------------------------------------------------------------
        // USStocksOrderApi
        // ------------------------------------------------------------------

        public static async Task PrintGetUsOrderBookTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing USStocksOrder API (GetUsOrderBook) ===");
            var api = services.GetRequiredService<IUSStocksOrderApi>();
            var response = await api.GetUsOrderBookAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} US orders");
                    foreach (var item in result.Data)
                    {
                        PrintOrderBookData(item, "    ");
                        Console.WriteLine("    ---");
                    }
                }
                else
                {
                    Console.WriteLine("  (no US orders found)");
                }
                PrintAdditional(result.AdditionalProperties, "");
            }
            else
            {
                Console.WriteLine($"GetUsOrderBook response is null (HTTP {(int)response.StatusCode}): {response.RawContent}");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetUsOrderBookTest(IServiceProvider services)
        {
            var api = services.GetRequiredService<IUSStocksOrderApi>();
            var response = await api.GetUsOrderBookAsync();
            var result = response.Ok();
            ThrowIfNull(result, response, "GetUsOrderBook");

            if (result!.Data == null)
                throw new Exception("GetUsOrderBook data is null");

            // An empty book is valid; when orders exist, the identifying fields must be populated.
            if (result.Data.Count > 0)
            {
                var first = result.Data[0];
                if (string.IsNullOrWhiteSpace(first.OrderId))
                    throw new Exception("GetUsOrderBook: Data[0].OrderId is not populated");
                if (string.IsNullOrWhiteSpace(first.InstrumentKey))
                    throw new Exception("GetUsOrderBook: Data[0].InstrumentKey is not populated");
                if (first.Status == null)
                    throw new Exception("GetUsOrderBook: Data[0].Status is not populated");
            }
        }

        public static async Task PrintGetUsOrderDetailsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing USStocksOrder API (GetUsOrderDetails) ===");
            var api = services.GetRequiredService<IUSStocksOrderApi>();
            var orderId = await ResolveOrderIdAsync(api);
            if (orderId == null)
            {
                Console.WriteLine("No US order found, skipping GetUsOrderDetails test");
                Console.WriteLine("==================");
                return;
            }

            var response = await api.GetUsOrderDetailsAsync(orderId);
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                PrintOrderBookData(result.Data, "  ");
                PrintAdditional(result.AdditionalProperties, "");
            }
            else
            {
                Console.WriteLine($"GetUsOrderDetails response is null (HTTP {(int)response.StatusCode}): {response.RawContent}");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetUsOrderDetailsTest(IServiceProvider services)
        {
            var api = services.GetRequiredService<IUSStocksOrderApi>();
            var orderId = await ResolveOrderIdAsync(api);
            if (orderId == null)
            {
                Console.WriteLine("GetUsOrderDetails sanity test skipped: no US order found");
                return;
            }

            var response = await api.GetUsOrderDetailsAsync(orderId);
            var result = response.Ok();
            ThrowIfNull(result, response, "GetUsOrderDetails");

            if (result!.Data == null)
                throw new Exception("GetUsOrderDetails data is null");
            if (result.Data.OrderId != orderId)
                throw new Exception($"GetUsOrderDetails: OrderId mismatch ({result.Data.OrderId} != {orderId})");
            if (string.IsNullOrWhiteSpace(result.Data.InstrumentKey))
                throw new Exception("GetUsOrderDetails: InstrumentKey is not populated");
        }

        public static async Task PrintEstimateUsOrderTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing USStocksOrder API (EstimateUsOrder) ===");
            var api = services.GetRequiredService<IUSStocksOrderApi>();
            var response = await api.EstimateUsOrderAsync(BuildEstimateRequest());
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                var d = result.Data;
                if (d != null)
                {
                    Console.WriteLine($"  Brokerage: {d.Brokerage}");
                    Console.WriteLine($"  Gst: {d.Gst}");
                    Console.WriteLine($"  TradeValue: {d.TradeValue}");
                    Console.WriteLine($"  RegulatoryFee: {d.RegulatoryFee}");
                    Console.WriteLine($"  TafFee: {d.TafFee}");
                    Console.WriteLine($"  CatFee: {d.CatFee}");
                    Console.WriteLine($"  TotalCharges: {d.TotalCharges}");
                    Console.WriteLine($"  EstimatedTotal: {d.EstimatedTotal}");
                    PrintAdditional(d.AdditionalProperties, "  ");
                }
                else
                {
                    Console.WriteLine("  (null)");
                }
                PrintAdditional(result.AdditionalProperties, "");
            }
            else
            {
                Console.WriteLine($"EstimateUsOrder response is null (HTTP {(int)response.StatusCode}): {response.RawContent}");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityEstimateUsOrderTest(IServiceProvider services)
        {
            var api = services.GetRequiredService<IUSStocksOrderApi>();
            var response = await api.EstimateUsOrderAsync(BuildEstimateRequest());
            var result = response.Ok();
            ThrowIfNull(result, response, "EstimateUsOrder");

            if (result!.Data == null)
                throw new Exception("EstimateUsOrder data is null");
            if (result.Data.TradeValue == null)
                throw new Exception("EstimateUsOrder: TradeValue is not populated");
            if (result.Data.TotalCharges == null)
                throw new Exception("EstimateUsOrder: TotalCharges is not populated");
            if (result.Data.EstimatedTotal == null)
                throw new Exception("EstimateUsOrder: EstimatedTotal is not populated");
        }

        public static async Task PrintPlaceUsOrderTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing USStocksOrder API (PlaceUsOrder) ===");
            if (!EnableStateChangingUsOrderTests)
            {
                Console.WriteLine("SKIPPED: set UPSTOX_ENABLE_US_ORDER_WRITE_TESTS=true to place a real US order.");
                Console.WriteLine("==================");
                return;
            }

            var api = services.GetRequiredService<IUSStocksOrderApi>();
            var response = await api.PlaceUsOrderAsync(BuildPlaceRequest());
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data.OrderId: {result.Data?.OrderId}");
                if (result.Data != null) PrintAdditional(result.Data.AdditionalProperties, "  ");
                PrintAdditional(result.AdditionalProperties, "");
            }
            else
            {
                Console.WriteLine($"PlaceUsOrder response is null (HTTP {(int)response.StatusCode}): {response.RawContent}");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityPlaceUsOrderTest(IServiceProvider services)
        {
            if (!EnableStateChangingUsOrderTests)
            {
                Console.WriteLine("PlaceUsOrder sanity test skipped: set UPSTOX_ENABLE_US_ORDER_WRITE_TESTS=true to run it");
                return;
            }

            var api = services.GetRequiredService<IUSStocksOrderApi>();
            var response = await api.PlaceUsOrderAsync(BuildPlaceRequest());
            var result = response.Ok();
            ThrowIfNull(result, response, "PlaceUsOrder");

            if (string.IsNullOrWhiteSpace(result!.Data?.OrderId))
                throw new Exception("PlaceUsOrder: Data.OrderId is not populated");
        }

        public static async Task PrintModifyUsOrderTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing USStocksOrder API (ModifyUsOrder) ===");
            if (!EnableStateChangingUsOrderTests)
            {
                Console.WriteLine("SKIPPED: set UPSTOX_ENABLE_US_ORDER_WRITE_TESTS=true to modify a real US order.");
                Console.WriteLine("==================");
                return;
            }

            var api = services.GetRequiredService<IUSStocksOrderApi>();
            var orderId = await ResolveOrderIdAsync(api);
            if (orderId == null)
            {
                Console.WriteLine("No US order found, skipping ModifyUsOrder test");
                Console.WriteLine("==================");
                return;
            }

            var response = await api.ModifyUsOrderAsync(BuildModifyRequest(orderId));
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data.OrderId: {result.Data?.OrderId}");
                if (result.Data != null) PrintAdditional(result.Data.AdditionalProperties, "  ");
                PrintAdditional(result.AdditionalProperties, "");
            }
            else
            {
                Console.WriteLine($"ModifyUsOrder response is null (HTTP {(int)response.StatusCode}): {response.RawContent}");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityModifyUsOrderTest(IServiceProvider services)
        {
            if (!EnableStateChangingUsOrderTests)
            {
                Console.WriteLine("ModifyUsOrder sanity test skipped: set UPSTOX_ENABLE_US_ORDER_WRITE_TESTS=true to run it");
                return;
            }

            var api = services.GetRequiredService<IUSStocksOrderApi>();
            var orderId = await ResolveOrderIdAsync(api);
            if (orderId == null)
            {
                Console.WriteLine("ModifyUsOrder sanity test skipped: no US order found");
                return;
            }

            var response = await api.ModifyUsOrderAsync(BuildModifyRequest(orderId));
            var result = response.Ok();
            ThrowIfNull(result, response, "ModifyUsOrder");

            if (string.IsNullOrWhiteSpace(result!.Data?.OrderId))
                throw new Exception("ModifyUsOrder: Data.OrderId is not populated");
        }

        private static UsModifyOrderRequest BuildModifyRequest(string orderId) => new UsModifyOrderRequest(
            quantity: 1m,
            price: 1.05m,
            validity: UsModifyOrderRequest.ValidityEnum.DAY,
            orderId: orderId,
            instrumentKey: InstrumentKey,
            transactionType: UsModifyOrderRequest.TransactionTypeEnum.BUY,
            orderType: UsModifyOrderRequest.OrderTypeEnum.LIMIT);

        public static async Task PrintCancelUsOrderTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing USStocksOrder API (CancelUsOrder) ===");
            if (!EnableStateChangingUsOrderTests)
            {
                Console.WriteLine("SKIPPED: set UPSTOX_ENABLE_US_ORDER_WRITE_TESTS=true to cancel a real US order.");
                Console.WriteLine("==================");
                return;
            }

            var api = services.GetRequiredService<IUSStocksOrderApi>();
            var orderId = await ResolveOrderIdAsync(api);
            if (orderId == null)
            {
                Console.WriteLine("No US order found, skipping CancelUsOrder test");
                Console.WriteLine("==================");
                return;
            }

            var response = await api.CancelUsOrderAsync(orderId);
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data.OrderId: {result.Data?.OrderId}");
                if (result.Data != null) PrintAdditional(result.Data.AdditionalProperties, "  ");
                PrintAdditional(result.AdditionalProperties, "");
            }
            else
            {
                Console.WriteLine($"CancelUsOrder response is null (HTTP {(int)response.StatusCode}): {response.RawContent}");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityCancelUsOrderTest(IServiceProvider services)
        {
            if (!EnableStateChangingUsOrderTests)
            {
                Console.WriteLine("CancelUsOrder sanity test skipped: set UPSTOX_ENABLE_US_ORDER_WRITE_TESTS=true to run it");
                return;
            }

            var api = services.GetRequiredService<IUSStocksOrderApi>();
            var orderId = await ResolveOrderIdAsync(api);
            if (orderId == null)
            {
                Console.WriteLine("CancelUsOrder sanity test skipped: no US order found");
                return;
            }

            var response = await api.CancelUsOrderAsync(orderId);
            var result = response.Ok();
            ThrowIfNull(result, response, "CancelUsOrder");

            if (string.IsNullOrWhiteSpace(result!.Data?.OrderId))
                throw new Exception("CancelUsOrder: Data.OrderId is not populated");
        }

        // ------------------------------------------------------------------
        // USStocksChargesApi
        // ------------------------------------------------------------------

        public static async Task PrintCalculateUsMarginTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing USStocksCharges API (CalculateUsMargin) ===");
            var api = services.GetRequiredService<IUSStocksChargesApi>();
            var response = await api.CalculateUsMarginAsync(new UsMarginRequest(new List<UsOrderEstimateRequest> { BuildEstimateRequest() }));
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                var d = result.Data;
                if (d != null)
                {
                    Console.WriteLine($"  RequiredMargin: {d.RequiredMargin}");
                    Console.WriteLine($"  AvailableToInvest: {d.AvailableToInvest}");
                    Console.WriteLine($"  Shortfall: {d.Shortfall}");
                    Console.WriteLine($"  Sufficient: {d.Sufficient}");
                    Console.WriteLine("  Margins:");
                    foreach (var m in d.Margins ?? new List<UsOrderMargin>())
                    {
                        Console.WriteLine($"    InstrumentKey: {m.InstrumentKey}");
                        Console.WriteLine($"    TransactionType: {m.TransactionType}");
                        Console.WriteLine($"    TradeValue: {m.TradeValue}");
                        Console.WriteLine($"    Brokerage: {m.Brokerage}");
                        Console.WriteLine($"    Gst: {m.Gst}");
                        Console.WriteLine($"    RequiredMargin: {m.RequiredMargin}");
                        PrintAdditional(m.AdditionalProperties, "    ");
                        Console.WriteLine("    ---");
                    }
                    PrintAdditional(d.AdditionalProperties, "  ");
                }
                else
                {
                    Console.WriteLine("  (null)");
                }
                PrintAdditional(result.AdditionalProperties, "");
            }
            else
            {
                Console.WriteLine($"CalculateUsMargin response is null (HTTP {(int)response.StatusCode}): {response.RawContent}");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityCalculateUsMarginTest(IServiceProvider services)
        {
            var api = services.GetRequiredService<IUSStocksChargesApi>();
            var response = await api.CalculateUsMarginAsync(new UsMarginRequest(new List<UsOrderEstimateRequest> { BuildEstimateRequest() }));
            var result = response.Ok();
            ThrowIfNull(result, response, "CalculateUsMargin");

            if (result!.Data == null)
                throw new Exception("CalculateUsMargin data is null");
            if (result.Data.RequiredMargin == null)
                throw new Exception("CalculateUsMargin: RequiredMargin is not populated");
            if (result.Data.Margins == null || result.Data.Margins.Count == 0)
                throw new Exception("CalculateUsMargin: Margins is empty");
            if (result.Data.Margins[0].InstrumentKey != InstrumentKey)
                throw new Exception($"CalculateUsMargin: Margins[0].InstrumentKey mismatch ({result.Data.Margins[0].InstrumentKey})");
        }

        // ------------------------------------------------------------------
        // USStocksPortfolioApi
        // ------------------------------------------------------------------

        public static async Task PrintGetUsHoldingsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing USStocksPortfolio API (GetUsHoldings) ===");
            var api = services.GetRequiredService<IUSStocksPortfolioApi>();
            var response = await api.GetUsHoldingsAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    foreach (var h in result.Data)
                    {
                        Console.WriteLine($"    InstrumentKey: {h.InstrumentKey}");
                        Console.WriteLine($"    TradingSymbol: {h.TradingSymbol}");
                        Console.WriteLine($"    CompanyName: {h.CompanyName}");
                        Console.WriteLine($"    Exchange: {h.Exchange}");
                        Console.WriteLine($"    Quantity: {h.Quantity}");
                        Console.WriteLine($"    AvailableQuantity: {h.AvailableQuantity}");
                        Console.WriteLine($"    AveragePrice: {h.AveragePrice}");
                        Console.WriteLine($"    LastPrice: {h.LastPrice}");
                        Console.WriteLine($"    PreviousClose: {h.PreviousClose}");
                        Console.WriteLine($"    InvestedValue: {h.InvestedValue}");
                        Console.WriteLine($"    CurrentValue: {h.CurrentValue}");
                        Console.WriteLine($"    Pnl: {h.Pnl}");
                        Console.WriteLine($"    DayPnl: {h.DayPnl}");
                        Console.WriteLine($"    TransactionType: {h.TransactionType}");
                        PrintAdditional(h.AdditionalProperties, "    ");
                        Console.WriteLine("    ---");
                    }
                }
                else
                {
                    Console.WriteLine("  (no US holdings found)");
                }
                PrintAdditional(result.AdditionalProperties, "");
            }
            else
            {
                Console.WriteLine($"GetUsHoldings response is null (HTTP {(int)response.StatusCode}): {response.RawContent}");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetUsHoldingsTest(IServiceProvider services)
        {
            var api = services.GetRequiredService<IUSStocksPortfolioApi>();
            var response = await api.GetUsHoldingsAsync();
            var result = response.Ok();
            ThrowIfNull(result, response, "GetUsHoldings");

            if (result!.Data == null)
                throw new Exception("GetUsHoldings data is null");

            // No holdings is valid; when present, the identifying fields must be populated.
            if (result.Data.Count > 0)
            {
                var first = result.Data[0];
                if (string.IsNullOrWhiteSpace(first.InstrumentKey))
                    throw new Exception("GetUsHoldings: Data[0].InstrumentKey is not populated");
                if (first.Quantity == null)
                    throw new Exception("GetUsHoldings: Data[0].Quantity is not populated");
            }
        }

        // ------------------------------------------------------------------
        // USStocksFundsApi
        // ------------------------------------------------------------------

        public static async Task PrintGetUsFundsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing USStocksFunds API (GetUsFunds) ===");
            var api = services.GetRequiredService<IUSStocksFundsApi>();
            var response = await api.GetUsFundsAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                var d = result.Data;
                if (d != null)
                {
                    Console.WriteLine($"  Cash: {d.Cash}");
                    Console.WriteLine($"  AvailableToTrade: {d.AvailableToTrade}");
                    Console.WriteLine($"  AvailableToWithdraw: {d.AvailableToWithdraw}");
                    Console.WriteLine($"  UnsettledCash: {d.UnsettledCash}");
                    Console.WriteLine($"  ExchangeRate: {d.ExchangeRate}");
                    Console.WriteLine($"  CashInr: {d.CashInr}");
                    Console.WriteLine($"  AvailableToTradeInr: {d.AvailableToTradeInr}");
                    Console.WriteLine($"  AvailableToWithdrawInr: {d.AvailableToWithdrawInr}");
                    Console.WriteLine($"  UnsettledCashInr: {d.UnsettledCashInr}");
                    PrintAdditional(d.AdditionalProperties, "  ");
                }
                else
                {
                    Console.WriteLine("  (null)");
                }
                PrintAdditional(result.AdditionalProperties, "");
            }
            else
            {
                Console.WriteLine($"GetUsFunds response is null (HTTP {(int)response.StatusCode}): {response.RawContent}");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetUsFundsTest(IServiceProvider services)
        {
            var api = services.GetRequiredService<IUSStocksFundsApi>();
            var response = await api.GetUsFundsAsync();
            var result = response.Ok();
            ThrowIfNull(result, response, "GetUsFunds");

            if (result!.Data == null)
                throw new Exception("GetUsFunds data is null");
            if (result.Data.AvailableToTrade == null)
                throw new Exception("GetUsFunds: AvailableToTrade is not populated");
            if (result.Data.ExchangeRate == null)
                throw new Exception("GetUsFunds: ExchangeRate is not populated");
        }

        // ------------------------------------------------------------------
        // USMarketHolidaysAndTimingsApi
        // ------------------------------------------------------------------

        public static async Task PrintGetUsExchangeTimingsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing USMarketHolidaysAndTimings API (GetUsExchangeTimings) ===");
            var api = services.GetRequiredService<IUSMarketHolidaysAndTimingsApi>();
            var response = await api.GetUsExchangeTimingsAsync(Today);
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    foreach (var t in result.Data)
                    {
                        Console.WriteLine($"    Exchange: {t.Exchange}");
                        Console.WriteLine($"    StartTime: {t.StartTime}");
                        Console.WriteLine($"    EndTime: {t.EndTime}");
                        Console.WriteLine($"    OvernightStartTime: {t.OvernightStartTime}");
                        Console.WriteLine($"    OvernightEndTime: {t.OvernightEndTime}");
                        PrintAdditional(t.AdditionalProperties, "    ");
                        Console.WriteLine("    ---");
                    }
                }
                else
                {
                    Console.WriteLine("  (no timings found, market may be closed on this date)");
                }
                PrintAdditional(result.AdditionalProperties, "");
            }
            else
            {
                Console.WriteLine($"GetUsExchangeTimings response is null (HTTP {(int)response.StatusCode}): {response.RawContent}");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetUsExchangeTimingsTest(IServiceProvider services)
        {
            var api = services.GetRequiredService<IUSMarketHolidaysAndTimingsApi>();
            var response = await api.GetUsExchangeTimingsAsync(Today);
            var result = response.Ok();
            ThrowIfNull(result, response, "GetUsExchangeTimings");

            if (result!.Data == null)
                throw new Exception("GetUsExchangeTimings data is null");

            // Empty on US market holidays/weekends; otherwise each entry needs exchange + window.
            foreach (var t in result.Data)
            {
                if (string.IsNullOrWhiteSpace(t.Exchange))
                    throw new Exception("GetUsExchangeTimings: Exchange is not populated");
                if (t.StartTime == null || t.EndTime == null)
                    throw new Exception($"GetUsExchangeTimings: StartTime/EndTime missing for {t.Exchange}");
            }
        }

        public static async Task PrintGetUsHolidayTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing USMarketHolidaysAndTimings API (GetUsHoliday) ===");
            var api = services.GetRequiredService<IUSMarketHolidaysAndTimingsApi>();
            var response = await api.GetUsHolidayAsync(Today);
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                PrintHolidays(result.Data);
                PrintAdditional(result.AdditionalProperties, "");
            }
            else
            {
                Console.WriteLine($"GetUsHoliday response is null (HTTP {(int)response.StatusCode}): {response.RawContent}");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetUsHolidayTest(IServiceProvider services)
        {
            var api = services.GetRequiredService<IUSMarketHolidaysAndTimingsApi>();
            var response = await api.GetUsHolidayAsync(Today);
            var result = response.Ok();
            ThrowIfNull(result, response, "GetUsHoliday");

            // A non-holiday date legitimately returns an empty list.
            if (result!.Data == null)
                throw new Exception("GetUsHoliday data is null");
            foreach (var h in result.Data)
                if (string.IsNullOrWhiteSpace(h.Date))
                    throw new Exception("GetUsHoliday: Date is not populated");
        }

        public static async Task PrintGetUsHolidaysTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing USMarketHolidaysAndTimings API (GetUsHolidays) ===");
            var api = services.GetRequiredService<IUSMarketHolidaysAndTimingsApi>();
            var response = await api.GetUsHolidaysAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data ({result.Data?.Count ?? 0} holidays):");
                PrintHolidays(result.Data);
                PrintAdditional(result.AdditionalProperties, "");
            }
            else
            {
                Console.WriteLine($"GetUsHolidays response is null (HTTP {(int)response.StatusCode}): {response.RawContent}");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetUsHolidaysTest(IServiceProvider services)
        {
            var api = services.GetRequiredService<IUSMarketHolidaysAndTimingsApi>();
            var response = await api.GetUsHolidaysAsync();
            var result = response.Ok();
            ThrowIfNull(result, response, "GetUsHolidays");

            if (result!.Data == null || result.Data.Count == 0)
                throw new Exception("GetUsHolidays: holiday list is empty");
            var first = result.Data[0];
            if (string.IsNullOrWhiteSpace(first.Date))
                throw new Exception("GetUsHolidays: Data[0].Date is not populated");
            if (string.IsNullOrWhiteSpace(first.Description))
                throw new Exception("GetUsHolidays: Data[0].Description is not populated");
        }

        public static async Task PrintGetUsMarketStatusTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing USMarketHolidaysAndTimings API (GetUsMarketStatus) ===");
            var api = services.GetRequiredService<IUSMarketHolidaysAndTimingsApi>();
            var response = await api.GetUsMarketStatusAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Exchange: {result.Data.Exchange}");
                    Console.WriteLine($"  Status: {result.Data.Status}");
                    Console.WriteLine($"  LastUpdated: {result.Data.LastUpdated}");
                    PrintAdditional(result.Data.AdditionalProperties, "  ");
                }
                else
                {
                    Console.WriteLine("  (null)");
                }
                PrintAdditional(result.AdditionalProperties, "");
            }
            else
            {
                Console.WriteLine($"GetUsMarketStatus response is null (HTTP {(int)response.StatusCode}): {response.RawContent}");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetUsMarketStatusTest(IServiceProvider services)
        {
            var api = services.GetRequiredService<IUSMarketHolidaysAndTimingsApi>();
            var response = await api.GetUsMarketStatusAsync();
            var result = response.Ok();
            ThrowIfNull(result, response, "GetUsMarketStatus");

            if (result!.Data == null)
                throw new Exception("GetUsMarketStatus data is null");
            if (string.IsNullOrWhiteSpace(result.Data.Exchange))
                throw new Exception("GetUsMarketStatus: Exchange is not populated");
            if (string.IsNullOrWhiteSpace(result.Data.Status))
                throw new Exception("GetUsMarketStatus: Status is not populated");
        }
    }
}
