# UpstoxClient.Api.ExpiredInstrumentApi

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetExpiredFutureContracts**](ExpiredInstrumentApi.md#getexpiredfuturecontracts) | **GET** /v2/expired-instruments/future/contract | Expired instruments - Get future contracts |
| [**GetExpiredHistoricalCandleData**](ExpiredInstrumentApi.md#getexpiredhistoricalcandledata) | **GET** /v2/expired-instruments/historical-candle/{expired_instrument_key}/{interval}/{to_date}/{from_date} | Expired Historical candle data |
| [**GetExpiredOptionContracts**](ExpiredInstrumentApi.md#getexpiredoptioncontracts) | **GET** /v2/expired-instruments/option/contract | Get expired option contracts |
| [**GetExpiriesResponse**](ExpiredInstrumentApi.md#getexpiriesresponse) | **GET** /v2/expired-instruments/expiries | Expired instruments - Get expiries |

<a id="getexpiredfuturecontracts"></a>
# **GetExpiredFutureContracts**
> GetExpiredFuturesContractResponse GetExpiredFutureContracts (string instrumentKey, string expiryDate)

Expired instruments - Get future contracts

This API provides the functionality to retrieve expired future contracts for a given instrument key and expiry date.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instrumentKey** | **string** | Instrument Key of asset |  |
| **expiryDate** | **string** | Expiry date of the instrument |  |

### Return type

[**GetExpiredFuturesContractResponse**](GetExpiredFuturesContractResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1009 - instrument_key is required&lt;br&gt;UDAPI1011 - instrument_key is of invalid format&lt;br&gt;UDAPI100011 - Invalid Instrument key&lt;br&gt; |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getexpiredhistoricalcandledata"></a>
# **GetExpiredHistoricalCandleData**
> GetHistoricalCandleResponse GetExpiredHistoricalCandleData (string expiredInstrumentKey, string interval, string toDate, string fromDate)

Expired Historical candle data

Get Expired OHLC values for all instruments across various timeframes. Expired Historical data can be fetched for the following durations. 1minute: last 1 month candles till endDate 30minute: last 1 year candles till endDate day: last 1 year candles till endDate week: last 10 year candles till endDate month: last 10 year candles till endDate


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **expiredInstrumentKey** | **string** | Expired Instrument Key of asset |  |
| **interval** | **string** | Interval to get expired ohlc data |  |
| **toDate** | **string** | to date |  |
| **fromDate** | **string** | from date |  |

### Return type

[**GetHistoricalCandleResponse**](GetHistoricalCandleResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1015 - to_date must be greater than or equal to from_date and Date should be in valid format: yyyy-mm-dd&lt;br&gt;UDAPI1020 - Interval accepts one of (1minute,30minute,day,week,month)&lt;br&gt;UDAPI1021 - Instrument key is of invalid format&lt;br&gt;UDAPI1022 - to_date is required&lt;br&gt;UDAPI100011 - Invalid Instrument key |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getexpiredoptioncontracts"></a>
# **GetExpiredOptionContracts**
> GetOptionContractResponse GetExpiredOptionContracts (string instrumentKey, string expiryDate)

Get expired option contracts

This API provides the functionality to retrieve the expired option contracts


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instrumentKey** | **string** | Instrument key for an underlying symbol |  |
| **expiryDate** | **string** | Expiry date in format: YYYY-mm-dd |  |

### Return type

[**GetOptionContractResponse**](GetOptionContractResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** |  |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getexpiriesresponse"></a>
# **GetExpiriesResponse**
> GetExpiriesResponse GetExpiriesResponse (string instrumentKey)

Expired instruments - Get expiries

This API provides the functionality to retrieve expiry dates for a given instrument key.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instrumentKey** | **string** | Instrument Key of asset |  |

### Return type

[**GetExpiriesResponse**](GetExpiriesResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1009 - instrument_key is required&lt;br&gt;UDAPI1011 - instrument_key is of invalid format&lt;br&gt;UDAPI100011 - Invalid Instrument key |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

