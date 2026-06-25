using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Extensions;
using UpstoxClient.Model;
using UpstoxClient.Test.Service;

namespace UpstoxClient.Test
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Warning);
                    // Suppress SDK-specific logging
                    logging.AddFilter("UpstoxClient.Api.ChargeApi", LogLevel.None);
                    logging.AddFilter("System.Net.Http.HttpClient.IChargeApi", LogLevel.Warning);
                    logging.AddFilter("Microsoft.Hosting.Lifetime", LogLevel.Warning);
                })
                .ConfigureApi((context, services, options) =>
                {
                    var token = new OAuthToken("your_token_here");
                    options.AddTokens(token);
                }).Build();
            await host.StartAsync();

            try
            {
                // await VerboseTest(host.Services);

                // await SanityTest(host.Services);

                await SanityTest(host.Services);

                // await MarketDataWebSocketTest(host.Services);

                // await PortfolioDataWebSocketTest(host.Services);
            
        
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            } 
            await host.StopAsync();
        }

        public static async Task VerboseTest(IServiceProvider services)
        {
                await ChargeService.PrintGetBrokerageTest(services);
                await ChargeService.PrintPostMarginTest(services);
                await ExpiredInstrumentService.PrintGetExpiriesResponseTest(services);
                await ExpiredInstrumentService.PrintGetExpiredFutureContractsTest(services);
                await ExpiredInstrumentService.PrintGetExpiredHistoricalCandleDataTest(services);
                await ExpiredInstrumentService.PrintGetExpiredOptionContractsTest(services);
                await FundamentalsService.PrintGetBalanceSheetTest(services);
                await FundamentalsService.PrintGetCashFlowTest(services);
                await FundamentalsService.PrintGetCompanyProfileTest(services);
                await FundamentalsService.PrintGetCompetitorsTest(services);
                await FundamentalsService.PrintGetCorporateActionsTest(services);
                await FundamentalsService.PrintGetIncomeStatementTest(services);
                await FundamentalsService.PrintGetKeyRatiosTest(services);
                await FundamentalsService.PrintGetShareHoldingsTest(services);
                await HistoryService.PrintGetHistoricalCandleData2Test(services);
                await HistoryService.PrintGetHistoricalCandleData3Test(services);
                await HistoryService.PrintGetIntraDayCandleData1Test(services);
                await HistoryV3Service.PrintGetHistoricalCandleDataTest(services);
                await HistoryV3Service.PrintGetHistoricalCandleDataWithFromDateTest(services);
                await HistoryV3Service.PrintGetIntraDayCandleDataTest(services);
                await IPOService.PrintGetIpoListingTest(services);
                await IPOService.PrintGetIpoDetailsTest(services);
                await InstrumentsService.PrintSearchInstrumentTest(services);
                await LoginService.PrintTokenTest(services);
                await LoginService.PrintInitTokenRequestForIndieUserTest(services);
                await MarketExtensionsService.PrintGetOiDataTest(services);
                await MarketExtensionsService.PrintGetChangeOiDataTest(services);
                await MarketExtensionsService.PrintGetPcrDataTest(services);
                await MarketExtensionsService.PrintGetMaxPainDataTest(services);
                await MarketExtensionsService.PrintGetFiiDataTest(services);
                await MarketExtensionsService.PrintGetDiiDataTest(services);
                await MarketHolidaysAndTimingsService.PrintGetExchangeTimingsTest(services);
                await MarketHolidaysAndTimingsService.PrintGetHolidayTest(services);
                await MarketHolidaysAndTimingsService.PrintGetHolidaysTest(services);
                await MarketHolidaysAndTimingsService.PrintGetMarketStatusTest(services);
                await SmartlistService.PrintGetSmartlistFuturesTest(services);
                await SmartlistService.PrintGetSmartlistMtfTest(services);
                await SmartlistService.PrintGetSmartlistOptionsTest(services);
                await MarketQuoteService.PrintGetFullMarketQuoteTest(services);
                await MarketQuoteV3Service.PrintGetLtpTest(services);
                await MarketQuoteV3Service.PrintGetMarketQuoteOHLCV3Test(services);
                await MarketQuoteV3Service.PrintGetMarketQuoteOptionGreekTest(services);
                await MutualFundService.PrintGetMutualFundHoldingsTest(services);
                await MutualFundService.PrintGetMutualFundOrdersTest(services);
                await MutualFundService.PrintGetMutualFundSipsTest(services);
                await MutualFundService.PrintGetMutualFundOrderTest(services);
                await NewsService.PrintGetNewsTest(services);
                await OptionsService.PrintGetOptionContractsTest(services);
                await OptionsService.PrintGetPutCallOptionChainTest(services);
                await OrderService.TestOrderBookAsync(services);
                await OrderService.PrintPlaceMultiOrderTest(services);
                await OrderService.PrintCancelMultiOrderTest(services);
                await OrderService.PrintExitPositionsTest(services);
                await OrderService.PrintGetOrderDetailsTest(services);
                await OrderService.PrintGetOrderStatusTest(services);
                await OrderService.PrintGetTradeHistoryTest(services);
                await OrderService.PrintGetTradesByOrderTest(services);
                await OrderV3Service.TestPlaceOrderV3Async(services);
                await OrderV3Service.PrintCancelGTTOrderTest(services);
                await OrderV3Service.PrintModifyGTTOrderTest(services);
                await OrderV3Service.PrintModifyOrderTest(services);
                await OrderV3Service.PrintPlaceGTTOrderTest(services);
                await OrderV3Service.PrintGetGttOrderDetailsTest(services);
                await OrderV3Service.PrintCancelOrderTest(services);
                await PortfolioService.PrintConvertPositionsTest(services);
                await PortfolioService.PrintGetHoldingsTest(services);
                await PortfolioService.PrintGetMtfPositionsTest(services);
                await PortfolioService.PrintGetPositionsTest(services);
                await PostTradeService.PrintGetTradesByDateRangeTest(services);
                await TradeProfitAndLossService.PrintGetProfitAndLossChargesTest(services);
                await TradeProfitAndLossService.PrintGetTradeWiseProfitAndLossDataTest(services);
                await TradeProfitAndLossService.PrintGetTradeWiseProfitAndLossMetaDataTest(services);
                await UserApiExtensionsService.PrintGetKillSwitchTest(services);
                await UserApiExtensionsService.PrintGetUserIpsTest(services);
                await UserApiExtensionsService.PrintGetUserFundMarginV3Test(services);
                await UserApiExtensionsService.PrintGetPayinHistoryTest(services);
                await UserApiExtensionsService.PrintGetPayoutHistoryTest(services);
                await PayoutService.PrintGetPayoutModesTest(services);
                await PayoutService.PrintInitiatePayoutTest(services);
                await PayoutService.PrintModifyPayoutTest(services);
                await PayoutService.PrintCancelPayoutTest(services);
                await UserApiExtensionsService.PrintUpdateKillSwitchTest(services);
                await UserApiExtensionsService.PrintUpdateUserIpTest(services);
                await UserService.PrintProfileTest(services);
                await UserService.PrintGetUserFundMarginTest(services);
                await WebsocketService.PrintAuthorizeMarketDataFeedTest(services);
                await WebsocketService.PrintGetPortfolioStreamFeedAuthorizeTest(services);
        }
        public static async Task UserAndMarketSanityTest(IServiceProvider services)
        {
            var results = new List<(string Name, bool Passed, string? Error)>();

            async Task Run(string name, Func<Task> test)
            {
                try { await test(); results.Add((name, true, null)); }
                catch (Exception ex) { results.Add((name, false, ex.Message)); }
            }

            Console.WriteLine("=== User API Sanity Tests ===");
            await Run("GetProfile",           () => UserService.SanityProfileTest(services));
            await Run("GetUserFundMargin",    () => UserService.SanityGetUserFundMarginTest(services));
            await Run("GetKillSwitch",        () => UserApiExtensionsService.SanityGetKillSwitchTest(services));
            await Run("GetUserIps",           () => UserApiExtensionsService.SanityGetUserIpsTest(services));
            await Run("GetUserFundMarginV3",  () => UserApiExtensionsService.SanityGetUserFundMarginV3Test(services));
            await Run("GetPayinHistory",      () => UserApiExtensionsService.SanityGetPayinHistoryTest(services));
            await Run("GetPayoutHistory",     () => UserApiExtensionsService.SanityGetPayoutHistoryTest(services));

            Console.WriteLine("=== Payout Sanity Tests ===");
            await Run("GetPayoutModes",       () => PayoutService.SanityGetPayoutModesTest(services));
            await Run("InitiatePayout",       () => PayoutService.SanityInitiatePayoutTest(services));
            await Run("ModifyPayout",         () => PayoutService.SanityModifyPayoutTest(services));
            await Run("CancelPayout",         () => PayoutService.SanityCancelPayoutTest(services));

            Console.WriteLine("=== Market Holidays & Timings Sanity Tests ===");
            await Run("GetExchangeTimings",   () => MarketHolidaysAndTimingsService.SanityGetExchangeTimingsTest(services));
            await Run("GetHoliday",           () => MarketHolidaysAndTimingsService.SanityGetHolidayTest(services));
            await Run("GetHolidays",          () => MarketHolidaysAndTimingsService.SanityGetHolidaysTest(services));
            await Run("GetMarketStatus",      () => MarketHolidaysAndTimingsService.SanityGetMarketStatusTest(services));

            Console.WriteLine("=== Market Extensions Sanity Tests ===");
            await Run("GetOiData",            () => MarketExtensionsService.SanityGetOiDataTest(services));
            await Run("GetChangeOiData",      () => MarketExtensionsService.SanityGetChangeOiDataTest(services));
            await Run("GetPcrData",           () => MarketExtensionsService.SanityGetPcrDataTest(services));
            await Run("GetMaxPainData",       () => MarketExtensionsService.SanityGetMaxPainDataTest(services));
            await Run("GetFiiData",           () => MarketExtensionsService.SanityGetFiiDataTest(services));
            await Run("GetDiiData",           () => MarketExtensionsService.SanityGetDiiDataTest(services));

            Console.WriteLine("=== Smartlist Sanity Tests ===");
            await Run("GetSmartlistFutures",  () => SmartlistService.SanityGetSmartlistFuturesTest(services));
            await Run("GetSmartlistMtf",      () => SmartlistService.SanityGetSmartlistMtfTest(services));
            await Run("GetSmartlistOptions",  () => SmartlistService.SanityGetSmartlistOptionsTest(services));

            Console.WriteLine();
            Console.WriteLine("=== Results ===");
            foreach (var (name, passed, error) in results)
                Console.WriteLine(passed ? $"  PASS  {name}" : $"  FAIL  {name}: {error}");

            int failed = results.Count(r => !r.Passed);
            Console.WriteLine();
            Console.WriteLine($"{results.Count - failed}/{results.Count} passed, {failed} failed");
        }

        public static async Task SanityTest(IServiceProvider services){
                await ChargeService.SanityGetBrokerageTest(services);
                await ChargeService.SanityPostMarginTest(services);
                await ExpiredInstrumentService.SanityGetExpiriesResponseTest(services);
                await ExpiredInstrumentService.SanityGetExpiredFutureContractsTest(services);
                await ExpiredInstrumentService.SanityGetExpiredHistoricalCandleDataTest(services);
                await ExpiredInstrumentService.SanityGetExpiredOptionContractsTest(services);
                await FundamentalsService.SanityGetBalanceSheetTest(services);
                await FundamentalsService.SanityGetCashFlowTest(services);
                await FundamentalsService.SanityGetCompanyProfileTest(services);
                await FundamentalsService.SanityGetCompetitorsTest(services);
                await FundamentalsService.SanityGetCorporateActionsTest(services);
                await FundamentalsService.SanityGetIncomeStatementTest(services);
                await FundamentalsService.SanityGetKeyRatiosTest(services);
                await FundamentalsService.SanityGetShareHoldingsTest(services);
                await HistoryService.SanityGetHistoricalCandleData2Test(services);
                await HistoryService.SanityGetHistoricalCandleData3Test(services);
                await HistoryService.SanityGetIntraDayCandleData1Test(services);
                await HistoryV3Service.SanityGetHistoricalCandleDataTest(services);
                await HistoryV3Service.SanityGetHistoricalCandleDataWithFromDateTest(services);
                await HistoryV3Service.SanityGetIntraDayCandleDataTest(services);
                await IPOService.SanityGetIpoListingTest(services);
                await IPOService.SanityGetIpoDetailsTest(services);
                await InstrumentsService.SanitySearchInstrumentTest(services);
                await LoginService.SanityTokenTest(services);
                await LoginService.SanityInitTokenRequestForIndieUserTest(services);
                await MarketExtensionsService.SanityGetOiDataTest(services);
                await MarketExtensionsService.SanityGetChangeOiDataTest(services);
                await MarketExtensionsService.SanityGetPcrDataTest(services);
                await MarketExtensionsService.SanityGetMaxPainDataTest(services);
                await MarketExtensionsService.SanityGetFiiDataTest(services);
                await MarketExtensionsService.SanityGetDiiDataTest(services);
                await MarketHolidaysAndTimingsService.SanityGetExchangeTimingsTest(services);
                await MarketHolidaysAndTimingsService.SanityGetHolidayTest(services);
                await MarketHolidaysAndTimingsService.SanityGetHolidaysTest(services);
                await MarketHolidaysAndTimingsService.SanityGetMarketStatusTest(services);
                await SmartlistService.SanityGetSmartlistFuturesTest(services);
                await SmartlistService.SanityGetSmartlistMtfTest(services);
                await SmartlistService.SanityGetSmartlistOptionsTest(services);
                await MarketQuoteService.SanityGetFullMarketQuoteTest(services);
                await MarketQuoteV3Service.SanityGetLtpTest(services);
                await MarketQuoteV3Service.SanityGetMarketQuoteOHLCV3Test(services);
                await MarketQuoteV3Service.SanityGetMarketQuoteOptionGreekTest(services);
                await MutualFundService.SanityGetMutualFundHoldingsTest(services);
                await MutualFundService.SanityGetMutualFundOrdersTest(services);
                await MutualFundService.SanityGetMutualFundSipsTest(services);
                await MutualFundService.SanityGetMutualFundOrderTest(services);
                await NewsService.SanityGetNewsTest(services);
                await OptionsService.SanityGetOptionContractsTest(services);
                await OptionsService.SanityGetPutCallOptionChainTest(services);
                await OrderV3Service.SanityPlaceOrderV3Test(services);
                await OrderService.SanityOrderBookTest(services);
                await OrderService.SanityPlaceMultiOrderTest(services);
                await OrderService.SanityCancelMultiOrderTest(services);
                await OrderService.SanityExitPositionsTest(services);
                await OrderService.SanityGetOrderDetailsTest(services);
                await OrderService.SanityGetOrderStatusTest(services);
                await OrderService.SanityGetTradeHistoryTest(services);
                await OrderService.SanityGetTradesByOrderTest(services);
                await OrderV3Service.SanityCancelGTTOrderTest(services);
                await OrderV3Service.SanityModifyGTTOrderTest(services);
                await OrderV3Service.SanityModifyOrderTest(services);
                await OrderV3Service.SanityPlaceGTTOrderTest(services);
                await OrderV3Service.SanityGetGttOrderDetailsTest(services);
                await OrderV3Service.SanityCancelOrderTest(services);
                await PortfolioService.SanityConvertPositionsTest(services);
                await PortfolioService.SanityGetMtfPositionsTest(services);
                await PortfolioService.SanityGetPositionsTest(services);
                await PortfolioService.SanityGetHoldingsTest(services);
                await PostTradeService.SanityGetTradesByDateRangeTest(services);
                await TradeProfitAndLossService.SanityGetProfitAndLossChargesTest(services);
                await TradeProfitAndLossService.SanityGetTradeWiseProfitAndLossDataTest(services);
                await UserApiExtensionsService.SanityGetKillSwitchTest(services);
                await UserApiExtensionsService.SanityGetUserIpsTest(services);
                await UserApiExtensionsService.SanityGetUserFundMarginV3Test(services);
                await UserApiExtensionsService.SanityGetPayinHistoryTest(services);
                await UserApiExtensionsService.SanityGetPayoutHistoryTest(services);
                await PayoutService.SanityGetPayoutModesTest(services);
                await UserApiExtensionsService.SanityUpdateKillSwitchTest(services);
                await UserApiExtensionsService.SanityUpdateUserIpTest(services);
                await UserService.SanityProfileTest(services);
                await UserService.SanityGetUserFundMarginTest(services);
                await WebsocketService.SanityAuthorizeMarketDataFeedTest(services);
                await WebsocketService.SanityGetPortfolioStreamFeedAuthorizeTest(services);

                // await LoginService.SanityLogoutTest(services);
        }
        public static async Task MarketDataWebSocketTest(IServiceProvider services){
            await MarketDataWebSocketBasicTest.RunExample(services);
            await MarketDataWebSocketReconnectionTest.RunReconnectionTest(services);
            await MarketDataWebSocketDirectTest.RunDirectTest(services);
            await MarketDataWebSocketService.RunExample(services);
        }
        public static async Task PortfolioDataWebSocketTest(IServiceProvider services){
            await PortfolioDataWebSocketService.RunExample(services);
            await PortfolioDataWebSocketReconnectionTest.RunReconnectionTest(services);
            await PortfolioDataWebSocketServerDisconnectTest.RunServerDisconnectTest(services);
        }
    }

}
