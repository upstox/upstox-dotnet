# UpstoxClient.Api.HistoricalCandleDataControllerV2Api

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetHistoricalCandleData1**](HistoricalCandleDataControllerV2Api.md#gethistoricalcandledata1) | **GET** /v2/historical-candle/{instrumentKey}/{interval}/{to_date} |  |
| [**GetHistoricalCandleData2**](HistoricalCandleDataControllerV2Api.md#gethistoricalcandledata2) | **GET** /v2/historical-candle/{instrumentKey}/{interval}/{to_date}/{from_date} |  |
| [**GetIntraDayCandleData1**](HistoricalCandleDataControllerV2Api.md#getintradaycandledata1) | **GET** /v2/historical-candle/intraday/{instrumentKey}/{interval} |  |

<a id="gethistoricalcandledata1"></a>
# **GetHistoricalCandleData1**
> GetHistoricalCandleResponse GetHistoricalCandleData1 (string instrumentKey, string interval, string toDate)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instrumentKey** | **string** |  |  |
| **interval** | **string** |  |  |
| **toDate** | **string** |  |  |

### Return type

[**GetHistoricalCandleResponse**](GetHistoricalCandleResponse.md)

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

<a id="gethistoricalcandledata2"></a>
# **GetHistoricalCandleData2**
> GetHistoricalCandleResponse GetHistoricalCandleData2 (string instrumentKey, string interval, string toDate, string fromDate)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instrumentKey** | **string** |  |  |
| **interval** | **string** |  |  |
| **toDate** | **string** |  |  |
| **fromDate** | **string** |  |  |

### Return type

[**GetHistoricalCandleResponse**](GetHistoricalCandleResponse.md)

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

<a id="getintradaycandledata1"></a>
# **GetIntraDayCandleData1**
> GetIntraDayCandleResponse GetIntraDayCandleData1 (string instrumentKey, string interval)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instrumentKey** | **string** |  |  |
| **interval** | **string** |  |  |

### Return type

[**GetIntraDayCandleResponse**](GetIntraDayCandleResponse.md)

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

