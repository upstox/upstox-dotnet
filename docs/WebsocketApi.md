# UpstoxClient.Api.WebsocketApi

All URIs are relative to *https://api-v2.upstox.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetMarketDataFeed**](WebsocketApi.md#getmarketdatafeed) | **GET** /feed/market-data-feed | Market Data Feed
[**GetMarketDataFeedAuthorize**](WebsocketApi.md#getmarketdatafeedauthorize) | **GET** /feed/market-data-feed/authorize | Market Data Feed Authorize
[**GetPortfolioStreamFeed**](WebsocketApi.md#getportfoliostreamfeed) | **GET** /feed/portfolio-stream-feed | Portfolio Stream Feed
[**GetPortfolioStreamFeedAuthorize**](WebsocketApi.md#getportfoliostreamfeedauthorize) | **GET** /feed/portfolio-stream-feed/authorize | Portfolio Stream Feed Authorize

<a name="getmarketdatafeed"></a>
# **GetMarketDataFeed**
> void GetMarketDataFeed (string apiVersion)

Market Data Feed

 This API redirects the client to the respective socket endpoint to receive Market updates.

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetMarketDataFeedExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebsocketApi();
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Market Data Feed
                apiInstance.GetMarketDataFeed(apiVersion);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebsocketApi.GetMarketDataFeed: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **apiVersion** | **string**| API Version Header | 

### Return type

void (empty response body)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getmarketdatafeedauthorize"></a>
# **GetMarketDataFeedAuthorize**
> WebsocketAuthRedirectResponse GetMarketDataFeedAuthorize (string apiVersion)

Market Data Feed Authorize

This API provides the functionality to retrieve the socket endpoint URI for Market updates.

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetMarketDataFeedAuthorizeExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebsocketApi();
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Market Data Feed Authorize
                WebsocketAuthRedirectResponse result = apiInstance.GetMarketDataFeedAuthorize(apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebsocketApi.GetMarketDataFeedAuthorize: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **apiVersion** | **string**| API Version Header | 

### Return type

[**WebsocketAuthRedirectResponse**](WebsocketAuthRedirectResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getportfoliostreamfeed"></a>
# **GetPortfolioStreamFeed**
> void GetPortfolioStreamFeed (string apiVersion)

Portfolio Stream Feed

This API redirects the client to the respective socket endpoint to receive Portfolio updates.

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetPortfolioStreamFeedExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebsocketApi();
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Portfolio Stream Feed
                apiInstance.GetPortfolioStreamFeed(apiVersion);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebsocketApi.GetPortfolioStreamFeed: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **apiVersion** | **string**| API Version Header | 

### Return type

void (empty response body)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getportfoliostreamfeedauthorize"></a>
# **GetPortfolioStreamFeedAuthorize**
> WebsocketAuthRedirectResponse GetPortfolioStreamFeedAuthorize (string apiVersion)

Portfolio Stream Feed Authorize

 This API provides the functionality to retrieve the socket endpoint URI for Portfolio updates.

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetPortfolioStreamFeedAuthorizeExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new WebsocketApi();
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Portfolio Stream Feed Authorize
                WebsocketAuthRedirectResponse result = apiInstance.GetPortfolioStreamFeedAuthorize(apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebsocketApi.GetPortfolioStreamFeedAuthorize: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **apiVersion** | **string**| API Version Header | 

### Return type

[**WebsocketAuthRedirectResponse**](WebsocketAuthRedirectResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
