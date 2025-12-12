# UpstoxClient.Api.MarketQuoteApi

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetFullMarketQuote**](MarketQuoteApi.md#getfullmarketquote) | **GET** /v2/market-quote/quotes | Market quotes and instruments - Full market quotes |
| [**GetLastTradedPrice**](MarketQuoteApi.md#getlasttradedprice) | **GET** /v2/market-quote/ltp |  |
| [**GetOHLC**](MarketQuoteApi.md#getohlc) | **GET** /v2/market-quote/ohlc |  |

<a id="getfullmarketquote"></a>
# **GetFullMarketQuote**
> GetFullMarketQuoteResponse GetFullMarketQuote (string symbol = null, string instrumentKey = null)

Market quotes and instruments - Full market quotes

This API provides the functionality to retrieve the full market quotes for one or more instruments.This API returns the complete market data snapshot of up to 500 instruments in one go.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **symbol** | **string** | Comma separated list of symbols | [optional]  |
| **instrumentKey** | **string** | Comma separated list of instrument keys | [optional]  |

### Return type

[**GetFullMarketQuoteResponse**](GetFullMarketQuoteResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1009 - symbol is required&lt;br&gt;UDAPI1011 - symbol is of invalid format&lt;br&gt;UDAPI100011 - Invalid Instrument key |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getlasttradedprice"></a>
# **GetLastTradedPrice**
> GetMarketQuoteLastTradedPriceResponse GetLastTradedPrice (string symbol = null, string instrumentKey = null)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **symbol** | **string** |  | [optional]  |
| **instrumentKey** | **string** |  | [optional]  |

### Return type

[**GetMarketQuoteLastTradedPriceResponse**](GetMarketQuoteLastTradedPriceResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | Bad Request |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getohlc"></a>
# **GetOHLC**
> GetMarketQuoteOHLCResponse GetOHLC (string interval, string symbol = null, string instrumentKey = null)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **interval** | **string** |  |  |
| **symbol** | **string** |  | [optional]  |
| **instrumentKey** | **string** |  | [optional]  |

### Return type

[**GetMarketQuoteOHLCResponse**](GetMarketQuoteOHLCResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | Bad Request |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

