# UpstoxClient.Api.MarketQuoteV3Api

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetLtp**](MarketQuoteV3Api.md#getltp) | **GET** /v3/market-quote/ltp | Market quotes and instruments - LTP quotes. |
| [**GetMarketQuoteOHLCV3**](MarketQuoteV3Api.md#getmarketquoteohlcv3) | **GET** /v3/market-quote/ohlc | Market quotes and instruments - OHLC quotes |
| [**GetMarketQuoteOptionGreek**](MarketQuoteV3Api.md#getmarketquoteoptiongreek) | **GET** /v3/market-quote/option-greek | Market quotes and instruments - Option Greek |

<a id="getltp"></a>
# **GetLtp**
> GetMarketQuoteLastTradedPriceResponseV3 GetLtp (string instrumentKey = null)

Market quotes and instruments - LTP quotes.

This API provides the functionality to retrieve the LTP quotes for one or more instruments.This API returns the LTPs of up to 500 instruments in one go.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instrumentKey** | **string** | Comma separated list of instrument keys | [optional]  |

### Return type

[**GetMarketQuoteLastTradedPriceResponseV3**](GetMarketQuoteLastTradedPriceResponseV3.md)

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

<a id="getmarketquoteohlcv3"></a>
# **GetMarketQuoteOHLCV3**
> GetMarketQuoteOHLCResponseV3 GetMarketQuoteOHLCV3 (string interval, string instrumentKey = null)

Market quotes and instruments - OHLC quotes

This API provides the functionality to retrieve the OHLC quotes for one or more instruments.This API returns the OHLC snapshots of up to 500 instruments in one go.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **interval** | **string** | Interval to get ohlc data |  |
| **instrumentKey** | **string** | Comma separated list of instrument keys | [optional]  |

### Return type

[**GetMarketQuoteOHLCResponseV3**](GetMarketQuoteOHLCResponseV3.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1009 - symbol is required&lt;br&gt;UDAPI1011 - symbol is of invalid format&lt;br&gt;UDAPI1027 - interval is required&lt;br&gt;UDAPI1028 - Invalid interval&lt;br&gt;UDAPI100011 - Invalid Instrument key |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmarketquoteoptiongreek"></a>
# **GetMarketQuoteOptionGreek**
> GetMarketQuoteOptionGreekResponseV3 GetMarketQuoteOptionGreek (string instrumentKey = null)

Market quotes and instruments - Option Greek

This API provides the functionality to retrieve the Option Greek data for one or more instruments.This API returns the Option Greek data of up to 500 instruments in one go.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instrumentKey** | **string** | Comma separated list of instrument keys | [optional]  |

### Return type

[**GetMarketQuoteOptionGreekResponseV3**](GetMarketQuoteOptionGreekResponseV3.md)

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

