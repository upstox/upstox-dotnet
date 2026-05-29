using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class FundamentalsService
    {
        /// <summary>
        /// Tests the GetBalanceSheet API functionality
        /// </summary>
        public static async Task PrintGetBalanceSheetTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Fundamentals API (GetBalanceSheet) ===");

            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetBalanceSheetAsync(
                isin: "INE040A01034"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Type: {result.Data.Type}");
                    Console.WriteLine($"  TimePeriod: {result.Data.TimePeriod}");
                    Console.WriteLine($"  UnitsIn: {result.Data.UnitsIn}");
                    if (result.Data.History != null && result.Data.History.Count > 0)
                    {
                        Console.WriteLine($"  History ({result.Data.History.Count} entries, showing first 3):");
                        foreach (var item in result.Data.History.Take(3))
                        {
                            Console.WriteLine($"    Period: {item.Period}, TotalAsset: {item.TotalAsset}, TotalLiability: {item.TotalLiability}");
                        }
                        if (result.Data.History.Count > 3)
                        {
                            Console.WriteLine($"    ... and {result.Data.History.Count - 3} more");
                        }
                    }
                    else
                    {
                        Console.WriteLine("  History: (none)");
                    }
                    if (result.Data.FullStatement != null && result.Data.FullStatement.Count > 0)
                    {
                        Console.WriteLine($"  FullStatement ({result.Data.FullStatement.Count} entries, showing first 3):");
                        foreach (var entry in result.Data.FullStatement.Take(3))
                        {
                            Console.WriteLine($"    Particular: {entry.Particular}");
                            if (entry.History != null && entry.History.Count > 0)
                            {
                                Console.WriteLine($"    History (first): Period={entry.History[0].Period}, Value={entry.History[0].Value}, Change={entry.History[0].Change}");
                            }
                            Console.WriteLine("    ---");
                        }
                        if (result.Data.FullStatement.Count > 3)
                        {
                            Console.WriteLine($"    ... and {result.Data.FullStatement.Count - 3} more");
                        }
                    }
                    else
                    {
                        Console.WriteLine("  FullStatement: (none)");
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
                    {
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                    }
                }
            }
            else
            {
                Console.WriteLine("GetBalanceSheet response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetBalanceSheetTest(IServiceProvider services)
        {
            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetBalanceSheetAsync(
                isin: "INE040A01034"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetBalanceSheet response is null");
                return;
            }

            if (result.Data == null)
            {
                Console.WriteLine("GetBalanceSheet data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetCashFlow API functionality
        /// </summary>
        public static async Task PrintGetCashFlowTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Fundamentals API (GetCashFlow) ===");

            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetCashFlowAsync(
                isin: "INE040A01034"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Type: {result.Data.Type}");
                    Console.WriteLine($"  TimePeriod: {result.Data.TimePeriod}");
                    Console.WriteLine($"  UnitsIn: {result.Data.UnitsIn}");
                    if (result.Data.CashFlow != null && result.Data.CashFlow.Count > 0)
                    {
                        Console.WriteLine($"  CashFlow ({result.Data.CashFlow.Count} entries):");
                        foreach (var entry in result.Data.CashFlow.Take(3))
                        {
                            Console.WriteLine($"    Category: {entry.Category}");
                            if (entry.History != null && entry.History.Count > 0)
                            {
                                Console.WriteLine($"    History (first entry): Period={entry.History[0].Period}, Value={entry.History[0].Value}, Change={entry.History[0].Change}");
                            }
                            Console.WriteLine("    ---");
                        }
                    }
                    else
                    {
                        Console.WriteLine("  CashFlow: (none)");
                    }
                    if (result.Data.FullStatement != null && result.Data.FullStatement.Count > 0)
                    {
                        Console.WriteLine($"  FullStatement ({result.Data.FullStatement.Count} entries, showing first 3):");
                        foreach (var entry in result.Data.FullStatement.Take(3))
                        {
                            Console.WriteLine($"    Particular: {entry.Particular}");
                            if (entry.History != null && entry.History.Count > 0)
                            {
                                Console.WriteLine($"    History (first): Period={entry.History[0].Period}, Value={entry.History[0].Value}, Change={entry.History[0].Change}");
                            }
                            Console.WriteLine("    ---");
                        }
                        if (result.Data.FullStatement.Count > 3)
                        {
                            Console.WriteLine($"    ... and {result.Data.FullStatement.Count - 3} more");
                        }
                    }
                    else
                    {
                        Console.WriteLine("  FullStatement: (none)");
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
                    {
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                    }
                }
            }
            else
            {
                Console.WriteLine("GetCashFlow response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetCashFlowTest(IServiceProvider services)
        {
            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetCashFlowAsync(
                isin: "INE040A01034"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetCashFlow response is null");
                return;
            }

            if (result.Data == null)
            {
                Console.WriteLine("GetCashFlow data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetCompanyProfile API functionality
        /// </summary>
        public static async Task PrintGetCompanyProfileTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Fundamentals API (GetCompanyProfile) ===");

            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetCompanyProfileAsync(
                isin: "INE040A01034"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Sector: {result.Data.Sector}");
                    Console.WriteLine($"  SectorMarketCapInr: {result.Data.SectorMarketCapInr}");
                    Console.WriteLine($"  SectorMarketCapUsd: {result.Data.SectorMarketCapUsd}");
                    var profile = result.Data.CompanyProfile;
                    if (!string.IsNullOrEmpty(profile))
                    {
                        Console.WriteLine($"  CompanyProfile: {profile.Substring(0, Math.Min(200, profile.Length))}...");
                    }
                    else
                    {
                        Console.WriteLine("  CompanyProfile: (null or empty)");
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
                    {
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                    }
                }
            }
            else
            {
                Console.WriteLine("GetCompanyProfile response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetCompanyProfileTest(IServiceProvider services)
        {
            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetCompanyProfileAsync(
                isin: "INE040A01034"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetCompanyProfile response is null");
                return;
            }

            if (result.Data == null)
            {
                Console.WriteLine("GetCompanyProfile data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetCompetitors API functionality
        /// </summary>
        public static async Task PrintGetCompetitorsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Fundamentals API (GetCompetitors) ===");

            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetCompetitorsAsync(
                instrumentKey: "NSE_EQ|INE040A01034"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} competitors (showing first 3):");
                    foreach (var competitor in result.Data.Take(3))
                    {
                        Console.WriteLine($"    InstrumentKey: {competitor.InstrumentKey}");
                        Console.WriteLine($"    Sector: {competitor.Sector}");
                        Console.WriteLine($"    SectorMarketCapInr: {competitor.SectorMarketCapInr}");
                        Console.WriteLine($"    SectorMarketCapUsd: {competitor.SectorMarketCapUsd}");
                        if (!string.IsNullOrEmpty(competitor.CompanyProfile))
                        {
                            Console.WriteLine($"    CompanyProfile: {competitor.CompanyProfile.Substring(0, Math.Min(100, competitor.CompanyProfile.Length))}...");
                        }
                        else
                        {
                            Console.WriteLine("    CompanyProfile: (null or empty)");
                        }
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no competitors found)");
                }

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
                Console.WriteLine("GetCompetitors response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetCompetitorsTest(IServiceProvider services)
        {
            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetCompetitorsAsync(
                instrumentKey: "NSE_EQ|INE040A01034"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetCompetitors response is null");
                return;
            }

            if (result.Data == null)
            {
                Console.WriteLine("GetCompetitors data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetCorporateActions API functionality
        /// </summary>
        public static async Task PrintGetCorporateActionsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Fundamentals API (GetCorporateActions) ===");

            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetCorporateActionsAsync(
                isin: "INE040A01034"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} corporate actions (showing first 3):");
                    foreach (var action in result.Data.Take(3))
                    {
                        Console.WriteLine($"    Name: {action.Name}");
                        Console.WriteLine($"    ExpiryDate: {action.ExpiryDate}");
                        Console.WriteLine($"    Amount: {action.Amount}");
                        Console.WriteLine($"    Ratio: {action.Ratio}");
                        if (action.EventDetails != null && action.EventDetails.Count > 0)
                        {
                            Console.WriteLine($"    EventDetails ({action.EventDetails.Count} items):");
                            foreach (var detail in action.EventDetails.Take(3))
                            {
                                Console.WriteLine($"      Name: {detail.Name}, Value: {detail.Value}");
                            }
                        }
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no corporate actions found)");
                }

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
                Console.WriteLine("GetCorporateActions response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetCorporateActionsTest(IServiceProvider services)
        {
            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetCorporateActionsAsync(
                isin: "INE040A01034"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetCorporateActions response is null");
                return;
            }

            if (result.Data == null)
            {
                Console.WriteLine("GetCorporateActions data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetIncomeStatement API functionality
        /// </summary>
        public static async Task PrintGetIncomeStatementTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Fundamentals API (GetIncomeStatement) ===");

            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetIncomeStatementAsync(
                isin: "INE040A01034"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null)
                {
                    Console.WriteLine($"  Type: {result.Data.Type}");
                    Console.WriteLine($"  TimePeriod: {result.Data.TimePeriod}");
                    Console.WriteLine($"  UnitsIn: {result.Data.UnitsIn}");
                    if (result.Data.IncomeStatement != null && result.Data.IncomeStatement.Count > 0)
                    {
                        Console.WriteLine($"  IncomeStatement ({result.Data.IncomeStatement.Count} entries):");
                        foreach (var entry in result.Data.IncomeStatement.Take(3))
                        {
                            Console.WriteLine($"    Category: {entry.Category}");
                            if (entry.History != null && entry.History.Count > 0)
                            {
                                Console.WriteLine($"    History (first entry): Period={entry.History[0].Period}, Value={entry.History[0].Value}, Change={entry.History[0].Change}");
                            }
                            Console.WriteLine("    ---");
                        }
                    }
                    else
                    {
                        Console.WriteLine("  IncomeStatement: (none)");
                    }
                    if (result.Data.FullStatement != null && result.Data.FullStatement.Count > 0)
                    {
                        Console.WriteLine($"  FullStatement ({result.Data.FullStatement.Count} entries, showing first 3):");
                        foreach (var entry in result.Data.FullStatement.Take(3))
                        {
                            Console.WriteLine($"    Particular: {entry.Particular}");
                            if (entry.History != null && entry.History.Count > 0)
                            {
                                Console.WriteLine($"    History (first): Period={entry.History[0].Period}, Value={entry.History[0].Value}, Change={entry.History[0].Change}");
                            }
                            Console.WriteLine("    ---");
                        }
                        if (result.Data.FullStatement.Count > 3)
                        {
                            Console.WriteLine($"    ... and {result.Data.FullStatement.Count - 3} more");
                        }
                    }
                    else
                    {
                        Console.WriteLine("  FullStatement: (none)");
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
                    {
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                    }
                }
            }
            else
            {
                Console.WriteLine("GetIncomeStatement response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetIncomeStatementTest(IServiceProvider services)
        {
            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetIncomeStatementAsync(
                isin: "INE040A01034"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetIncomeStatement response is null");
                return;
            }

            if (result.Data == null)
            {
                Console.WriteLine("GetIncomeStatement data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetKeyRatios API functionality
        /// </summary>
        public static async Task PrintGetKeyRatiosTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Fundamentals API (GetKeyRatios) ===");

            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetKeyRatiosAsync(
                isin: "INE040A01034"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} key ratios (showing first 5):");
                    foreach (var ratio in result.Data.Take(5))
                    {
                        Console.WriteLine($"    Name: {ratio.Name}");
                        Console.WriteLine($"    CompanyValue: {ratio.CompanyValue}");
                        Console.WriteLine($"    SectorValue: {ratio.SectorValue}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 5)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 5} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no key ratios found)");
                }

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
                Console.WriteLine("GetKeyRatios response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetKeyRatiosTest(IServiceProvider services)
        {
            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetKeyRatiosAsync(
                isin: "INE040A01034"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetKeyRatios response is null");
                return;
            }

            if (result.Data == null)
            {
                Console.WriteLine("GetKeyRatios data is null");
                return;
            }
        }

        /// <summary>
        /// Tests the GetShareHoldings API functionality
        /// </summary>
        public static async Task PrintGetShareHoldingsTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Fundamentals API (GetShareHoldings) ===");

            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetShareHoldingsAsync(
                isin: "INE040A01034"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} shareholding categories (showing first 3):");
                    foreach (var holding in result.Data.Take(3))
                    {
                        Console.WriteLine($"    Category: {holding.Category}");
                        if (holding.History != null && holding.History.Count > 0)
                        {
                            Console.WriteLine($"    History (first entry): Period={holding.History[0].Period}, Value={holding.History[0].Value}");
                        }
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 3)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 3} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no shareholding data found)");
                }

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
                Console.WriteLine("GetShareHoldings response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanityGetShareHoldingsTest(IServiceProvider services)
        {
            var fundamentalsApi = services.GetRequiredService<IFundamentalsApi>();
            var response = await fundamentalsApi.GetShareHoldingsAsync(
                isin: "INE040A01034"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("GetShareHoldings response is null");
                return;
            }

            if (result.Data == null)
            {
                Console.WriteLine("GetShareHoldings data is null");
                return;
            }
        }
    }
}
