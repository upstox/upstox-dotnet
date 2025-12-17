using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class ChargeService
    {
        /// <summary>
        /// Tests the GetBrokerage API functionality
        /// </summary>
        public static async Task PrintGetBrokerageTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Charge API (GetBrokerage) ===");

            var chargeApi = services.GetRequiredService<IChargeApi>();
            var response = await chargeApi.GetBrokerageAsync(
                instrumentToken: "NSE_EQ|INE669E01016",
                quantity: 1,
                product: "I",
                transactionType: "BUY",
                price: 1000.0f
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Total: {result.Data.Charges?.Total}");
                    Console.WriteLine($"  Brokerage: {result.Data.Charges?.Brokerage}");

                    // Print additional properties if any
                    if (result.Data.AdditionalProperties.Count > 0)
                    {
                        Console.WriteLine("  Additional Properties:");
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
                Console.WriteLine($"GetBrokerage response: {response.RawContent}");
                if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized){
                    throw new Exception("Invalid access token");
                }
                Console.WriteLine("GetBrokerage response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetBrokerageTest(IServiceProvider services)
        {
            var chargeApi = services.GetRequiredService<IChargeApi>();
            var response = await chargeApi.GetBrokerageAsync(
                instrumentToken: "NSE_EQ|INE669E01016",
                quantity: 1,
                product: "I",
                transactionType: "BUY",
                price: 1000.0f
            );
            var result = response.Ok();

            if (result == null)
            {
                if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized){
                    throw new Exception("Invalid access token");
                }
                Console.WriteLine("GetBrokerage response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetBrokerageResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetBrokerage test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetBrokerage data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the PostMargin API functionality
        /// </summary>
        public static async Task PrintPostMarginTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Charge API (PostMargin) ===");

            var chargeApi = services.GetRequiredService<IChargeApi>();

            // Create a sample instrument for margin calculation
            var instrument = new Instrument(
                instrumentKey: "NSE_EQ|INE669E01016",
                quantity: 1,
                product: "I",
                transactionType: "BUY",
                price: 1000.0f
            );

            var marginRequest = new MarginRequest(new List<Instrument> { instrument });

            var response = await chargeApi.PostMarginAsync(marginRequest);
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  RequiredMargin: {result.Data.RequiredMargin}");
                    Console.WriteLine($"  FinalMargin: {result.Data.FinalMargin}");

                    // Print additional properties if any
                    if (result.Data.AdditionalProperties.Count > 0)
                    {
                        Console.WriteLine("  Additional Properties:");
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
                Console.WriteLine("PostMargin response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityPostMarginTest(IServiceProvider services)
        {
            var chargeApi = services.GetRequiredService<IChargeApi>();

            // Create a sample instrument for margin calculation
            var instrument = new Instrument(
                instrumentKey: "NSE_EQ|INE669E01016",
                quantity: 1,
                product: "I",
                transactionType: "BUY",
                price: 1000.0f
            );

            var marginRequest = new MarginRequest(new List<Instrument> { instrument });

            var response = await chargeApi.PostMarginAsync(marginRequest);
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("PostMargin response is null");
                return;
            }

            // Check for success status
            if (result.Status != PostMarginResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("PostMargin test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("PostMargin data is null");
                return;
            }
        }
    }
}