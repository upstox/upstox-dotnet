# UpstoxClient.Api.WebsocketApi

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AuthorizeMarketDataFeed**](WebsocketApi.md#authorizemarketdatafeed) | **GET** /v2/feed/market-data-feed/authorize |  |
| [**GetPortfolioStreamFeed**](WebsocketApi.md#getportfoliostreamfeed) | **GET** /v2/feed/portfolio-stream-feed | Portfolio Stream Feed |
| [**GetPortfolioStreamFeedAuthorize**](WebsocketApi.md#getportfoliostreamfeedauthorize) | **GET** /v2/feed/portfolio-stream-feed/authorize | Portfolio Stream Feed Authorize |
| [**HandleMarketDataFeedRedirect**](WebsocketApi.md#handlemarketdatafeedredirect) | **GET** /v2/feed/market-data-feed |  |

<a id="authorizemarketdatafeed"></a>
# **AuthorizeMarketDataFeed**
> WebsocketAuthRedirectResponse AuthorizeMarketDataFeed ()




### Parameters
This endpoint does not need any parameter.
### Return type

[**WebsocketAuthRedirectResponse**](WebsocketAuthRedirectResponse.md)

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

<a id="getportfoliostreamfeed"></a>
# **GetPortfolioStreamFeed**
> void GetPortfolioStreamFeed (string updateTypes = null)

Portfolio Stream Feed

This API redirects the client to the respective socket endpoint to receive Portfolio updates.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **updateTypes** | **string** | Identifiers separated by commas denote the types of updates to receive. | [optional]  |

### Return type

void (empty response body)

### Authorization

[OAUTH2](../README.md#OAUTH2)

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
| **302** | Location for authorized access of portfolio stream feed |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getportfoliostreamfeedauthorize"></a>
# **GetPortfolioStreamFeedAuthorize**
> WebsocketAuthRedirectResponse GetPortfolioStreamFeedAuthorize (string updateTypes = null)

Portfolio Stream Feed Authorize

 This API provides the functionality to retrieve the socket endpoint URI for Portfolio updates.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **updateTypes** | **string** | Identifiers separated by commas denote the types of updates to receive. | [optional]  |

### Return type

[**WebsocketAuthRedirectResponse**](WebsocketAuthRedirectResponse.md)

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

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="handlemarketdatafeedredirect"></a>
# **HandleMarketDataFeedRedirect**
> void HandleMarketDataFeedRedirect ()




### Parameters
This endpoint does not need any parameter.
### Return type

void (empty response body)

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

