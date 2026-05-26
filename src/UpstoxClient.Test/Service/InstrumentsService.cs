using Microsoft.Extensions.DependencyInjection;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test.Service
{
    public class InstrumentsService
    {
        /// <summary>
        /// Tests the SearchInstrument API functionality
        /// </summary>
        public static async Task PrintSearchInstrumentTest(IServiceProvider services)
        {
            Console.WriteLine("=== Testing Instruments API (SearchInstrument) ===");

            var instrumentsApi = services.GetRequiredService<IInstrumentsApi>();
            var response = await instrumentsApi.SearchInstrumentAsync(
                query: "Reliance"
            );
            var result = response.Ok();

            if (result != null)
            {
                Console.WriteLine($"Status: {result.Status?.ToString() ?? "null"}");
                Console.WriteLine($"Data:");
                if (result.Data != null && result.Data.Count > 0)
                {
                    Console.WriteLine($"  Found {result.Data.Count} instruments");
                    foreach (var item in result.Data.Take(5))
                    {
                        Console.WriteLine($"    InstrumentKey: {item.InstrumentKey}");
                        Console.WriteLine($"    Name: {item.Name}");
                        Console.WriteLine($"    Exchange: {item.Exchange}");
                        Console.WriteLine($"    Segment: {item.Segment}");
                        Console.WriteLine($"    InstrumentType: {item.InstrumentType}");
                        Console.WriteLine($"    Isin: {item.Isin}");
                        Console.WriteLine($"    Expiry: {item.Expiry}");
                        Console.WriteLine($"    Country: {item.Country}");
                        Console.WriteLine($"    Currency: {item.Currency}");
                        Console.WriteLine($"    Description: {item.Description}");
                        Console.WriteLine($"    ExchangeToken: {item.ExchangeToken}");
                        Console.WriteLine($"    TradingSymbol: {item.TradingSymbol}");
                        Console.WriteLine($"    ShortName: {item.ShortName}");
                        Console.WriteLine($"    TickSize: {item.TickSize}");
                        Console.WriteLine($"    LotSize: {item.LotSize}");
                        Console.WriteLine($"    FreezeQuantity: {item.FreezeQuantity}");
                        Console.WriteLine($"    UnderlyingKey: {item.UnderlyingKey}");
                        Console.WriteLine($"    UnderlyingType: {item.UnderlyingType}");
                        Console.WriteLine($"    SecurityType: {item.SecurityType}");
                        Console.WriteLine($"    MtfEnabled: {item.MtfEnabled}");
                        Console.WriteLine($"    MtfBracket: {item.MtfBracket}");
                        Console.WriteLine($"    Weekly: {item.Weekly}");
                        Console.WriteLine($"    Latency: {item.Latency}");
                        Console.WriteLine("    ---");
                    }
                    if (result.Data.Count > 5)
                    {
                        Console.WriteLine($"    ... and {result.Data.Count - 5} more");
                    }
                }
                else
                {
                    Console.WriteLine("  (no instruments found)");
                }

                if (result.MetaData != null && result.MetaData.Page != null)
                {
                    Console.WriteLine($"  MetaData.Page: PageNumber={result.MetaData.Page.PageNumber}, TotalPages={result.MetaData.Page.TotalPages}, Records={result.MetaData.Page.Records}, TotalRecords={result.MetaData.Page.TotalRecords}");
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
                Console.WriteLine("SearchInstrument response is null");
            }
            Console.WriteLine("==================");
        }

        public static async Task SanitySearchInstrumentTest(IServiceProvider services)
        {
            var instrumentsApi = services.GetRequiredService<IInstrumentsApi>();
            var response = await instrumentsApi.SearchInstrumentAsync(
                query: "Reliance"
            );
            var result = response.Ok();

            if (result == null)
            {
                Console.WriteLine("SearchInstrument response is null");
                return;
            }

            // Validate data exists if applicable
            if (result.Data == null)
            {
                Console.WriteLine("SearchInstrument data is null");
                return;
            }
        }
    }
}
