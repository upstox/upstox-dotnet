# UpstoxClient.Api.PortfolioApi

All URIs are relative to *https://api-v2.upstox.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ConvertPositions**](PortfolioApi.md#convertpositions) | **PUT** /portfolio/convert-position | Convert Positions
[**GetHoldings**](PortfolioApi.md#getholdings) | **GET** /portfolio/long-term-holdings | Get Holdings
[**GetPositions**](PortfolioApi.md#getpositions) | **GET** /portfolio/short-term-positions | Get Positions

<a name="convertpositions"></a>
# **ConvertPositions**
> ConvertPositionResponse ConvertPositions (ConvertPositionRequest body, string apiVersion)

Convert Positions

Convert the margin product of an open position

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class ConvertPositionsExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PortfolioApi();
            var body = new ConvertPositionRequest(); // ConvertPositionRequest | 
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Convert Positions
                ConvertPositionResponse result = apiInstance.ConvertPositions(body, apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PortfolioApi.ConvertPositions: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**ConvertPositionRequest**](ConvertPositionRequest.md)|  | 
 **apiVersion** | **string**| API Version Header | 

### Return type

[**ConvertPositionResponse**](ConvertPositionResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getholdings"></a>
# **GetHoldings**
> GetHoldingsResponse GetHoldings (string apiVersion)

Get Holdings

Fetches the holdings which the user has bought/sold in previous trading sessions.

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetHoldingsExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PortfolioApi();
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Get Holdings
                GetHoldingsResponse result = apiInstance.GetHoldings(apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PortfolioApi.GetHoldings: " + e.Message );
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

[**GetHoldingsResponse**](GetHoldingsResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getpositions"></a>
# **GetPositions**
> GetPositionResponse GetPositions (string apiVersion)

Get Positions

Fetches the current positions for the user for the current day.

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetPositionsExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new PortfolioApi();
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Get Positions
                GetPositionResponse result = apiInstance.GetPositions(apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PortfolioApi.GetPositions: " + e.Message );
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

[**GetPositionResponse**](GetPositionResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
