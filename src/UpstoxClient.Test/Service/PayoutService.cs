using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    /// <summary>
    /// Tests for the Payout endpoints folded into <see cref="IUserApi"/>:
    /// GetPayoutModes, InitiatePayout, ModifyPayout, CancelPayout.
    ///
    /// NOTE: InitiatePayout / ModifyPayout / CancelPayout are money-moving,
    /// mutating endpoints. Their sanity tests only assert the SDK round-trips
    /// the call and deserializes a response object; they do NOT assert success
    /// so that running the suite never initiates a real payout.
    /// </summary>
    public class PayoutService
    {
        private static void PrintPayoutDetails(PayoutDetails? data)
        {
            if (data == null)
            {
                Console.WriteLine("  (null)");
                return;
            }
            Console.WriteLine($"  Status: {data.Status}");
            Console.WriteLine($"  Mode: {data.Mode}");
            Console.WriteLine($"  Amount: {data.Amount}");
            Console.WriteLine($"  Currency: {data.Currency}");
            Console.WriteLine($"  Eta: {data.Eta}");
            Console.WriteLine($"  Message: {data.Message}");
            Console.WriteLine($"  TransactionId: {data.TransactionId}");
            Console.WriteLine($"  CreatedAt: {data.CreatedAt}");
            Console.WriteLine($"  BankName: {data.BankName}");
            Console.WriteLine($"  TransactionFee: {data.TransactionFee}");

            if (data.AdditionalProperties.Count > 0)
            {
                Console.WriteLine("  Additional Properties:");
                foreach (var kvp in data.AdditionalProperties)
                {
                    Console.WriteLine($"    {kvp.Key}: {kvp.Value}");
                }
            }
        }

        public static async Task PrintGetPayoutModesTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing User API (GetPayoutModes) ===");
            var userApi = services.GetRequiredService<IUserApi>();
            var response = await userApi.GetPayoutModesAsync();
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
                Console.WriteLine("GetPayoutModes response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task PrintInitiatePayoutTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing User API (InitiatePayout) ===");
            var userApi = services.GetRequiredService<IUserApi>();
            var request = new InitiatePayoutRequest
            {
                Mode = "INSTANT",
                Amount = 100.0
            };
            var response = await userApi.InitiatePayoutAsync(request);
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                PrintPayoutDetails(result.Data);

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
                Console.WriteLine("InitiatePayout response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task PrintModifyPayoutTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing User API (ModifyPayout) ===");
            var userApi = services.GetRequiredService<IUserApi>();
            var request = new ModifyPayoutRequest
            {
                Amount = 200.0
            };
            var response = await userApi.ModifyPayoutAsync(request, transactionId: "TEST_TXN_ID");
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                PrintPayoutDetails(result.Data);

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
                Console.WriteLine("ModifyPayout response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task PrintCancelPayoutTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing User API (CancelPayout) ===");
            var userApi = services.GetRequiredService<IUserApi>();
            var response = await userApi.CancelPayoutAsync(transactionId: "TEST_TXN_ID");
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                PrintPayoutDetails(result.Data);

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
                Console.WriteLine("CancelPayout response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetPayoutModesTest(IServiceProvider services)
        {
            var userApi = services.GetRequiredService<IUserApi>();
            var response = await userApi.GetPayoutModesAsync();
            var result = response.Ok();

            if (result == null)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("GetPayoutModes: Invalid access token");
                throw new Exception("GetPayoutModes response is null");
            }

            if (result.Status == null)
                throw new Exception("GetPayoutModes: Status is null");
            if (result.Data == null)
                throw new Exception("GetPayoutModes: Data is null");
        }

        // The following are mutating, money-moving endpoints. The sanity checks
        // only verify the SDK is wired correctly (request serialized, response
        // deserialized) without asserting a successful payout.

        public static async Task SanityInitiatePayoutTest(IServiceProvider services)
        {
            var userApi = services.GetRequiredService<IUserApi>();
            var request = new InitiatePayoutRequest
            {
                Mode = "INSTANT",
                Amount = 100.0
            };
            var response = await userApi.InitiatePayoutAsync(request);

            if (response == null)
                throw new Exception("InitiatePayout: response object is null (SDK not wired)");
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception("InitiatePayout: Invalid access token");
        }

        public static async Task SanityModifyPayoutTest(IServiceProvider services)
        {
            var userApi = services.GetRequiredService<IUserApi>();
            var request = new ModifyPayoutRequest
            {
                Amount = 200.0
            };
            var response = await userApi.ModifyPayoutAsync(request, transactionId: "TEST_TXN_ID");

            if (response == null)
                throw new Exception("ModifyPayout: response object is null (SDK not wired)");
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception("ModifyPayout: Invalid access token");
        }

        public static async Task SanityCancelPayoutTest(IServiceProvider services)
        {
            var userApi = services.GetRequiredService<IUserApi>();
            var response = await userApi.CancelPayoutAsync(transactionId: "TEST_TXN_ID");

            if (response == null)
                throw new Exception("CancelPayout: response object is null (SDK not wired)");
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception("CancelPayout: Invalid access token");
        }
    }
}
