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
                    if (result.Data.Investors != null)
                    {
                        Console.WriteLine($"  Investors ({result.Data.Investors.Count}):");
                        foreach (var investor in result.Data.Investors)
                        {
                            Console.WriteLine($"    Category: {investor?.Category}");
                            Console.WriteLine($"    Description: {investor?.Description}");
                            if (investor?.AdditionalProperties != null && investor.AdditionalProperties.Count > 0)
                            {
                                foreach (var kvp in investor.AdditionalProperties)
                                    Console.WriteLine($"    [additional] {kvp.Key}: {kvp.Value}");
                            }
                            Console.WriteLine("    ---");
                        }
                    }
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

        // ------------------------------------------------------------------
        // IPO orders (ApplyForIpo / GetIpoOrders / GetIpoOrderById / CancelIpoOrder)
        // ------------------------------------------------------------------

        /// <summary>
        /// ApplyForIpo and CancelIpoOrder mutate state on the authenticated live account:
        /// they place, and withdraw, a real IPO application backed by a real UPI mandate.
        /// The existing test harness has no guarding pattern for write paths, so these two
        /// endpoints are wired up but disabled by default. Flip this flag to true (and set
        /// ApplyUpiId / ApplyIpoId below to values valid for the account under test) to
        /// exercise them for real.
        /// </summary>
        private static readonly bool EnableStateChangingIpoTests = false;

        /// <summary>
        /// UPI handle used by the ApplyForIpo tests. Must belong to the authenticated user.
        /// </summary>
        private const string ApplyUpiId = "someone@upi";

        /// <summary>
        /// Prints every field of an <see cref="IpoOrderData"/>, including nested bids
        /// and any additional properties.
        /// </summary>
        private static void PrintIpoOrderData(IpoOrderData? data, string indent)
        {
            if (data == null)
            {
                Console.WriteLine($"{indent}(null)");
                return;
            }

            Console.WriteLine($"{indent}Id: {data.Id}");
            Console.WriteLine($"{indent}Symbol: {data.Symbol}");
            Console.WriteLine($"{indent}Exchange: {data.Exchange}");
            Console.WriteLine($"{indent}RequestId: {data.RequestId}");
            Console.WriteLine($"{indent}OrderId: {data.OrderId}");
            Console.WriteLine($"{indent}Status: {data.Status}");
            Console.WriteLine($"{indent}OrderStatus: {data.OrderStatus}");
            Console.WriteLine($"{indent}PaymentStatus: {data.PaymentStatus}");
            Console.WriteLine($"{indent}Category: {data.Category}");
            Console.WriteLine($"{indent}IssueType: {data.IssueType}");
            Console.WriteLine($"{indent}Reason: {data.Reason}");
            Console.WriteLine($"{indent}Upi: {data.Upi}");
            Console.WriteLine($"{indent}UpiAmountBlocked: {data.UpiAmountBlocked}");
            Console.WriteLine($"{indent}NseSubmittedDate: {data.NseSubmittedDate}");
            Console.WriteLine($"{indent}BseSubmittedDate: {data.BseSubmittedDate}");
            Console.WriteLine($"{indent}MandateApprovedDate: {data.MandateApprovedDate}");
            Console.WriteLine($"{indent}RejectionDate: {data.RejectionDate}");
            Console.WriteLine($"{indent}MandateRejectionDate: {data.MandateRejectionDate}");
            Console.WriteLine($"{indent}CancelRequestedDate: {data.CancelRequestedDate}");
            Console.WriteLine($"{indent}CancelAcceptedDate: {data.CancelAcceptedDate}");
            Console.WriteLine($"{indent}UnitsAllotted: {data.UnitsAllotted}");
            Console.WriteLine($"{indent}CreatedAt: {data.CreatedAt}");
            Console.WriteLine($"{indent}LastUpdatedAt: {data.LastUpdatedAt}");

            if (data.Bids != null)
            {
                Console.WriteLine($"{indent}Bids ({data.Bids.Count}):");
                foreach (var bid in data.Bids)
                {
                    Console.WriteLine($"{indent}  Quantity: {bid?.Quantity}");
                    Console.WriteLine($"{indent}  Price: {bid?.Price}");
                    Console.WriteLine($"{indent}  Amount: {bid?.Amount}");
                    Console.WriteLine($"{indent}  Message: {bid?.Message}");
                    if (bid?.AdditionalProperties != null && bid.AdditionalProperties.Count > 0)
                    {
                        foreach (var kvp in bid.AdditionalProperties)
                            Console.WriteLine($"{indent}  [additional] {kvp.Key}: {kvp.Value}");
                    }
                    Console.WriteLine($"{indent}  ---");
                }
            }
            else
            {
                Console.WriteLine($"{indent}Bids: (null)");
            }

            if (data.AdditionalProperties.Count > 0)
            {
                Console.WriteLine($"{indent}AdditionalProperties:");
                foreach (var kvp in data.AdditionalProperties)
                    Console.WriteLine($"{indent}  {kvp.Key}: {kvp.Value}");
            }
        }

        /// <summary>
        /// Prints every field of an <see cref="IpoMetaData"/> and its nested pagination.
        /// </summary>
        private static void PrintIpoMetaData(IpoMetaData? metaData, string indent)
        {
            if (metaData == null)
            {
                Console.WriteLine($"{indent}(null)");
                return;
            }

            if (metaData.Page != null)
            {
                Console.WriteLine($"{indent}Page:");
                Console.WriteLine($"{indent}  PageNumber: {metaData.Page.PageNumber}");
                Console.WriteLine($"{indent}  TotalPages: {metaData.Page.TotalPages}");
                Console.WriteLine($"{indent}  Records: {metaData.Page.Records}");
                Console.WriteLine($"{indent}  TotalRecords: {metaData.Page.TotalRecords}");
                if (metaData.Page.AdditionalProperties.Count > 0)
                {
                    foreach (var kvp in metaData.Page.AdditionalProperties)
                        Console.WriteLine($"{indent}  [additional] {kvp.Key}: {kvp.Value}");
                }
            }
            else
            {
                Console.WriteLine($"{indent}Page: (null)");
            }

            if (metaData.AdditionalProperties.Count > 0)
            {
                Console.WriteLine($"{indent}AdditionalProperties:");
                foreach (var kvp in metaData.AdditionalProperties)
                    Console.WriteLine($"{indent}  {kvp.Key}: {kvp.Value}");
            }
        }

        /// <summary>
        /// Resolves an IPO order id from the order book, or null when the account has none.
        /// </summary>
        private static async Task<string?> ResolveIpoOrderIdAsync(IIPOApi ipoApi)
        {
            var ordersResponse = await ipoApi.GetIpoOrdersAsync();
            var orders = ordersResponse.Ok();

            if (orders == null)
            {
                if (ordersResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("Invalid access token");
                throw new Exception("GetIpoOrders response is null while resolving an IPO order id");
            }

            if (orders.Data == null || orders.Data.Count == 0)
                return null;

            return orders.Data[0].OrderId;
        }

        /// <summary>
        /// Tests the ApplyForIpo API functionality
        /// </summary>
        public static async Task PrintApplyForIpoTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing IPO API (ApplyForIpo) ===");

            if (!EnableStateChangingIpoTests)
            {
                Console.WriteLine("SKIPPED: ApplyForIpo places a real IPO application against the live");
                Console.WriteLine("         account. Set EnableStateChangingIpoTests = true in IPOService");
                Console.WriteLine("         to run it.");
                Console.WriteLine("==================");
                return;
            }

            var ipoApi = services.GetRequiredService<IIPOApi>();

            // Resolve an open IPO plus its cut-off price and lot size from the listing/details APIs.
            var listingResponse = await ipoApi.GetIpoListingAsync();
            var listing = listingResponse.Ok();

            if (listing?.Data == null || listing.Data.Count == 0)
            {
                Console.WriteLine("No IPO listings found, skipping ApplyForIpo test");
                Console.WriteLine("==================");
                return;
            }

            var ipoId = listing.Data[0].Id;
            var detailsResponse = await ipoApi.GetIpoDetailsAsync(id: ipoId);
            var details = detailsResponse.Ok();

            var quantity = details?.Data?.MinimumQuantity ?? details?.Data?.LotSize ?? 1;
            var price = (decimal)(details?.Data?.CutOffPrice ?? details?.Data?.MaximumPrice ?? 0d);

            var request = new IpoApplyRequest(
                bids: new List<IpoBidRequest> { new IpoBidRequest(quantity: quantity, price: price) },
                id: ipoId,
                upi: ApplyUpiId,
                category: IpoApplyRequest.CategoryEnum.IND
            );

            Console.WriteLine($"Applying for IPO id: {ipoId} quantity: {quantity} price: {price} upi: {ApplyUpiId}");

            var response = await ipoApi.ApplyForIpoAsync(request);
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  OrderId: {result.Data.OrderId}");
                    if (result.Data.AdditionalProperties.Count > 0)
                    {
                        Console.WriteLine("  AdditionalProperties:");
                        foreach (var kvp in result.Data.AdditionalProperties)
                            Console.WriteLine($"    {kvp.Key}: {kvp.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("  (null)");
                }

                if (result.AdditionalProperties.Count > 0)
                {
                    Console.WriteLine("Response Additional Properties:");
                    foreach (var kvp in result.AdditionalProperties)
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                }
            }
            else
            {
                Console.WriteLine("ApplyForIpo response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityApplyForIpoTest(IServiceProvider services)
        {
            if (!EnableStateChangingIpoTests)
            {
                Console.WriteLine("ApplyForIpo sanity test skipped: state-changing endpoint is disabled " +
                                  "(set EnableStateChangingIpoTests = true in IPOService to run it)");
                return;
            }

            var ipoApi = services.GetRequiredService<IIPOApi>();

            var listingResponse = await ipoApi.GetIpoListingAsync();
            var listing = listingResponse.Ok();

            if (listing == null)
            {
                if (listingResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("Invalid access token");
                throw new Exception("GetIpoListing response is null while resolving an IPO to apply for");
            }

            if (listing.Data == null || listing.Data.Count == 0)
            {
                Console.WriteLine("ApplyForIpo sanity test skipped: no IPOs are currently listed");
                return;
            }

            var ipoId = listing.Data[0].Id;
            var detailsResponse = await ipoApi.GetIpoDetailsAsync(id: ipoId);
            var details = detailsResponse.Ok();

            var quantity = details?.Data?.MinimumQuantity ?? details?.Data?.LotSize ?? 1;
            var price = (decimal)(details?.Data?.CutOffPrice ?? details?.Data?.MaximumPrice ?? 0d);

            var request = new IpoApplyRequest(
                bids: new List<IpoBidRequest> { new IpoBidRequest(quantity: quantity, price: price) },
                id: ipoId,
                upi: ApplyUpiId,
                category: IpoApplyRequest.CategoryEnum.IND
            );

            var response = await ipoApi.ApplyForIpoAsync(request);
            var result = response.Ok();

            if (result == null)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("Invalid access token");
                throw new Exception("ApplyForIpo response is null");
            }

            if (result.Data == null)
                throw new Exception("ApplyForIpo data is null");

            if (string.IsNullOrWhiteSpace(result.Data.OrderId))
                throw new Exception("ApplyForIpo: Data.OrderId is not populated");
        }

        /// <summary>
        /// Tests the GetIpoOrders API functionality
        /// </summary>
        public static async Task PrintGetIpoOrdersTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing IPO API (GetIpoOrders) ===");

            var ipoApi = services.GetRequiredService<IIPOApi>();
            var response = await ipoApi.GetIpoOrdersAsync(pageNumber: "1", records: "10");
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} IPO orders");
                    foreach (var item in result.Data)
                    {
                        PrintIpoOrderData(item, "    ");
                        Console.WriteLine("    ---");
                    }
                }
                else
                {
                    Console.WriteLine("  (no IPO orders found)");
                }

                Console.WriteLine("MetaData:");
                PrintIpoMetaData(result.MetaData, "  ");

                if (result.AdditionalProperties.Count > 0)
                {
                    Console.WriteLine("Response Additional Properties:");
                    foreach (var kvp in result.AdditionalProperties)
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                }
            }
            else
            {
                Console.WriteLine("GetIpoOrders response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetIpoOrdersTest(IServiceProvider services)
        {
            var ipoApi = services.GetRequiredService<IIPOApi>();
            var response = await ipoApi.GetIpoOrdersAsync(pageNumber: "1", records: "10");
            var result = response.Ok();

            if (result == null)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("Invalid access token");
                throw new Exception("GetIpoOrders response is null");
            }

            if (result.Data == null)
                throw new Exception("GetIpoOrders data is null");

            // An account may legitimately have no IPO orders; when it does have some,
            // assert the identifying fields actually came back populated.
            if (result.Data.Count > 0)
            {
                var first = result.Data[0];

                if (string.IsNullOrWhiteSpace(first.Id))
                    throw new Exception("GetIpoOrders: Data[0].Id is not populated");

                if (string.IsNullOrWhiteSpace(first.OrderId))
                    throw new Exception("GetIpoOrders: Data[0].OrderId is not populated");

                if (string.IsNullOrWhiteSpace(first.Symbol))
                    throw new Exception("GetIpoOrders: Data[0].Symbol is not populated");

                if (string.IsNullOrWhiteSpace(first.Status))
                    throw new Exception("GetIpoOrders: Data[0].Status is not populated");
            }
        }

        /// <summary>
        /// Tests the GetIpoOrderById API functionality
        /// </summary>
        public static async Task PrintGetIpoOrderByIdTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing IPO API (GetIpoOrderById) ===");

            var ipoApi = services.GetRequiredService<IIPOApi>();
            var orderId = await ResolveIpoOrderIdAsync(ipoApi);

            if (string.IsNullOrWhiteSpace(orderId))
            {
                Console.WriteLine("No IPO orders found, skipping GetIpoOrderById test");
                Console.WriteLine("==================");
                return;
            }

            Console.WriteLine($"Fetching IPO order: {orderId}");

            var response = await ipoApi.GetIpoOrderByIdAsync(orderId: orderId);
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                PrintIpoOrderData(result.Data, "  ");

                if (result.AdditionalProperties.Count > 0)
                {
                    Console.WriteLine("Response Additional Properties:");
                    foreach (var kvp in result.AdditionalProperties)
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                }
            }
            else
            {
                Console.WriteLine("GetIpoOrderById response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetIpoOrderByIdTest(IServiceProvider services)
        {
            var ipoApi = services.GetRequiredService<IIPOApi>();
            var orderId = await ResolveIpoOrderIdAsync(ipoApi);

            if (string.IsNullOrWhiteSpace(orderId))
            {
                Console.WriteLine("GetIpoOrderById sanity test skipped: the account has no IPO orders");
                return;
            }

            var response = await ipoApi.GetIpoOrderByIdAsync(orderId: orderId);
            var result = response.Ok();

            if (result == null)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("Invalid access token");
                throw new Exception("GetIpoOrderById response is null");
            }

            if (result.Data == null)
                throw new Exception("GetIpoOrderById data is null");

            if (string.IsNullOrWhiteSpace(result.Data.OrderId))
                throw new Exception("GetIpoOrderById: Data.OrderId is not populated");

            if (result.Data.OrderId != orderId)
                throw new Exception($"GetIpoOrderById: returned OrderId '{result.Data.OrderId}' does not match requested '{orderId}'");

            if (string.IsNullOrWhiteSpace(result.Data.Id))
                throw new Exception("GetIpoOrderById: Data.Id is not populated");

            if (string.IsNullOrWhiteSpace(result.Data.Status))
                throw new Exception("GetIpoOrderById: Data.Status is not populated");
        }

        /// <summary>
        /// Tests the CancelIpoOrder API functionality
        /// </summary>
        public static async Task PrintCancelIpoOrderTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing IPO API (CancelIpoOrder) ===");

            if (!EnableStateChangingIpoTests)
            {
                Console.WriteLine("SKIPPED: CancelIpoOrder withdraws a real IPO application from the live");
                Console.WriteLine("         account. Set EnableStateChangingIpoTests = true in IPOService");
                Console.WriteLine("         to run it.");
                Console.WriteLine("==================");
                return;
            }

            var ipoApi = services.GetRequiredService<IIPOApi>();
            var orderId = await ResolveIpoOrderIdAsync(ipoApi);

            if (string.IsNullOrWhiteSpace(orderId))
            {
                Console.WriteLine("No IPO orders found, skipping CancelIpoOrder test");
                Console.WriteLine("==================");
                return;
            }

            Console.WriteLine($"Cancelling IPO order: {orderId}");

            var response = await ipoApi.CancelIpoOrderAsync(orderId: orderId);
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine("Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  OrderId: {result.Data.OrderId}");
                    Console.WriteLine($"  Status: {result.Data.Status}");
                    if (result.Data.AdditionalProperties.Count > 0)
                    {
                        Console.WriteLine("  AdditionalProperties:");
                        foreach (var kvp in result.Data.AdditionalProperties)
                            Console.WriteLine($"    {kvp.Key}: {kvp.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("  (null)");
                }

                if (result.AdditionalProperties.Count > 0)
                {
                    Console.WriteLine("Response Additional Properties:");
                    foreach (var kvp in result.AdditionalProperties)
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                }
            }
            else
            {
                Console.WriteLine("CancelIpoOrder response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityCancelIpoOrderTest(IServiceProvider services)
        {
            if (!EnableStateChangingIpoTests)
            {
                Console.WriteLine("CancelIpoOrder sanity test skipped: state-changing endpoint is disabled " +
                                  "(set EnableStateChangingIpoTests = true in IPOService to run it)");
                return;
            }

            var ipoApi = services.GetRequiredService<IIPOApi>();
            var orderId = await ResolveIpoOrderIdAsync(ipoApi);

            if (string.IsNullOrWhiteSpace(orderId))
            {
                Console.WriteLine("CancelIpoOrder sanity test skipped: the account has no IPO orders");
                return;
            }

            var response = await ipoApi.CancelIpoOrderAsync(orderId: orderId);
            var result = response.Ok();

            if (result == null)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new Exception("Invalid access token");
                throw new Exception("CancelIpoOrder response is null");
            }

            if (result.Data == null)
                throw new Exception("CancelIpoOrder data is null");

            if (string.IsNullOrWhiteSpace(result.Data.OrderId))
                throw new Exception("CancelIpoOrder: Data.OrderId is not populated");

            if (result.Data.OrderId != orderId)
                throw new Exception($"CancelIpoOrder: returned OrderId '{result.Data.OrderId}' does not match requested '{orderId}'");

            if (string.IsNullOrWhiteSpace(result.Data.Status))
                throw new Exception("CancelIpoOrder: Data.Status is not populated");
        }
    }
}
