# UpstoxClient.Api.MarketHolidaysAndTimingsApi

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetExchangeTimings**](MarketHolidaysAndTimingsApi.md#getexchangetimings) | **GET** /v2/market/timings/{date} | Get Exchange Timings on particular date |
| [**GetHoliday**](MarketHolidaysAndTimingsApi.md#getholiday) | **GET** /v2/market/holidays/{date} | Get Holiday on particular date |
| [**GetHolidays**](MarketHolidaysAndTimingsApi.md#getholidays) | **GET** /v2/market/holidays | Get Holiday list of current year |
| [**GetMarketStatus**](MarketHolidaysAndTimingsApi.md#getmarketstatus) | **GET** /v2/market/status/{exchange} | Get Market status for particular exchange |

<a id="getexchangetimings"></a>
# **GetExchangeTimings**
> GetExchangeTimingResponse GetExchangeTimings (string date)

Get Exchange Timings on particular date

This API provides the functionality to retrieve the exchange timings on particular date


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **date** | **string** |  |  |

### Return type

[**GetExchangeTimingResponse**](GetExchangeTimingResponse.md)

### Authorization

No authorization required

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

<a id="getholiday"></a>
# **GetHoliday**
> GetHolidayResponse GetHoliday (string date)

Get Holiday on particular date

This API provides the functionality to retrieve the holiday on particular date


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **date** | **string** |  |  |

### Return type

[**GetHolidayResponse**](GetHolidayResponse.md)

### Authorization

No authorization required

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

<a id="getholidays"></a>
# **GetHolidays**
> GetHolidayResponse GetHolidays ()

Get Holiday list of current year

This API provides the functionality to retrieve the holiday list of current year


### Parameters
This endpoint does not need any parameter.
### Return type

[**GetHolidayResponse**](GetHolidayResponse.md)

### Authorization

No authorization required

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

<a id="getmarketstatus"></a>
# **GetMarketStatus**
> GetMarketStatusResponse GetMarketStatus (string exchange)

Get Market status for particular exchange

This API provides the functionality to retrieve the market status for particular exchange


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **exchange** | **string** |  |  |

### Return type

[**GetMarketStatusResponse**](GetMarketStatusResponse.md)

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

