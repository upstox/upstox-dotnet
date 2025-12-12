# UpstoxClient.Api.PortfolioApi

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ConvertPositions**](PortfolioApi.md#convertpositions) | **PUT** /v2/portfolio/convert-position | Convert Positions |
| [**GetHoldings**](PortfolioApi.md#getholdings) | **GET** /v2/portfolio/long-term-holdings | Get Holdings |
| [**GetMtfPositions**](PortfolioApi.md#getmtfpositions) | **GET** /v3/portfolio/mtf-positions | Get MTF positions |
| [**GetPositions**](PortfolioApi.md#getpositions) | **GET** /v2/portfolio/short-term-positions | Get Positions |

<a id="convertpositions"></a>
# **ConvertPositions**
> ConvertPositionResponse ConvertPositions (ConvertPositionRequest convertPositionRequest)

Convert Positions

Convert the margin product of an open position


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **convertPositionRequest** | [**ConvertPositionRequest**](ConvertPositionRequest.md) |  |  |

### Return type

[**ConvertPositionResponse**](ConvertPositionResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | Bad Request |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |
| **401** | Authorization Failure |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getholdings"></a>
# **GetHoldings**
> GetHoldingsResponse GetHoldings ()

Get Holdings

Fetches the holdings which the user has bought/sold in previous trading sessions.


### Parameters
This endpoint does not need any parameter.
### Return type

[**GetHoldingsResponse**](GetHoldingsResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | Bad Request |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |
| **401** | Authorization Failure |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getmtfpositions"></a>
# **GetMtfPositions**
> GetPositionResponse GetMtfPositions ()

Get MTF positions

This API allows you to get MTF positions.


### Parameters
This endpoint does not need any parameter.
### Return type

[**GetPositionResponse**](GetPositionResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | Bad Request |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |
| **401** | Authorization Failure |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getpositions"></a>
# **GetPositions**
> GetPositionResponse GetPositions ()

Get Positions

Fetches the current positions for the user for the current day.


### Parameters
This endpoint does not need any parameter.
### Return type

[**GetPositionResponse**](GetPositionResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | Bad Request |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |
| **401** | Authorization Failure |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

