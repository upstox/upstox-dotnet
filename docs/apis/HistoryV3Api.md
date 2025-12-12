# UpstoxClient.Api.HistoryV3Api

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetHistoricalCandleData**](HistoryV3Api.md#gethistoricalcandledata) | **GET** /v3/historical-candle/{instrumentKey}/{unit}/{interval}/{to_date} | Historical candle data |
| [**GetHistoricalCandleDataWithFromDate**](HistoryV3Api.md#gethistoricalcandledatawithfromdate) | **GET** /v3/historical-candle/{instrumentKey}/{unit}/{interval}/{to_date}/{from_date} | Historical candle data |
| [**GetIntraDayCandleData**](HistoryV3Api.md#getintradaycandledata) | **GET** /v3/historical-candle/intraday/{instrumentKey}/{unit}/{interval} | Intra day candle data |

<a id="gethistoricalcandledata"></a>
# **GetHistoricalCandleData**
> GetHistoricalCandleResponse GetHistoricalCandleData (string instrumentKey, string unit, int interval, string toDate)

Historical candle data

Get OHLC values for all instruments for the present trading day with expanded interval options.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instrumentKey** | **string** |  |  |
| **unit** | **string** |  |  |
| **interval** | **int** |  |  |
| **toDate** | **string** |  |  |

### Return type

[**GetHistoricalCandleResponse**](GetHistoricalCandleResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1015 - to_date must be greater than or equal to from_date and Date should be in valid format: yyyy-mm-dd&lt;br&gt;UDAPI1021 - Instrument key is of invalid format&lt;br&gt;UDAPI1022 - to_date is required&lt;br&gt;UDAPI1146 - Invalid unit&lt;br&gt;UDAPI1147 - Invalid interval&lt;br&gt;UDAPI100011 - Invalid Instrument key |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="gethistoricalcandledatawithfromdate"></a>
# **GetHistoricalCandleDataWithFromDate**
> GetHistoricalCandleResponse GetHistoricalCandleDataWithFromDate (string instrumentKey, string unit, int interval, string toDate, string fromDate)

Historical candle data

Get OHLC values for all instruments for the present trading day with expanded interval options


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instrumentKey** | **string** |  |  |
| **unit** | **string** |  |  |
| **interval** | **int** |  |  |
| **toDate** | **string** |  |  |
| **fromDate** | **string** |  |  |

### Return type

[**GetHistoricalCandleResponse**](GetHistoricalCandleResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1015 - to_date must be greater than or equal to from_date and Date should be in valid format: yyyy-mm-dd&lt;br&gt;UDAPI1021 - Instrument key is of invalid format&lt;br&gt;UDAPI1022 - to_date is required&lt;br&gt;UDAPI1146 - Invalid unit&lt;br&gt;UDAPI1147 - Invalid interval&lt;br&gt;UDAPI1148 - Invalid date range&lt;br&gt;UDAPI100011 - Invalid Instrument key |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getintradaycandledata"></a>
# **GetIntraDayCandleData**
> GetIntraDayCandleResponse GetIntraDayCandleData (string instrumentKey, string unit, int interval)

Intra day candle data

Get OHLC values for all instruments for the present trading day


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instrumentKey** | **string** |  |  |
| **unit** | **string** |  |  |
| **interval** | **int** |  |  |

### Return type

[**GetIntraDayCandleResponse**](GetIntraDayCandleResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1021 - Instrument key is of invalid format&lt;br&gt;UDAPI1146 - Invalid unit&lt;br&gt;UDAPI1147 - Invalid interval&lt;br&gt;UDAPI100011 - Invalid Instrument key |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

