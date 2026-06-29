using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    /// <summary>
    /// Tests for the Smartlist endpoints folded into <see cref="IMarketApi"/>:
    /// GetSmartlistFutures, GetSmartlistMtf, GetSmartlistOptions.
    /// </summary>
    public class SmartlistService
    {
        public static async Task PrintGetSmartlistFuturesTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Market API (GetSmartlistFutures) ===");
            var marketApi = services.GetRequiredService<IMarketApi>();
            var response = await marketApi.GetSmartlistFuturesAsync(
                assetType: new Option<string?>("STOCK"),
                category: new Option<string?>("TOP_TRADED"),
                pageNumber: new Option<int?>(1),
                pageSize: new Option<int?>(10));
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data: {result.Data?.ToString() ?? "(null)"}");

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
                Console.WriteLine("GetSmartlistFutures response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task PrintGetSmartlistMtfTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Market API (GetSmartlistMtf) ===");
            var marketApi = services.GetRequiredService<IMarketApi>();
            var response = await marketApi.GetSmartlistMtfAsync(
                pageNumber: new Option<int?>(1),
                pageSize: new Option<int?>(10));
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data: {result.Data?.ToString() ?? "(null)"}");

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
                Console.WriteLine("GetSmartlistMtf response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task PrintGetSmartlistOptionsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Market API (GetSmartlistOptions) ===");
            var marketApi = services.GetRequiredService<IMarketApi>();
            var response = await marketApi.GetSmartlistOptionsAsync(
                assetType: new Option<string?>("EQUITY"),
                pageNumber: new Option<int?>(1),
                pageSize: new Option<int?>(10));
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data: {result.Data?.ToString() ?? "(null)"}");

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
                Console.WriteLine("GetSmartlistOptions response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetSmartlistFuturesTest(IServiceProvider services)
        {
            var marketApi = services.GetRequiredService<IMarketApi>();
            var response = await marketApi.GetSmartlistFuturesAsync(
                assetType: new Option<string?>("STOCK"),
                category: new Option<string?>("TOP_TRADED"),
                pageNumber: new Option<int?>(1),
                pageSize: new Option<int?>(10));
            var result = response.Ok();

            if (result == null)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("GetSmartlistFutures: Invalid access token");
                throw new Exception("GetSmartlistFutures response is null");
            }

            if (result.Status == null)
                throw new Exception("GetSmartlistFutures: Status is null");
            if (result.Data == null)
                throw new Exception("GetSmartlistFutures: Data is null");
        }

        public static async Task SanityGetSmartlistMtfTest(IServiceProvider services)
        {
            var marketApi = services.GetRequiredService<IMarketApi>();
            var response = await marketApi.GetSmartlistMtfAsync(
                pageNumber: new Option<int?>(1),
                pageSize: new Option<int?>(10));
            var result = response.Ok();

            if (result == null)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("GetSmartlistMtf: Invalid access token");
                throw new Exception("GetSmartlistMtf response is null");
            }

            if (result.Status == null)
                throw new Exception("GetSmartlistMtf: Status is null");
            if (result.Data == null)
                throw new Exception("GetSmartlistMtf: Data is null");
        }

        public static async Task SanityGetSmartlistOptionsTest(IServiceProvider services)
        {
            var marketApi = services.GetRequiredService<IMarketApi>();
            var response = await marketApi.GetSmartlistOptionsAsync(
                assetType: new Option<string?>("STOCK"),
                category: new Option<string?>("TOP_TRADED"),
                pageNumber: new Option<int?>(1),
                pageSize: new Option<int?>(10));
            var result = response.Ok();

            if (result == null)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("GetSmartlistOptions: Invalid access token");
                throw new Exception("GetSmartlistOptions response is null");
            }

            if (result.Status == null)
                throw new Exception("GetSmartlistOptions: Status is null");
            if (result.Data == null)
                throw new Exception("GetSmartlistOptions: Data is null");
        }
    }
}
