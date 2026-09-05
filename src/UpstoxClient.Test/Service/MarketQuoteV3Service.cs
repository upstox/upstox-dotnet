using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class MarketQuoteV3Service
    {
        /// <summary>
        /// Tests the GetFullMarketQuoteV3 API functionality
        /// </summary>
        public static async Task PrintGetFullMarketQuoteV3Test(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketQuoteV3 API (GetFullMarketQuoteV3) ===");

            var marketApi = services.GetRequiredService<IMarketQuoteV3Api>();
            var response = await marketApi.GetFullMarketQuoteV3Async(
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} full market quotes");
                    foreach (var kvp in result.Data)
                    {
                        var q = kvp.Value;
                        Console.WriteLine($"    Key: {kvp.Key}");
                        Console.WriteLine($"      InstrumentToken: {q?.InstrumentToken}");
                        Console.WriteLine($"      Symbol: {q?.Symbol}");
                        Console.WriteLine($"      Timestamp: {q?.Timestamp}");
                        Console.WriteLine($"      LastPrice: {q?.LastPrice}");
                        Console.WriteLine($"      LastTradeTime: {q?.LastTradeTime}");
                        Console.WriteLine($"      Volume: {q?.Volume}");
                        Console.WriteLine($"      AveragePrice: {q?.AveragePrice}");
                        Console.WriteLine($"      Oi: {q?.Oi}");
                        Console.WriteLine($"      NetChange: {q?.NetChange}");
                        Console.WriteLine($"      TotalBuyQuantity: {q?.TotalBuyQuantity}");
                        Console.WriteLine($"      TotalSellQuantity: {q?.TotalSellQuantity}");
                        Console.WriteLine($"      LowerCircuitLimit: {q?.LowerCircuitLimit}");
                        Console.WriteLine($"      UpperCircuitLimit: {q?.UpperCircuitLimit}");
                        Console.WriteLine($"      OiDayHigh: {q?.OiDayHigh}");
                        Console.WriteLine($"      OiDayLow: {q?.OiDayLow}");
                        Console.WriteLine($"      PrevClosePrice: {q?.PrevClosePrice}");
                        Console.WriteLine($"      PreviousOi: {q?.PreviousOi}");
                        Console.WriteLine($"      YearHigh: {q?.YearHigh}");
                        Console.WriteLine($"      YearLow: {q?.YearLow}");
                        Console.WriteLine($"      IndicativeEquilibriumPrice: {q?.IndicativeEquilibriumPrice}");
                        Console.WriteLine($"      IndicativeEquilibriumQuantity: {q?.IndicativeEquilibriumQuantity}");
                        Console.WriteLine($"      IndicativeImbalanceQuantityTotal: {q?.IndicativeImbalanceQuantityTotal}");
                        Console.WriteLine($"      IndicativeImbalanceQuantityMarket: {q?.IndicativeImbalanceQuantityMarket}");
                        Console.WriteLine($"      ReferencePrice: {q?.ReferencePrice}");
                        Console.WriteLine($"      CasEligible: {q?.CasEligible}");

                        Console.WriteLine($"      Ohlc:");
                        Console.WriteLine($"        Open: {q?.Ohlc?.Open}");
                        Console.WriteLine($"        High: {q?.Ohlc?.High}");
                        Console.WriteLine($"        Low: {q?.Ohlc?.Low}");
                        Console.WriteLine($"        Close: {q?.Ohlc?.Close}");
                        Console.WriteLine($"        Volume: {q?.Ohlc?.Volume}");
                        Console.WriteLine($"        Ts: {q?.Ohlc?.Ts}");
                        if (q?.Ohlc?.AdditionalProperties != null)
                        {
                            foreach (var extra in q.Ohlc.AdditionalProperties)
                                Console.WriteLine($"        [extra] {extra.Key}: {extra.Value}");
                        }

                        Console.WriteLine($"      Depth:");
                        if (q?.Depth?.Buy != null)
                        {
                            foreach (var level in q.Depth.Buy)
                                Console.WriteLine($"        Buy  -> Quantity: {level?.Quantity}, Price: {level?.Price}, Orders: {level?.Orders}");
                        }
                        if (q?.Depth?.Sell != null)
                        {
                            foreach (var level in q.Depth.Sell)
                                Console.WriteLine($"        Sell -> Quantity: {level?.Quantity}, Price: {level?.Price}, Orders: {level?.Orders}");
                        }
                        if (q?.Depth?.AdditionalProperties != null)
                        {
                            foreach (var extra in q.Depth.AdditionalProperties)
                                Console.WriteLine($"        [extra] {extra.Key}: {extra.Value}");
                        }

                        if (q?.AdditionalProperties != null && q.AdditionalProperties.Count > 0)
                        {
                            Console.WriteLine($"      Additional Properties:");
                            foreach (var extra in q.AdditionalProperties)
                                Console.WriteLine($"        {extra.Key}: {extra.Value}");
                        }
                        Console.WriteLine("      ---");
                    }
                }
                else
                {
                    Console.WriteLine("  (no full market quote data found)");
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
                Console.WriteLine($"GetFullMarketQuoteV3 failed with HTTP {(int)response.StatusCode}: {response.RawContent}");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetFullMarketQuoteV3Test(IServiceProvider services)
        {
            var marketApi = services.GetRequiredService<IMarketQuoteV3Api>();
            var response = await marketApi.GetFullMarketQuoteV3Async(
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result == null)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception($"GetFullMarketQuoteV3: invalid access token (HTTP 401): {response.RawContent}");
                throw new Exception($"GetFullMarketQuoteV3 failed with HTTP {(int)response.StatusCode}: {response.RawContent}");
            }

            if (result.Data == null)
                throw new Exception($"GetFullMarketQuoteV3 data is null (HTTP {(int)response.StatusCode}): {response.RawContent}");

            if (result.Data.Count == 0)
                throw new Exception($"GetFullMarketQuoteV3 returned no quotes (HTTP {(int)response.StatusCode}): {response.RawContent}");

            foreach (var kvp in result.Data)
            {
                var quote = kvp.Value;

                if (quote == null)
                    throw new Exception($"GetFullMarketQuoteV3: quote for '{kvp.Key}' is null");

                if (string.IsNullOrEmpty(quote.InstrumentToken))
                    throw new Exception($"GetFullMarketQuoteV3: InstrumentToken is empty for '{kvp.Key}'");

                if (quote.LastPrice == null)
                    throw new Exception($"GetFullMarketQuoteV3: LastPrice is null for '{kvp.Key}'");

                if (quote.Ohlc == null)
                    throw new Exception($"GetFullMarketQuoteV3: Ohlc is null for '{kvp.Key}'");

                if (quote.Ohlc.Close == null)
                    throw new Exception($"GetFullMarketQuoteV3: Ohlc.Close is null for '{kvp.Key}'");

                if (quote.Depth == null)
                    throw new Exception($"GetFullMarketQuoteV3: Depth is null for '{kvp.Key}'");
            }
        }

        /// <summary>
        /// Tests the GetLtp API functionality
        /// </summary>
        public static async Task PrintGetLtpTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketQuoteV3 API (GetLtp) ===");

            var marketApi = services.GetRequiredService<IMarketQuoteV3Api>();
            var response = await marketApi.GetLtpAsync(
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} LTP quotes");
                    foreach (var kvp in result.Data.Take(1)) // Show first 1 for brevity
                    {
                        Console.WriteLine($"    Instrument Key: {kvp.Key}");
                        Console.WriteLine($"    Last Price: {kvp.Value.LastPrice}");
                        Console.WriteLine($"    Volume: {kvp.Value.Volume}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 1)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 1} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no LTP data found)");
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
                Console.WriteLine("GetLtp response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetLtpTest(IServiceProvider services)
        {
            var marketApi = services.GetRequiredService<IMarketQuoteV3Api>();
            var response = await marketApi.GetLtpAsync(
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetLtp response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetMarketQuoteLastTradedPriceResponseV3.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetLtp test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetLtp data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetMarketQuoteOHLCV3 API functionality
        /// </summary>
        public static async Task PrintGetMarketQuoteOHLCV3Test(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketQuoteV3 API (GetMarketQuoteOHLCV3) ===");

            var marketApi = services.GetRequiredService<IMarketQuoteV3Api>();
            var response = await marketApi.GetMarketQuoteOHLCV3Async(
                interval: "I1",
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} OHLC quotes");
                    foreach (var kvp in result.Data.Take(1)) // Show first 1 for brevity
                    {
                        Console.WriteLine($"    Instrument Key: {kvp.Key}");
                        Console.WriteLine($"    OHLC: O={kvp.Value.LiveOhlc?.Open}, H={kvp.Value.LiveOhlc?.High}, L={kvp.Value.LiveOhlc?.Low}, C={kvp.Value.LiveOhlc?.Close}");
                        Console.WriteLine($"    Volume: {kvp.Value.LiveOhlc?.Volume}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 1)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 1} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no OHLC data found)");
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
                Console.WriteLine("GetMarketQuoteOHLCV3 response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetMarketQuoteOHLCV3Test(IServiceProvider services)
        {
            var marketApi = services.GetRequiredService<IMarketQuoteV3Api>();
            var response = await marketApi.GetMarketQuoteOHLCV3Async(
                interval: "I1",
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetMarketQuoteOHLCV3 response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetMarketQuoteOHLCResponseV3.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetMarketQuoteOHLCV3 test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetMarketQuoteOHLCV3 data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetMarketQuoteOptionGreek API functionality
        /// </summary>
        public static async Task PrintGetMarketQuoteOptionGreekTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketQuoteV3 API (GetMarketQuoteOptionGreek) ===");

            var marketApi = services.GetRequiredService<IMarketQuoteV3Api>();
            var response = await marketApi.GetMarketQuoteOptionGreekAsync(
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} option greek quotes");
                    foreach (var kvp in result.Data.Take(1)) // Show first 1 for brevity
                    {
                        Console.WriteLine($"    Instrument Key: {kvp.Key}");
                        Console.WriteLine($"    Delta: {kvp.Value.Delta}");
                        Console.WriteLine($"    Gamma: {kvp.Value.Gamma}");
                        Console.WriteLine($"    Theta: {kvp.Value.Theta}");
                        Console.WriteLine($"    Vega: {kvp.Value.Vega}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 1)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 1} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no option greek data found)");
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
                Console.WriteLine("GetMarketQuoteOptionGreek response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetMarketQuoteOptionGreekTest(IServiceProvider services)
        {
            var marketApi = services.GetRequiredService<IMarketQuoteV3Api>();
            var response = await marketApi.GetMarketQuoteOptionGreekAsync(
                instrumentKey: "NSE_EQ|INE669E01016"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetMarketQuoteOptionGreek response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetMarketQuoteOptionGreekResponseV3.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetMarketQuoteOptionGreek test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetMarketQuoteOptionGreek data is null");
                return;
            }
        }
    }
}
