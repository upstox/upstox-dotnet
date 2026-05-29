using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class NewsService
    {
        /// <summary>
        /// Tests the GetNews API functionality
        /// </summary>
        public static async Task PrintGetNewsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing News API (GetNews) ===");

            var newsApi = services.GetRequiredService<INewsApi>();
            var response = await newsApi.GetNewsAsync(
                category: "market"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} news categories");
                    var allItems = result.Data.Values.SelectMany(v => v).Take(3).ToList();
                    Console.WriteLine($"  Showing first 3 news items:");
                    foreach (var item in allItems)
                    {
                        Console.WriteLine($"    Title (Heading): {item.Heading}");
                        Console.WriteLine($"    PublishedAt (PublishedTime): {item.PublishedTime}");
                        Console.WriteLine($"    Source (Thumbnail): {item.Thumbnail}");
                        Console.WriteLine($"    Url (ArticleLink): {item.ArticleLink}");
                        Console.WriteLine("    ---");
                    }
                }
                else
                {
                    Console.WriteLine("  (no news found)");
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
                Console.WriteLine("GetNews response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetNewsTest(IServiceProvider services)
        {
            var newsApi = services.GetRequiredService<INewsApi>();
            var response = await newsApi.GetNewsAsync(
                category: "market"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetNews response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetNewsResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetNews test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetNews data is null");
                return;
            }
        }
    }
}
