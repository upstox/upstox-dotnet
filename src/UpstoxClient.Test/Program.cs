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
                    var token = new OAuthToken("eyJ0eXAiOiJKV1QiLCJrZXlfaWQiOiJza192MS4wIiwiYWxnIjoiSFMyNTYifQ.eyJzdWIiOiI3UEJDNkQiLCJqdGkiOiI2OTNiOWVkNmJkODg5ZTY5OGM5ZTIyMmIiLCJpc011bHRpQ2xpZW50IjpmYWxzZSwiaXNQbHVzUGxhbiI6dHJ1ZSwiaWF0IjoxNzY1NTE0OTY2LCJpc3MiOiJ1ZGFwaS1nYXRld2F5LXNlcnZpY2UiLCJleHAiOjE3NjU1NzY4MDB9.7VlzChFwH2QBlztrQnJLkW7_rKcWqIKYWmS9XjMCZE8");
                    options.AddTokens(token);
                }).Build();
            await host.StartAsync();

            try
            {

                // await ChargeService.PrintGetBrokerageTest(host.Services);
                // await ChargeService.PrintPostMarginTest(host.Services);
                // await ExpiredInstrumentService.PrintGetExpiriesResponseTest(host.Services);
                // await ExpiredInstrumentService.PrintGetExpiredFutureContractsTest(host.Services);
                // await ExpiredInstrumentService.PrintGetExpiredHistoricalCandleDataTest(host.Services);
                // await ExpiredInstrumentService.PrintGetExpiredOptionContractsTest(host.Services);
                // await HistoryV3Service.PrintGetHistoricalCandleDataTest(host.Services);
                // await HistoryV3Service.PrintGetHistoricalCandleDataWithFromDateTest(host.Services);
                // await HistoryV3Service.PrintGetIntraDayCandleDataTest(host.Services);
                // await LoginService.PrintTokenTest(host.Services);
                // await LoginService.PrintInitTokenRequestForIndieUserTest(host.Services);
                // await MarketHolidaysAndTimingsService.PrintGetExchangeTimingsTest(host.Services);
                // await MarketHolidaysAndTimingsService.PrintGetHolidayTest(host.Services);
                // await MarketHolidaysAndTimingsService.PrintGetHolidaysTest(host.Services);
                // await MarketHolidaysAndTimingsService.PrintGetMarketStatusTest(host.Services);
                // await MarketQuoteService.PrintGetFullMarketQuoteTest(host.Services);
                // await MarketQuoteV3Service.PrintGetLtpTest(host.Services);
                // await MarketQuoteV3Service.PrintGetMarketQuoteOHLCV3Test(host.Services);
                // await MarketQuoteV3Service.PrintGetMarketQuoteOptionGreekTest(host.Services);
                // await OptionsService.PrintGetOptionContractsTest(host.Services);
                // await OptionsService.PrintGetPutCallOptionChainTest(host.Services);
                // await MarketDataWebSocketService.RunExample(host.Services);
                // await PortfolioDataWebSocketService.RunExample(host.Services);
                // await OrderService.TestOrderBookAsync(host.Services);
                // await OrderService.PrintPlaceMultiOrderTest(host.Services);
                // await OrderService.PrintCancelMultiOrderTest(host.Services);
                // await OrderService.PrintExitPositionsTest(host.Services);
                // await OrderService.PrintGetOrderDetailsTest(host.Services);
                // await OrderService.PrintGetOrderStatusTest(host.Services);
                // await OrderService.PrintGetTradeHistoryTest(host.Services);
                // await OrderService.PrintGetTradesByOrderTest(host.Services);
                // await OrderV3Service.TestPlaceOrderV3Async(host.Services);
                // await OrderV3Service.PrintCancelGTTOrderTest(host.Services);
                // await OrderV3Service.PrintModifyGTTOrderTest(host.Services);
                // await OrderV3Service.PrintModifyOrderTest(host.Services);
                // await OrderV3Service.PrintPlaceGTTOrderTest(host.Services);
                // await OrderV3Service.PrintGetGttOrderDetailsTest(host.Services);
                // await OrderV3Service.PrintCancelOrderTest(host.Services);
                // await PortfolioService.PrintConvertPositionsTest(host.Services);
                // await PortfolioService.PrintGetHoldingsTest(host.Services);
                // await PortfolioService.PrintGetMtfPositionsTest(host.Services);
                // await PortfolioService.PrintGetPositionsTest(host.Services);
                // await PostTradeService.PrintGetTradesByDateRangeTest(host.Services);
                // await TradeProfitAndLossService.PrintGetProfitAndLossChargesTest(host.Services);
                // await TradeProfitAndLossService.PrintGetTradeWiseProfitAndLossDataTest(host.Services);
                // await TradeProfitAndLossService.PrintGetTradeWiseProfitAndLossMetaDataTest(host.Services);
                // await UserService.PrintProfileTest(host.Services);
                // await UserService.PrintGetUserFundMarginTest(host.Services);
                // await WebsocketService.PrintAuthorizeMarketDataFeedTest(host.Services);
                // await WebsocketService.PrintGetPortfolioStreamFeedTest(host.Services);
                 // await WebsocketService.PrintGetPortfolioStreamFeedAuthorizeTest(host.Services);

                await ChargeService.SanityGetBrokerageTest(host.Services);
                await ChargeService.SanityPostMarginTest(host.Services);
                await ExpiredInstrumentService.SanityGetExpiriesResponseTest(host.Services);
                await ExpiredInstrumentService.SanityGetExpiredFutureContractsTest(host.Services);
                await ExpiredInstrumentService.SanityGetExpiredHistoricalCandleDataTest(host.Services);
                await ExpiredInstrumentService.SanityGetExpiredOptionContractsTest(host.Services);
                await HistoryV3Service.SanityGetHistoricalCandleDataTest(host.Services);
                await HistoryV3Service.SanityGetHistoricalCandleDataWithFromDateTest(host.Services);
                await HistoryV3Service.SanityGetIntraDayCandleDataTest(host.Services);
                await LoginService.SanityTokenTest(host.Services);
                await LoginService.SanityInitTokenRequestForIndieUserTest(host.Services);
                await MarketHolidaysAndTimingsService.SanityGetExchangeTimingsTest(host.Services);
                await MarketHolidaysAndTimingsService.SanityGetHolidayTest(host.Services);
                await MarketHolidaysAndTimingsService.SanityGetHolidaysTest(host.Services);
                await MarketHolidaysAndTimingsService.SanityGetMarketStatusTest(host.Services);
                await MarketQuoteService.SanityGetFullMarketQuoteTest(host.Services);
                await MarketQuoteV3Service.SanityGetLtpTest(host.Services);
                await MarketQuoteV3Service.SanityGetMarketQuoteOHLCV3Test(host.Services);
                await MarketQuoteV3Service.SanityGetMarketQuoteOptionGreekTest(host.Services);
                await OptionsService.SanityGetOptionContractsTest(host.Services);
                await OptionsService.SanityGetPutCallOptionChainTest(host.Services);
                await OrderV3Service.SanityPlaceOrderV3Test(host.Services);
                await OrderService.SanityOrderBookTest(host.Services);
                await OrderService.SanityPlaceMultiOrderTest(host.Services);
                await OrderService.SanityCancelMultiOrderTest(host.Services);
                await OrderService.SanityExitPositionsTest(host.Services);
                await OrderService.SanityGetOrderDetailsTest(host.Services);
                await OrderService.SanityGetOrderStatusTest(host.Services); 
                await OrderService.SanityGetTradeHistoryTest(host.Services);
                await OrderService.SanityGetTradesByOrderTest(host.Services);
                await OrderV3Service.SanityCancelGTTOrderTest(host.Services);
                await OrderV3Service.SanityModifyGTTOrderTest(host.Services);
                await OrderV3Service.SanityModifyOrderTest(host.Services);
                await OrderV3Service.SanityPlaceGTTOrderTest(host.Services);
                await OrderV3Service.SanityGetGttOrderDetailsTest(host.Services);
                await OrderV3Service.SanityCancelOrderTest(host.Services);
                await PortfolioService.SanityConvertPositionsTest(host.Services);
                await PortfolioService.SanityGetMtfPositionsTest(host.Services);
                await PortfolioService.SanityGetPositionsTest(host.Services);
                await PortfolioService.SanityGetHoldingsTest(host.Services);
                await PostTradeService.SanityGetTradesByDateRangeTest(host.Services);
                await TradeProfitAndLossService.SanityGetProfitAndLossChargesTest(host.Services);
                await TradeProfitAndLossService.SanityGetTradeWiseProfitAndLossDataTest(host.Services);
                await UserService.SanityProfileTest(host.Services);
                await UserService.SanityGetUserFundMarginTest(host.Services);
                await WebsocketService.SanityAuthorizeMarketDataFeedTest(host.Services);
                await WebsocketService.SanityGetPortfolioStreamFeedAuthorizeTest(host.Services);



                // await LoginService.SanityLogoutTest(host.Services);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            } 
            await host.StopAsync();
        }

    }
}
