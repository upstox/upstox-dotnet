using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class MarketHolidaysAndTimingsService
    {
        /// <summary>
        /// Tests the GetExchangeTimings API functionality
        /// </summary>
        public static async Task PrintGetExchangeTimingsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketHolidaysAndTimings API (GetExchangeTimings) ===");

            var marketApi = services.GetRequiredService<IMarketHolidaysAndTimingsApi>();
            var response = await marketApi.GetExchangeTimingsAsync(
                date: "2024-12-04"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} exchange timings");
                    foreach (var timing in result.Data.Take(3)) // Show first 3 for brevity
                    {
                        Console.WriteLine($"    Exchange: {timing.Exchange}");
                        Console.WriteLine($"    StartTime: {timing.StartTime}");
                        Console.WriteLine($"    EndTime: {timing.EndTime}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no exchange timings found)");
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
                Console.WriteLine("GetExchangeTimings response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetExchangeTimingsTest(IServiceProvider services)
        {
            var marketApi = services.GetRequiredService<IMarketHolidaysAndTimingsApi>();
            var response = await marketApi.GetExchangeTimingsAsync(
                date: "2024-12-04"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetExchangeTimings response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetExchangeTimingResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetExchangeTimings test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetExchangeTimings data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetHoliday API functionality
        /// </summary>
        public static async Task PrintGetHolidayTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketHolidaysAndTimings API (GetHoliday) ===");

            var marketApi = services.GetRequiredService<IMarketHolidaysAndTimingsApi>();
            var response = await marketApi.GetHolidayAsync(
                date: "2024-12-25"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} holidays");
                    foreach (var holiday in result.Data.Take(3)) // Show first 3 for brevity
                    {
                        Console.WriteLine($"    Date: {holiday.Date}");
                        Console.WriteLine($"    Description: {holiday.Description}");
                        Console.WriteLine($"    ClosedExchanges: {string.Join(", ", holiday.ClosedExchanges ?? new List<string>())}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no holidays found)");
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
                Console.WriteLine("GetHoliday response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetHolidayTest(IServiceProvider services)
        {
            var marketApi = services.GetRequiredService<IMarketHolidaysAndTimingsApi>();
            var response = await marketApi.GetHolidayAsync(
                date: "2024-12-25"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetHoliday response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetHolidayResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetHoliday test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetHoliday data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetHolidays API functionality
        /// </summary>
        public static async Task PrintGetHolidaysTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketHolidaysAndTimings API (GetHolidays) ===");

            var marketApi = services.GetRequiredService<IMarketHolidaysAndTimingsApi>();
            var response = await marketApi.GetHolidaysAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} holidays");
                    foreach (var holiday in result.Data.Take(5)) // Show first 5 for brevity
                    {
                        Console.WriteLine($"    Date: {holiday.Date}");
                        Console.WriteLine($"    Description: {holiday.Description}");
                        Console.WriteLine($"    ClosedExchanges: {string.Join(", ", holiday.ClosedExchanges ?? new List<string>())}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 5)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 5} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no holidays found)");
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
                Console.WriteLine("GetHolidays response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetHolidaysTest(IServiceProvider services)
        {
            var marketApi = services.GetRequiredService<IMarketHolidaysAndTimingsApi>();
            var response = await marketApi.GetHolidaysAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetHolidays response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetHolidayResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetHolidays test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetHolidays data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetMarketStatus API functionality
        /// </summary>
        public static async Task PrintGetMarketStatusTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing MarketHolidaysAndTimings API (GetMarketStatus) ===");

            var marketApi = services.GetRequiredService<IMarketHolidaysAndTimingsApi>();
            var response = await marketApi.GetMarketStatusAsync(
                exchange: "NSE"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Market status for requested exchange:");
                    Console.WriteLine($"    Exchange: {result.Data.Exchange}");
                    Console.WriteLine($"    Status: {result.Data.Status}");
                    Console.WriteLine($"    LastUpdated: {result.Data.LastUpdated}");
                }
                else
                {
                    Console.WriteLine("  (no market status data found)");
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
                Console.WriteLine("GetMarketStatus response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetMarketStatusTest(IServiceProvider services)
        {
            var marketApi = services.GetRequiredService<IMarketHolidaysAndTimingsApi>();
            var response = await marketApi.GetMarketStatusAsync(
                exchange: "NSE"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetMarketStatus response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetMarketStatusResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetMarketStatus test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetMarketStatus data is null");
                return;
            }

            // Validate required fields
            if (string.IsNullOrEmpty(result.Data.Exchange))
            {
                Console.WriteLine("GetMarketStatus exchange is null or empty");
                return;
            }

            if (string.IsNullOrEmpty(result.Data.Status))
            {
                Console.WriteLine("GetMarketStatus status is null or empty");
                return;
            }
        }
    }
}
