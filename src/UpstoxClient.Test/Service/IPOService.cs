using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class IPOService
    {
        /// <summary>
        /// Tests the GetIpoListing API functionality
        /// </summary>
        public static async Task PrintGetIpoListingTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing IPO API (GetIpoListing) ===");

            var ipoApi = services.GetRequiredService<IIPOApi>();
            var response = await ipoApi.GetIpoListingAsync();
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} IPO listings");
                    foreach (var item in result.Data.Take(3))
                    {
                        Console.WriteLine($"    Id: {item.Id}");
                        Console.WriteLine($"    Symbol: {item.Symbol}");
                        Console.WriteLine($"    Name: {item.Name}");
                        Console.WriteLine($"    Status: {item.Status}");
                        Console.WriteLine($"    Isin: {item.Isin}");
                        Console.WriteLine($"    IssueType: {item.IssueType}");
                        Console.WriteLine($"    IssueSize: {item.IssueSize}");
                        Console.WriteLine($"    Industry: {item.Industry}");
                        Console.WriteLine($"    MinimumPrice: {item.MinimumPrice}");
                        Console.WriteLine($"    MaximumPrice: {item.MaximumPrice}");
                        Console.WriteLine($"    BiddingStartDate: {item.BiddingStartDate}");
                        Console.WriteLine($"    BiddingEndDate: {item.BiddingEndDate}");
                        Console.WriteLine($"    TotalSubscription: {item.TotalSubscription}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no IPO listings found)");
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
                Console.WriteLine("GetIpoListing response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetIpoListingTest(IServiceProvider services)
        {
            var ipoApi = services.GetRequiredService<IIPOApi>();
            var response = await ipoApi.GetIpoListingAsync();
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetIpoListing response is null");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetIpoListing data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetIpoDetails API functionality
        /// </summary>
        public static async Task PrintGetIpoDetailsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing IPO API (GetIpoDetails) ===");

            var ipoApi = services.GetRequiredService<IIPOApi>();

            // First fetch listing to get a valid id
            var listingResponse = await ipoApi.GetIpoListingAsync();
            var listing = listingResponse.Ok();

            if (listing?.Data == null || listing.Data.Count == 0)
            {
                Console.WriteLine("No IPO listings found, skipping GetIpoDetails test");
                Console.WriteLine("==================");
                return;
            }

            var firstId = listing.Data[0].Id;
            Console.WriteLine($"Fetching details for IPO id: {firstId}");

            var response = await ipoApi.GetIpoDetailsAsync(id: firstId);
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Id: {result.Data.Id}");
                    Console.WriteLine($"  Symbol: {result.Data.Symbol}");
                    Console.WriteLine($"  Name: {result.Data.Name}");
                    Console.WriteLine($"  Status: {result.Data.Status}");
                    Console.WriteLine($"  Isin: {result.Data.Isin}");
                    Console.WriteLine($"  IssueType: {result.Data.IssueType}");
                    Console.WriteLine($"  IssueSize: {result.Data.IssueSize}");
                    Console.WriteLine($"  Industry: {result.Data.Industry}");
                    Console.WriteLine($"  MinimumPrice: {result.Data.MinimumPrice}");
                    Console.WriteLine($"  MaximumPrice: {result.Data.MaximumPrice}");
                    Console.WriteLine($"  BiddingStartDate: {result.Data.BiddingStartDate}");
                    Console.WriteLine($"  BiddingEndDate: {result.Data.BiddingEndDate}");
                    Console.WriteLine($"  DailyStartTime: {result.Data.DailyStartTime}");
                    Console.WriteLine($"  DailyEndTime: {result.Data.DailyEndTime}");
                    Console.WriteLine($"  FaceValue: {result.Data.FaceValue}");
                    Console.WriteLine($"  TickSize: {result.Data.TickSize}");
                    Console.WriteLine($"  LotSize: {result.Data.LotSize}");
                    Console.WriteLine($"  MinimumQuantity: {result.Data.MinimumQuantity}");
                    Console.WriteLine($"  CutOffPrice: {result.Data.CutOffPrice}");
                    Console.WriteLine($"  ListingPrice: {result.Data.ListingPrice}");
                    Console.WriteLine($"  ListingExchange: {result.Data.ListingExchange}");
                    Console.WriteLine($"  RhpUrl: {result.Data.RhpUrl}");
                    Console.WriteLine($"  DrhpUrl: {result.Data.DrhpUrl}");
                    Console.WriteLine($"  TotalSubscription: {result.Data.TotalSubscription}");
                    if (result.Data.Timeline != null)
                    {
                        Console.WriteLine($"  Timeline:");
                        Console.WriteLine($"    PreApplyStartDate: {result.Data.Timeline.PreApplyStartDate}");
                        Console.WriteLine($"    ApplicationStartDate: {result.Data.Timeline.ApplicationStartDate}");
                        Console.WriteLine($"    ApplicationEndDate: {result.Data.Timeline.ApplicationEndDate}");
                        Console.WriteLine($"    AllotmentStartDate: {result.Data.Timeline.AllotmentStartDate}");
                        Console.WriteLine($"    AllotmentDate: {result.Data.Timeline.AllotmentDate}");
                        Console.WriteLine($"    RefundInitiationDate: {result.Data.Timeline.RefundInitiationDate}");
                        Console.WriteLine($"    ListingDate: {result.Data.Timeline.ListingDate}");
                        Console.WriteLine($"    MandateEndDate: {result.Data.Timeline.MandateEndDate}");
                    }
                    if (result.Data.RegistrarInfo != null)
                    {
                        Console.WriteLine($"  RegistrarInfo:");
                        Console.WriteLine($"    Name: {result.Data.RegistrarInfo.Name}");
                        Console.WriteLine($"    Email: {result.Data.RegistrarInfo.Email}");
                        Console.WriteLine($"    ContactName: {result.Data.RegistrarInfo.ContactName}");
                        Console.WriteLine($"    ContactNumber: {result.Data.RegistrarInfo.ContactNumber}");
                        Console.WriteLine($"    Website: {result.Data.RegistrarInfo.Website}");
                        Console.WriteLine($"    Registrar: {result.Data.RegistrarInfo.Registrar}");
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
                Console.WriteLine("GetIpoDetails response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetIpoDetailsTest(IServiceProvider services)
        {
            var ipoApi = services.GetRequiredService<IIPOApi>();

            // First fetch listing to get a valid id
            var listingResponse = await ipoApi.GetIpoListingAsync();
            var listing = listingResponse.Ok();

            if (listing?.Data == null || listing.Data.Count == 0)
            {
                Console.WriteLine("No IPO listings found, skipping GetIpoDetails sanity test");
                return;
            }

            var firstId = listing.Data[0].Id;
            var response = await ipoApi.GetIpoDetailsAsync(id: firstId);
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetIpoDetails response is null");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("GetIpoDetails data is null");
                return;
            }
        }
    }
}
