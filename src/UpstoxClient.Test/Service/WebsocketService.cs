using Microsoft.Extensions.DependencyInjection;
using System.Net;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class WebsocketService
    {
        /// <summary>
        /// Tests the AuthorizeMarketDataFeed API functionality
        /// </summary>
        public static async Task PrintAuthorizeMarketDataFeedTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Websocket API (AuthorizeMarketDataFeed) ===");

            var websocketApi = services.GetRequiredService<IWebsocketApi>();
            var response = await websocketApi.AuthorizeMarketDataFeedAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Authorized: {result.Status == WebsocketAuthRedirectResponse.StatusEnum.Success}");
                    Console.WriteLine($"  Feed Url: {result.Data.AuthorizedRedirectUri}");

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
                Console.WriteLine("AuthorizeMarketDataFeed response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityAuthorizeMarketDataFeedTest(IServiceProvider services)
        {
            var websocketApi = services.GetRequiredService<IWebsocketApi>();
            var response = await websocketApi.AuthorizeMarketDataFeedAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("AuthorizeMarketDataFeed response is null");
                return;
            }

            // Check for success status
            if (result.Status != WebsocketAuthRedirectResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("AuthorizeMarketDataFeed test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("AuthorizeMarketDataFeed data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetPortfolioStreamFeedAuthorize API functionality
        /// </summary>
        public static async Task PrintGetPortfolioStreamFeedAuthorizeTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Websocket API (GetPortfolioStreamFeedAuthorize) ===");

            var websocketApi = services.GetRequiredService<IWebsocketApi>();
            var response = await websocketApi.GetPortfolioStreamFeedAuthorizeAsync(
                updateTypes: "position,holding"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Authorized: {result.Status == WebsocketAuthRedirectResponse.StatusEnum.Success}");
                    Console.WriteLine($"  Feed Url: {result.Data.AuthorizedRedirectUri}");

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
                Console.WriteLine("GetPortfolioStreamFeedAuthorize response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetPortfolioStreamFeedAuthorizeTest(IServiceProvider services)
        {
            var websocketApi = services.GetRequiredService<IWebsocketApi>();
            var response = await websocketApi.GetPortfolioStreamFeedAuthorizeAsync(
                updateTypes: "position,holding"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetPortfolioStreamFeedAuthorize response is null");
                return;
            }

            // Check for success status
            if (result.Status != WebsocketAuthRedirectResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetPortfolioStreamFeedAuthorize test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetPortfolioStreamFeedAuthorize data is null");
                return;
            }
        }
    }
}
