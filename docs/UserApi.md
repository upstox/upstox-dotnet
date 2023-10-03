# UpstoxClient.Api.UserApi

All URIs are relative to *https://api-v2.upstox.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetProfile**](UserApi.md#getprofile) | **GET** /user/profile | Get profile
[**GetUserFundMargin**](UserApi.md#getuserfundmargin) | **GET** /user/get-funds-and-margin | Get User Fund And Margin

<a name="getprofile"></a>
# **GetProfile**
> GetProfileResponse GetProfile (string apiVersion)

Get profile

This API allows to fetch the complete information of the user who is logged in including the products, order types and exchanges enabled for the user

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetProfileExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi();
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Get profile
                GetProfileResponse result = apiInstance.GetProfile(apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.GetProfile: " + e.Message );
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

[**GetProfileResponse**](GetProfileResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getuserfundmargin"></a>
# **GetUserFundMargin**
> GetUserFundMarginResponse GetUserFundMargin (string apiVersion, string segment = null)

Get User Fund And Margin

Shows the balance of the user in equity and commodity market.

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetUserFundMarginExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new UserApi();
            var apiVersion = apiVersion_example;  // string | API Version Header
            var segment = segment_example;  // string |  (optional) 

            try
            {
                // Get User Fund And Margin
                GetUserFundMarginResponse result = apiInstance.GetUserFundMargin(apiVersion, segment);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.GetUserFundMargin: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **apiVersion** | **string**| API Version Header | 
 **segment** | **string**|  | [optional] 

### Return type

[**GetUserFundMarginResponse**](GetUserFundMarginResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
