using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class UserApiExtensionsService
    {
        /// <summary>
        /// Tests the GetKillSwitch API functionality
        /// </summary>
        public static async Task PrintGetKillSwitchTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing User API (GetKillSwitch) ===");

            var userApi = (UserApi)services.GetRequiredService<IUserApi>();
            var response = await userApi.GetKillSwitchAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} segment(s)");
                    foreach (var segment in result.Data)
                    {
                        Console.WriteLine($"    Segment: {segment.Segment}");
                        Console.WriteLine($"    SegmentStatus: {segment.SegmentStatus?.ToString() ?? "null"}");
                        Console.WriteLine($"    KillSwitchEnabled: {segment.KillSwitchEnabled}");
                        Console.WriteLine("    ---");
                    }
                }
                else
                {
                    Console.WriteLine("  (no segment data found)");
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
                Console.WriteLine("GetKillSwitch response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetKillSwitchTest(IServiceProvider services)
        {
            var userApi = (UserApi)services.GetRequiredService<IUserApi>();
            var response = await userApi.GetKillSwitchAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetKillSwitch response is null");
                return;
            }

            // Check for success status
            if (result.Status != KillSwitchResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetKillSwitch test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetKillSwitch data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetUserIps API functionality
        /// </summary>
        public static async Task PrintGetUserIpsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing User API (GetUserIps) ===");

            var userApi = (UserApi)services.GetRequiredService<IUserApi>();
            var response = await userApi.GetUserIpsAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  PrimaryIp: {result.Data.PrimaryIp ?? "(null)"}");
                    Console.WriteLine($"  SecondaryIp: {result.Data.SecondaryIp ?? "(null)"}");
                    Console.WriteLine($"  PrimaryIpUpdatedAt: {result.Data.PrimaryIpUpdatedAt ?? "(null)"}");
                    Console.WriteLine($"  SecondaryIpUpdatedAt: {result.Data.SecondaryIpUpdatedAt ?? "(null)"}");
                    Console.WriteLine($"  AccessTokensInvalidated: {result.Data.AccessTokensInvalidated}");

                    if (result.Data.PrimaryIpFamilyMembers != null && result.Data.PrimaryIpFamilyMembers.Count > 0)
                    {
                        Console.WriteLine($"  PrimaryIpFamilyMembers: {result.Data.PrimaryIpFamilyMembers.Count} member(s)");
                    }

                    if (result.Data.SecondaryIpFamilyMembers != null && result.Data.SecondaryIpFamilyMembers.Count > 0)
                    {
                        Console.WriteLine($"  SecondaryIpFamilyMembers: {result.Data.SecondaryIpFamilyMembers.Count} member(s)");
                    }

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
                Console.WriteLine("GetUserIps response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetUserIpsTest(IServiceProvider services)
        {
            var userApi = (UserApi)services.GetRequiredService<IUserApi>();
            var response = await userApi.GetUserIpsAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetUserIps response is null");
                return;
            }

            // Check for success status
            if (result.Status != UserIpResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetUserIps test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetUserIps data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetUserFundMarginV3 API functionality
        /// </summary>
        public static async Task PrintGetUserFundMarginV3Test(IServiceProvider services)
        {
            Console.WriteLine("=== Testing User API (GetUserFundMarginV3) ===");

            var userApi = (UserApi)services.GetRequiredService<IUserApi>();
            var response = await userApi.GetUserFundMarginV3Async();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    if (result.Data.AvailableToTrade != null)
                    {
                        Console.WriteLine($"  AvailableToTrade:");
                        Console.WriteLine($"    Total: {result.Data.AvailableToTrade.Total}");
                        if (result.Data.AvailableToTrade.AdditionalProperties.Count > 0)
                        {
                            Console.WriteLine("    Additional Properties:");
                            foreach (var kvp in result.Data.AvailableToTrade.AdditionalProperties)
                            {
                                Console.WriteLine($"      {kvp.Key}: {kvp.Value}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("  AvailableToTrade: (null)");
                    }

                    if (result.Data.UnavailableToTrade != null)
                    {
                        Console.WriteLine($"  UnavailableToTrade:");
                        if (result.Data.UnavailableToTrade.AdditionalProperties.Count > 0)
                        {
                            Console.WriteLine("    Additional Properties:");
                            foreach (var kvp in result.Data.UnavailableToTrade.AdditionalProperties)
                            {
                                Console.WriteLine($"      {kvp.Key}: {kvp.Value}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("  UnavailableToTrade: (null)");
                    }

                    // Print data additional properties if any
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
                Console.WriteLine("GetUserFundMarginV3 response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetUserFundMarginV3Test(IServiceProvider services)
        {
            var userApi = (UserApi)services.GetRequiredService<IUserApi>();
            var response = await userApi.GetUserFundMarginV3Async();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetUserFundMarginV3 response is null");
                return;
            }

            // Check for success status
            if (result.Status != GetUserFundMarginV3Response.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetUserFundMarginV3 test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetUserFundMarginV3 data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetPayinHistory API functionality
        /// </summary>
        public static async Task PrintGetPayinHistoryTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing User API (GetPayinHistory) ===");

            var userApi = (UserApi)services.GetRequiredService<IUserApi>();
            var response = await userApi.GetPayinHistoryAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} payment record(s)");
                    foreach (var record in result.Data.Take(3)) // Show first 3 for brevity
                    {
                        Console.WriteLine($"    Amount: {record.Amount}");
                        Console.WriteLine($"    Mode: {record.Mode}");
                        Console.WriteLine($"    Status: {record.Status}");
                        Console.WriteLine($"    Reason: {record.Reason}");
                        Console.WriteLine($"    LastUpdatedAt: {record.LastUpdatedAt}");
                        Console.WriteLine($"    BankName: {record.BankName}");
                        Console.WriteLine($"    TransactionId: {record.TransactionId}");
                        Console.WriteLine($"    TotalCharges: {record.TotalCharges}");
                        Console.WriteLine($"    ChargesCategory: {record.ChargesCategory}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no payment history found)");
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
                Console.WriteLine("GetPayinHistory response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetPayinHistoryTest(IServiceProvider services)
        {
            var userApi = (UserApi)services.GetRequiredService<IUserApi>();
            var response = await userApi.GetPayinHistoryAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetPayinHistory response is null");
                return;
            }

            // Check for success status
            if (result.Status != PaymentHistoryResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetPayinHistory test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetPayinHistory data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetPayoutHistory API functionality
        /// </summary>
        public static async Task PrintGetPayoutHistoryTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing User API (GetPayoutHistory) ===");

            var userApi = (UserApi)services.GetRequiredService<IUserApi>();
            var response = await userApi.GetPayoutHistoryAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} payment record(s)");
                    foreach (var record in result.Data.Take(3)) // Show first 3 for brevity
                    {
                        Console.WriteLine($"    Amount: {record.Amount}");
                        Console.WriteLine($"    Mode: {record.Mode}");
                        Console.WriteLine($"    Status: {record.Status}");
                        Console.WriteLine($"    Reason: {record.Reason}");
                        Console.WriteLine($"    LastUpdatedAt: {record.LastUpdatedAt}");
                        Console.WriteLine($"    BankName: {record.BankName}");
                        Console.WriteLine($"    TransactionId: {record.TransactionId}");
                        Console.WriteLine($"    TotalCharges: {record.TotalCharges}");
                        Console.WriteLine($"    ChargesCategory: {record.ChargesCategory}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no payment history found)");
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
                Console.WriteLine("GetPayoutHistory response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetPayoutHistoryTest(IServiceProvider services)
        {
            var userApi = (UserApi)services.GetRequiredService<IUserApi>();
            var response = await userApi.GetPayoutHistoryAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetPayoutHistory response is null");
                return;
            }

            // Check for success status
            if (result.Status != PaymentHistoryResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("GetPayoutHistory test failed");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetPayoutHistory data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the UpdateKillSwitch API functionality
        /// </summary>
        public static async Task PrintUpdateKillSwitchTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing User API (UpdateKillSwitch) ===");

            var userApi = (UserApi)services.GetRequiredService<IUserApi>();
            var response = await userApi.UpdateKillSwitchAsync(
                killSwitchSegmentUpdateRequest: new List<KillSwitchSegmentUpdateRequest>()
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} segment(s)");
                    foreach (var segment in result.Data)
                    {
                        Console.WriteLine($"    Segment: {segment.Segment}");
                        Console.WriteLine($"    SegmentStatus: {segment.SegmentStatus?.ToString() ?? "null"}");
                        Console.WriteLine($"    KillSwitchEnabled: {segment.KillSwitchEnabled}");
                        Console.WriteLine("    ---");
                    }
                }
                else
                {
                    Console.WriteLine("  (no segment data found)");
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
                Console.WriteLine("UpdateKillSwitch response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityUpdateKillSwitchTest(IServiceProvider services)
        {
            var userApi = (UserApi)services.GetRequiredService<IUserApi>();
            var response = await userApi.UpdateKillSwitchAsync(
                killSwitchSegmentUpdateRequest: new List<KillSwitchSegmentUpdateRequest>()
            );
            var result = response.Ok();

            // UpdateKillSwitch modifies state; just verify response is non-null
            if (result == null)
            {
                Console.WriteLine("UpdateKillSwitch response is null");
                return;
            }
        }

        /// <summary>
        /// Tests the UpdateUserIp API functionality
        /// </summary>
        public static async Task PrintUpdateUserIpTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing User API (UpdateUserIp) ===");

            var userApi = (UserApi)services.GetRequiredService<IUserApi>();
            try
            {
                var response = await userApi.UpdateUserIpAsync(
                    updateUserIpRequest: new UpdateUserIpRequest(
                        primaryIp: new UpstoxClient.Client.Option<string?>("0.0.0.0"),
                        secondaryIp: new UpstoxClient.Client.Option<string?>("0.0.0.0")
                    )
                );
                var result = response.Ok();

                if (result != null)
                {
                    Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                    Console.WriteLine($"Data:");
                    if (result.Data != null)
                    {
                        Console.WriteLine($"  PrimaryIp: {result.Data.PrimaryIp ?? "(null)"}");
                        Console.WriteLine($"  SecondaryIp: {result.Data.SecondaryIp ?? "(null)"}");
                        Console.WriteLine($"  PrimaryIpUpdatedAt: {result.Data.PrimaryIpUpdatedAt ?? "(null)"}");
                        Console.WriteLine($"  SecondaryIpUpdatedAt: {result.Data.SecondaryIpUpdatedAt ?? "(null)"}");
                        Console.WriteLine($"  AccessTokensInvalidated: {result.Data.AccessTokensInvalidated}");
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
                    Console.WriteLine("UpdateUserIp response is null");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateUserIp error (expected if validation fails): {ex.Message}");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityUpdateUserIpTest(IServiceProvider services)
        {
            var userApi = (UserApi)services.GetRequiredService<IUserApi>();
            try
            {
                var response = await userApi.UpdateUserIpAsync(
                    updateUserIpRequest: new UpdateUserIpRequest(
                        primaryIp: new UpstoxClient.Client.Option<string?>("0.0.0.0"),
                        secondaryIp: new UpstoxClient.Client.Option<string?>("0.0.0.0")
                    )
                );
                var result = response.Ok();

                // UpdateUserIp modifies state; just verify response is non-null
                if (result == null)
                {
                    Console.WriteLine("UpdateUserIp response is null");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateUserIp error (expected if validation fails): {ex.Message}");
            }
        }
    }
}
