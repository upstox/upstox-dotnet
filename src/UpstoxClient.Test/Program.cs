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

                // await MarketDataWebSocketTest(host.Services);

                await PortfolioDataWebSocketTest(host.Services);
            
        
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
                await HistoryV3Service.PrintGetHistoricalCandleDataTest(services);
                await HistoryV3Service.PrintGetHistoricalCandleDataWithFromDateTest(services);
                await HistoryV3Service.PrintGetIntraDayCandleDataTest(services);
                await LoginService.PrintTokenTest(services);
                await LoginService.PrintInitTokenRequestForIndieUserTest(services);
                await MarketHolidaysAndTimingsService.PrintGetExchangeTimingsTest(services);
                await MarketHolidaysAndTimingsService.PrintGetHolidayTest(services);
                await MarketHolidaysAndTimingsService.PrintGetHolidaysTest(services);
                await MarketHolidaysAndTimingsService.PrintGetMarketStatusTest(services);
                await MarketQuoteService.PrintGetFullMarketQuoteTest(services);
                await MarketQuoteV3Service.PrintGetLtpTest(services);
                await MarketQuoteV3Service.PrintGetMarketQuoteOHLCV3Test(services);
                await MarketQuoteV3Service.PrintGetMarketQuoteOptionGreekTest(services);
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
                await UserService.PrintProfileTest(services);
                await UserService.PrintGetUserFundMarginTest(services);
                await WebsocketService.PrintAuthorizeMarketDataFeedTest(services);
                await WebsocketService.PrintGetPortfolioStreamFeedAuthorizeTest(services);
        }
        public static async Task SanityTest(IServiceProvider services){
                await ChargeService.SanityGetBrokerageTest(services);
                await ChargeService.SanityPostMarginTest(services);
                await ExpiredInstrumentService.SanityGetExpiriesResponseTest(services);
                await ExpiredInstrumentService.SanityGetExpiredFutureContractsTest(services);
                await ExpiredInstrumentService.SanityGetExpiredHistoricalCandleDataTest(services);
                await ExpiredInstrumentService.SanityGetExpiredOptionContractsTest(services);
                await HistoryV3Service.SanityGetHistoricalCandleDataTest(services);
                await HistoryV3Service.SanityGetHistoricalCandleDataWithFromDateTest(services);
                await HistoryV3Service.SanityGetIntraDayCandleDataTest(services);
                await LoginService.SanityTokenTest(services);
                await LoginService.SanityInitTokenRequestForIndieUserTest(services);
                await MarketHolidaysAndTimingsService.SanityGetExchangeTimingsTest(services);
                await MarketHolidaysAndTimingsService.SanityGetHolidayTest(services);
                await MarketHolidaysAndTimingsService.SanityGetHolidaysTest(services);
                await MarketHolidaysAndTimingsService.SanityGetMarketStatusTest(services);
                await MarketQuoteService.SanityGetFullMarketQuoteTest(services);
                await MarketQuoteV3Service.SanityGetLtpTest(services);
                await MarketQuoteV3Service.SanityGetMarketQuoteOHLCV3Test(services);
                await MarketQuoteV3Service.SanityGetMarketQuoteOptionGreekTest(services);
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
