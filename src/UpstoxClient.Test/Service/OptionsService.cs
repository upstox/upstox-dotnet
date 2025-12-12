using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class OptionsService
    {
        /// <summary>
        /// Tests the GetOptionContracts API functionality
        /// </summary>
        public static async Task PrintGetOptionContractsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Options API (GetOptionContracts) ===");

            var optionsApi = services.GetRequiredService<IOptionsApi>();
            var response = await optionsApi.GetOptionContractsAsync(
                instrumentKey: "NSE_INDEX|Nifty 50"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} option contracts");
                    foreach (var contract in result.Data.Take(3)) // Show first 3 for brevity
                    {
                        Console.WriteLine($"    Instrument Key: {contract.InstrumentKey}");
                        Console.WriteLine($"    Trading Symbol: {contract.TradingSymbol}");
                        Console.WriteLine($"    Name: {contract.Name}");
                        Console.WriteLine($"    Expiry: {contract.Expiry}");
                        Console.WriteLine($"    Strike Price: {contract.StrikePrice}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no option contracts found)");
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
                Console.WriteLine("GetOptionContracts response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetOptionContractsTest(IServiceProvider services)
        {
            var optionsApi = services.GetRequiredService<IOptionsApi>();
            var response = await optionsApi.GetOptionContractsAsync(
                instrumentKey: "NSE_INDEX|NIFTY_50"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetOptionContracts response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetOptionContractResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetOptionContracts test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetOptionContracts data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetPutCallOptionChain API functionality
        /// </summary>
        public static async Task PrintGetPutCallOptionChainTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Options API (GetPutCallOptionChain) ===");

            var optionsApi = services.GetRequiredService<IOptionsApi>();
            var response = await optionsApi.GetPutCallOptionChainAsync(
                instrumentKey: "NSE_INDEX|NIFTY_50",
                expiryDate: "2025-12-30"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Found {result.Data.Count} option strike data");
                    foreach (var strikeData in result.Data.Take(3)) // Show first 3 strike data for brevity
                    {
                        Console.WriteLine($"    Strike Price: {strikeData.StrikePrice}, PCR: {strikeData.Pcr}");

                        if (strikeData.PutOptions != null && strikeData.PutOptions.MarketData != null)
                        {
                            Console.WriteLine($"      Put LTP: {strikeData.PutOptions.MarketData.Ltp}");
                        }
                        else
                        {
                            Console.WriteLine("      Put Options: (no market data)");
                        }

                        if (strikeData.CallOptions != null && strikeData.CallOptions.MarketData != null)
                        {
                            Console.WriteLine($"      Call LTP: {strikeData.CallOptions.MarketData.Ltp}");
                        }
                        else
                        {
                            Console.WriteLine("      Call Options: (no market data)");
                        }

                        // Print additional properties if any
                        if (strikeData.AdditionalProperties.Count > 0)
                        {
                            Console.WriteLine("      Additional Properties:");
                            foreach (var kvp in strikeData.AdditionalProperties)
                            {
                                Console.WriteLine($"        {kvp.Key}: {kvp.Value}");
                            }
                        }
                        Console.WriteLine("      ---");
                    }

                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more strike data");
                    }
                }
                else
                {
                    Console.WriteLine("  (no option chain data found)");
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
                Console.WriteLine("GetPutCallOptionChain response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetPutCallOptionChainTest(IServiceProvider services)
        {
            var optionsApi = services.GetRequiredService<IOptionsApi>();
            var response = await optionsApi.GetPutCallOptionChainAsync(
                instrumentKey: "NSE_INDEX|NIFTY_50",
                expiryDate: "2025-12-30"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetPutCallOptionChain response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetOptionChainResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetPutCallOptionChain test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetPutCallOptionChain data is null");
                return;
            }
        }
    }
}
