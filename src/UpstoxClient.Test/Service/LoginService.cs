using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class LoginService
    {

        /// <summary>
        /// Tests the InitTokenRequestForIndieUser API functionality
        /// </summary>
        public static async Task PrintInitTokenRequestForIndieUserTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Login API (InitTokenRequestForIndieUser) ===");

            var loginApi = services.GetRequiredService<ILoginApi>();
            var indieUserRequest = new IndieUserTokenRequest(
                clientSecret: "test_client_secret"
            );

            var response = await loginApi.InitTokenRequestForIndieUserAsync(
                indieUserRequest,
                clientId: "test_client_id"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  AuthorizationExpiry: {result.Data.AuthorizationExpiry}");
                    Console.WriteLine($"  NotifierUrl: {result.Data.NotifierUrl}");

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
                Console.WriteLine("InitTokenRequestForIndieUser response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityInitTokenRequestForIndieUserTest(IServiceProvider services)
        {
            var loginApi = services.GetRequiredService<ILoginApi>();
            var indieUserRequest = new IndieUserTokenRequest(
                clientSecret: "test_client_secret"
            );

            var response = await loginApi.InitTokenRequestForIndieUserAsync(
                indieUserRequest,
                clientId: "test_client_id"
            );
            var result = response.Ok();
            if (result != null)
            {
                // Check for success status
                if (result.Status != IndieUserInitTokenResponse.StatusEnum.Success)
                {
                    Console.WriteLine("InitTokenRequestForIndieUser test failed - status not success");
                    return;
                }

                // Validate data exists if applicable
                if (result.Data == null)
                {
                    Console.WriteLine("InitTokenRequestForIndieUser data is null");
                    return;
                }

                Console.WriteLine("SanityInitTokenRequestForIndieUserTest passed - got valid response");
                return;
            }

            // Check for expected error responses (invalid credentials)
            var badRequestError = response.BadRequest();
            if (badRequestError != null)
            {
                // This is expected for invalid test credentials
                var firstError = badRequestError.Errors?.FirstOrDefault();
                if (firstError != null && firstError.ErrorCode == "UDAPI100069")
                {
                    Console.WriteLine("SanityInitTokenRequestForIndieUserTest passed - got expected invalid credentials error (UDAPI100069)");
                    return;
                }

                Console.WriteLine($"InitTokenRequestForIndieUser test failed - unexpected bad request error: {firstError?.Message ?? "Unknown error"}");
                return;
            }

            var unauthorizedError = response.Unauthorized();
            if (unauthorizedError != null)
            {
                // This is also expected for invalid test credentials
                var firstError = unauthorizedError.Errors?.FirstOrDefault();
                if (firstError != null)
                {
                    return;
                }

                Console.WriteLine("SanityInitTokenRequestForIndieUserTest passed - got expected unauthorized error");
                return;
            }

            // If we get here, it's an unexpected error
            Console.WriteLine("InitTokenRequestForIndieUser test failed - unexpected response type");
        }

        /// <summary>
        /// Tests the Logout API functionality
        /// </summary>
        public static async Task PrintLogoutTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Login API (Logout) ===");

            var loginApi = services.GetRequiredService<ILoginApi>();
            var response = await loginApi.LogoutAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data: {result.Data}");
            }
            else
            {
                Console.WriteLine("Logout response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityLogoutTest(IServiceProvider services)
        {
            var loginApi = services.GetRequiredService<ILoginApi>();
            var response = await loginApi.LogoutAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("Logout response is null");
                return;
            }

            // Check for success status
            if (result.Status != LogoutResponse.StatusEnum.Success)
            {
                // TODO: Add valid error codes handling here
                Console.WriteLine("Logout test failed");
                return;
            }
        }

        /// <summary>
        /// Tests the Token API functionality
        /// </summary>
        public static async Task PrintTokenTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Login API (Token) ===");

            var loginApi = services.GetRequiredService<ILoginApi>();
            var response = await loginApi.TokenAsync(
                code: "IifRcm",
                clientSecret: "x3fvck9bcx",
                grantType: "authorization_code",
                clientId: "f0d68b8d-c3e9-47f2-82dd-ae867e2bf617",
                redirectUri: "https://google.com"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Email: {result.Email}");
                Console.WriteLine($"Exchanges: {string.Join(", ", result.Exchanges?.Select(e => TokenResponse.ExchangesEnumToJsonValue(e)).Where(s => s != null) ?? new List<string>())}");
                Console.WriteLine($"Products: {string.Join(", ", result.Products?.Select(p => TokenResponse.ProductsEnumToJsonValue(p)).Where(s => s != null) ?? new List<string>())}");
                Console.WriteLine($"Broker: {result.Broker}");
                Console.WriteLine($"UserId: {result.UserId}");
                Console.WriteLine($"UserName: {result.UserName}");
                Console.WriteLine($"OrderTypes: {string.Join(", ", result.OrderTypes?.Select(o => TokenResponse.OrderTypesEnumToJsonValue(o)).Where(s => s != null) ?? new List<string>())}");
                Console.WriteLine($"UserType: {result.UserType}");
                Console.WriteLine($"Poa: {result.Poa}");
                Console.WriteLine($"Ddpi: {result.Ddpi}");
                Console.WriteLine($"IsActive: {result.IsActive}");
                Console.WriteLine($"AccessToken: {result.AccessToken}");

                // Print additional properties if any
                if (result.AdditionalProperties.Count > 0)
                {
                    Console.WriteLine("Additional Properties:");
                    foreach (var kvp in result.AdditionalProperties)
                    {
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Token response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityTokenTest(IServiceProvider services)
        {
            var loginApi = services.GetRequiredService<ILoginApi>();
            var response = await loginApi.TokenAsync(
                code: "test_auth_code",
                clientId: "test_client_id",
                clientSecret: "test_client_secret",
                redirectUri: "https://example.com/callback",
                grantType: "authorization_code"
            );

            // Check for successful response first
            var result = response.Ok();
            if (result != null)
            {
                // Token response doesn't have status, just validate key fields exist
                if (string.IsNullOrEmpty(result.UserId))
                {
                    Console.WriteLine("Token test failed - UserId is null or empty");
                    return;
                }

                if (string.IsNullOrEmpty(result.AccessToken))
                {
                    Console.WriteLine("Token test failed - AccessToken is null or empty");
                    return;
                }

                Console.WriteLine("SanityTokenTest passed - got valid token response");
                return;
            }

            // Check for expected error responses (invalid credentials)
            var badRequestError = response.BadRequest();
            if (badRequestError != null)
            {
                // This is expected for invalid test credentials
                var firstError = badRequestError.Errors?.FirstOrDefault();
                if (firstError != null && firstError.ErrorCode == "UDAPI100069")
                {
                    Console.WriteLine("SanityTokenTest passed - got expected invalid credentials error (UDAPI100069)");
                    return;
                }

                Console.WriteLine($"Token test failed - unexpected bad request error: {firstError?.Message ?? "Unknown error"}");
                return;
            }

            var unauthorizedError = response.Unauthorized();
            if (unauthorizedError != null)
            {
                // This is also expected for invalid test credentials
                var firstError = unauthorizedError.Errors?.FirstOrDefault();
                if (firstError != null)
                {
                    return;
                }

                Console.WriteLine("SanityTokenTest passed - got expected unauthorized error");
                return;
            }

            // If we get here, it's an unexpected error
            Console.WriteLine("Token test failed - unexpected response type");
        }
    }
}
