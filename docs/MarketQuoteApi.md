# UpstoxClient.Api.MarketQuoteApi

All URIs are relative to *https://api-v2.upstox.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetFullMarketQuote**](MarketQuoteApi.md#getfullmarketquote) | **GET** /market-quote/quotes | Market quotes and instruments - Full market quotes
[**GetMarketQuoteOHLC**](MarketQuoteApi.md#getmarketquoteohlc) | **GET** /market-quote/ohlc | Market quotes and instruments - OHLC quotes
[**Ltp**](MarketQuoteApi.md#ltp) | **GET** /market-quote/ltp | Market quotes and instruments - LTP quotes.

<a name="getfullmarketquote"></a>
# **GetFullMarketQuote**
> GetFullMarketQuoteResponse GetFullMarketQuote (string symbol, string apiVersion)

Market quotes and instruments - Full market quotes

This API provides the functionality to retrieve the full market quotes for one or more instruments.This API returns the complete market data snapshot of up to 500 instruments in one go.

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetFullMarketQuoteExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MarketQuoteApi();
            var symbol = symbol_example;  // string | Comma separated list of symbols
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Market quotes and instruments - Full market quotes
                GetFullMarketQuoteResponse result = apiInstance.GetFullMarketQuote(symbol, apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MarketQuoteApi.GetFullMarketQuote: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **symbol** | **string**| Comma separated list of symbols | 
 **apiVersion** | **string**| API Version Header | 

### Return type

[**GetFullMarketQuoteResponse**](GetFullMarketQuoteResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getmarketquoteohlc"></a>
# **GetMarketQuoteOHLC**
> GetMarketQuoteOHLCResponse GetMarketQuoteOHLC (string symbol, string interval, string apiVersion)

Market quotes and instruments - OHLC quotes

This API provides the functionality to retrieve the OHLC quotes for one or more instruments.This API returns the OHLC snapshots of up to 1000 instruments in one go.

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetMarketQuoteOHLCExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MarketQuoteApi();
            var symbol = symbol_example;  // string | Comma separated list of symbols
            var interval = interval_example;  // string | Interval to get ohlc data
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Market quotes and instruments - OHLC quotes
                GetMarketQuoteOHLCResponse result = apiInstance.GetMarketQuoteOHLC(symbol, interval, apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MarketQuoteApi.GetMarketQuoteOHLC: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **symbol** | **string**| Comma separated list of symbols | 
 **interval** | **string**| Interval to get ohlc data | 
 **apiVersion** | **string**| API Version Header | 

### Return type

[**GetMarketQuoteOHLCResponse**](GetMarketQuoteOHLCResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="ltp"></a>
# **Ltp**
> GetMarketQuoteLastTradedPriceResponse Ltp (string symbol, string apiVersion)

Market quotes and instruments - LTP quotes.

This API provides the functionality to retrieve the LTP quotes for one or more instruments.This API returns the LTPs of up to 1000 instruments in one go.

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class LtpExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new MarketQuoteApi();
            var symbol = symbol_example;  // string | Comma separated list of symbols
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Market quotes and instruments - LTP quotes.
                GetMarketQuoteLastTradedPriceResponse result = apiInstance.Ltp(symbol, apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MarketQuoteApi.Ltp: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **symbol** | **string**| Comma separated list of symbols | 
 **apiVersion** | **string**| API Version Header | 

### Return type

[**GetMarketQuoteLastTradedPriceResponse**](GetMarketQuoteLastTradedPriceResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
