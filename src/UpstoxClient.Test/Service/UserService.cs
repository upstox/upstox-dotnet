using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class UserService
    {
        /// <summary>
        /// Tests the user API functionality by fetching the user profile
        /// </summary>
        public static async Task TestUserProfileAsync(IServiceProvider services)
        {
            await PrintProfileTest(services);
            await SanityProfileTest(services);
            Console.WriteLine("Profile test passed");
        }
        public static async Task PrintProfileTest(IServiceProvider services){

        Console.WriteLine("=== Testing User API (Profile) ===");

            var userApi = services.GetRequiredService<IUserApi>();
            var profileResponse = await userApi.GetProfileAsync();
            var profile = profileResponse.Ok();

            if (profile != null)
            {
                Console.WriteLine($"Status: {profile.Status?.ToString() ?? "null"}");
            Console.WriteLine($"Data:");
            if (profile.Data != null)
            {
                Console.WriteLine($"  Email: {profile.Data.Email}");
                Console.WriteLine($"  Exchanges: {string.Join(", ", profile.Data.Exchanges ?? [])}");
                Console.WriteLine($"  Products: {string.Join(", ", profile.Data.Products ?? [])}");
                Console.WriteLine($"  Broker: {profile.Data.Broker}");
                Console.WriteLine($"  UserId: {profile.Data.UserId}");
                Console.WriteLine($"  UserName: {profile.Data.UserName}");
                Console.WriteLine($"  OrderTypes: {string.Join(", ", profile.Data.OrderTypes ?? [])}");
                Console.WriteLine($"  UserType: {profile.Data.UserType}");
                Console.WriteLine($"  Poa: {profile.Data.Poa}");
                Console.WriteLine($"  Ddpi: {profile.Data.Ddpi}");
                Console.WriteLine($"  IsActive: {profile.Data.IsActive}");

                // Print additional properties if any
                if (profile.Data.AdditionalProperties.Count > 0)
                {
                    Console.WriteLine("  Additional Properties:");
                    foreach (var kvp in profile.Data.AdditionalProperties)
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
            if (profile.AdditionalProperties.Count > 0)
            {
                Console.WriteLine("Response Additional Properties:");
                foreach (var kvp in profile.AdditionalProperties)
                {
                    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                }
            }
            }
            else
            {
                Console.WriteLine("Profile response is null");
            }
            Console.WriteLine("==================");
        }
        public static async Task SanityProfileTest(IServiceProvider services){
            var userApi = services.GetRequiredService<IUserApi>();
            var profileResponse = await userApi.GetProfileAsync();
            var profile = profileResponse.Ok();
            if(profile == null){
                Console.WriteLine("Profile response is null");
                return;
            }
            if(profile.Status != GetProfileResponse.StatusEnum.Success){
                Console.WriteLine("Profile test failed");
                return;
            }
            if(profile.Data == null){
                Console.WriteLine("Profile data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetUserFundMargin API functionality
        /// </summary>
        public static async Task PrintGetUserFundMarginTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing User API (GetUserFundMargin) ===");

            var userApi = services.GetRequiredService<IUserApi>();
            var response = await userApi.GetUserFundMarginAsync(
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    foreach (var kvp in result.Data)
                    {
                        Console.WriteLine($"  Segment: {kvp.Key}");
                        var fundData = kvp.Value;
                        Console.WriteLine($"    Used Margin: {fundData.UsedMargin}");
                        Console.WriteLine($"    Payin Amount: {fundData.PayinAmount}");
                        Console.WriteLine($"    Span Margin: {fundData.SpanMargin}");
                        Console.WriteLine($"    Adhoc Margin: {fundData.AdhocMargin}");
                        Console.WriteLine($"    Notional Cash: {fundData.NotionalCash}");
                        Console.WriteLine($"    Available Margin: {fundData.AvailableMargin}");
                        Console.WriteLine($"    Exposure Margin: {fundData.ExposureMargin}");

                        // Print additional properties if any
                        if (fundData.AdditionalProperties.Count > 0)
                        {
                            Console.WriteLine("    Additional Properties:");
                            foreach (var prop in fundData.AdditionalProperties)
                            {
                                Console.WriteLine($"      {prop.Key}: {prop.Value}");
                            }
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
                Console.WriteLine("GetUserFundMargin response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetUserFundMarginTest(IServiceProvider services)
        {
            var userApi = services.GetRequiredService<IUserApi>();
            var response = await userApi.GetUserFundMarginAsync(
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetUserFundMargin response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetUserFundMarginResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetUserFundMargin test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetUserFundMargin data is null");
                return;
            }
        }
    }

}
