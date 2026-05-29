using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class MarketExtensionsService
    {
        private static void PrintAnalyticsData(string label, AnalyticsResponse result)
        {
            Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
            if (result.Data != null)
            {
                var json = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine($"Data ({label}):");
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine("Data: (null)");
            }
            if (result.AdditionalProperties.Count > 0)
            {
                Console.WriteLine("Additional Properties:");
                foreach (var kvp in result.AdditionalProperties)
                    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
            }
        }

        private static void AssertAnalyticsData(string name, AnalyticsResponse? result)
        {
            if (result == null)
                throw new Exception($"{name} response is null");
            if (result.Data == null)
                throw new Exception($"{name} data is null");
            // Verify data is a non-empty JSON object/array
            if (result.Data is JsonElement el && el.ValueKind == JsonValueKind.Null)
                throw new Exception($"{name} data is JSON null");
        }

        // ── GetOiData ─────────────────────────────────────────────────────────

        public static async Task PrintGetOiDataTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketExtensions API (GetOiData) ===");
            var api = (MarketApi)services.GetRequiredService<IMarketApi>();
            var response = await api.GetOiDataAsync(
                instrumentKey: "NSE_INDEX|Nifty 50",
                expiry: "2026-06-02",
                date: "2026-05-23"
            );
            var result = response.Ok();
            if (result != null)
                PrintAnalyticsData("OiData", result);
            else
                Console.WriteLine("GetOiData response is null");
            Console.WriteLine("==================");
        }

        public static async Task SanityGetOiDataTest(IServiceProvider services)
        {
            var api = (MarketApi)services.GetRequiredService<IMarketApi>();
            var response = await api.GetOiDataAsync(
                instrumentKey: "NSE_INDEX|Nifty 50",
                expiry: "2026-06-02",
                date: "2026-05-23"
            );
            AssertAnalyticsData("GetOiData", response.Ok());
        }

        // ── GetChangeOiData ───────────────────────────────────────────────────

        public static async Task PrintGetChangeOiDataTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketExtensions API (GetChangeOiData) ===");
            var api = (MarketApi)services.GetRequiredService<IMarketApi>();
            var response = await api.GetChangeOiDataAsync(
                instrumentKey: "NSE_INDEX|Nifty 50",
                expiry: "2026-06-02",
                date: "2026-05-23",
                interval: 1
            );
            var result = response.Ok();
            if (result != null)
                PrintAnalyticsData("ChangeOiData", result);
            else
                Console.WriteLine("GetChangeOiData response is null");
            Console.WriteLine("==================");
        }

        public static async Task SanityGetChangeOiDataTest(IServiceProvider services)
        {
            var api = (MarketApi)services.GetRequiredService<IMarketApi>();
            var response = await api.GetChangeOiDataAsync(
                instrumentKey: "NSE_INDEX|Nifty 50",
                expiry: "2026-06-02",
                date: "2026-05-23",
                interval: 1
            );
            AssertAnalyticsData("GetChangeOiData", response.Ok());
        }

        // ── GetPcrData ────────────────────────────────────────────────────────

        public static async Task PrintGetPcrDataTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketExtensions API (GetPcrData) ===");
            var api = (MarketApi)services.GetRequiredService<IMarketApi>();
            var response = await api.GetPcrDataAsync(
                instrumentKey: "NSE_INDEX|Nifty 50",
                expiry: "2026-06-02",
                date: "2026-05-23",
                bucketInterval: 1
            );
            var result = response.Ok();
            if (result != null)
                PrintAnalyticsData("PcrData", result);
            else
                Console.WriteLine("GetPcrData response is null");
            Console.WriteLine("==================");
        }

        public static async Task SanityGetPcrDataTest(IServiceProvider services)
        {
            var api = (MarketApi)services.GetRequiredService<IMarketApi>();
            var response = await api.GetPcrDataAsync(
                instrumentKey: "NSE_INDEX|Nifty 50",
                expiry: "2026-06-02",
                date: "2026-05-23",
                bucketInterval: 1
            );
            AssertAnalyticsData("GetPcrData", response.Ok());
        }

        // ── GetMaxPainData ────────────────────────────────────────────────────

        public static async Task PrintGetMaxPainDataTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketExtensions API (GetMaxPainData) ===");
            var api = (MarketApi)services.GetRequiredService<IMarketApi>();
            var response = await api.GetMaxPainDataAsync(
                instrumentKey: "NSE_INDEX|Nifty 50",
                expiry: "2026-06-02",
                date: "2026-05-23",
                bucketInterval: 1
            );
            var result = response.Ok();
            if (result != null)
                PrintAnalyticsData("MaxPainData", result);
            else
                Console.WriteLine("GetMaxPainData response is null");
            Console.WriteLine("==================");
        }

        public static async Task SanityGetMaxPainDataTest(IServiceProvider services)
        {
            var api = (MarketApi)services.GetRequiredService<IMarketApi>();
            var response = await api.GetMaxPainDataAsync(
                instrumentKey: "NSE_INDEX|Nifty 50",
                expiry: "2026-06-02",
                date: "2026-05-23",
                bucketInterval: 1
            );
            AssertAnalyticsData("GetMaxPainData", response.Ok());
        }

        // ── GetFiiData ────────────────────────────────────────────────────────

        public static async Task PrintGetFiiDataTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketExtensions API (GetFiiData) ===");
            var api = (MarketApi)services.GetRequiredService<IMarketApi>();
            var response = await api.GetFiiDataAsync(
                dataType: "NSE_FO|INDEX_FUTURES",
                interval: "1D"
            );
            var result = response.Ok();
            if (result != null)
                PrintAnalyticsData("FiiData", result);
            else
                Console.WriteLine("GetFiiData response is null");
            Console.WriteLine("==================");
        }

        public static async Task SanityGetFiiDataTest(IServiceProvider services)
        {
            var api = (MarketApi)services.GetRequiredService<IMarketApi>();
            var response = await api.GetFiiDataAsync(
                dataType: "NSE_EQ|CASH",
                interval: "1D"
            );
            AssertAnalyticsData("GetFiiData", response.Ok());
        }

        // ── GetDiiData ────────────────────────────────────────────────────────

        public static async Task PrintGetDiiDataTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketExtensions API (GetDiiData) ===");
            var api = (MarketApi)services.GetRequiredService<IMarketApi>();
            var response = await api.GetDiiDataAsync(
                dataType: "NSE_EQ|CASH",
                interval: "1D"
            );
            var result = response.Ok();
            if (result != null)
                PrintAnalyticsData("DiiData", result);
            else
                Console.WriteLine("GetDiiData response is null");
            Console.WriteLine("==================");
        }

        public static async Task SanityGetDiiDataTest(IServiceProvider services)
        {
            var api = (MarketApi)services.GetRequiredService<IMarketApi>();
            var response = await api.GetDiiDataAsync(
                dataType: "NSE_EQ|CASH",
                interval: "1D"
            );
            AssertAnalyticsData("GetDiiData", response.Ok());
        }
    }
}
