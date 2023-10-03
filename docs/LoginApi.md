# UpstoxClient.Api.LoginApi

All URIs are relative to *https://api-v2.upstox.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Authorize**](LoginApi.md#authorize) | **GET** /login/authorization/dialog | Authorize API
[**Logout**](LoginApi.md#logout) | **DELETE** /logout | Logout
[**Token**](LoginApi.md#token) | **POST** /login/authorization/token | Get token API

<a name="authorize"></a>
# **Authorize**
> void Authorize (string clientId, string redirectUri, string apiVersion, string state = null, string scope = null)

Authorize API

This provides details on the login endpoint.

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class AuthorizeExample
    {
        public void main()
        {
            var apiInstance = new LoginApi();
            var clientId = clientId_example;  // string | 
            var redirectUri = redirectUri_example;  // string | 
            var apiVersion = apiVersion_example;  // string | API Version Header
            var state = state_example;  // string |  (optional) 
            var scope = scope_example;  // string |  (optional) 

            try
            {
                // Authorize API
                apiInstance.Authorize(clientId, redirectUri, apiVersion, state, scope);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LoginApi.Authorize: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientId** | **string**|  | 
 **redirectUri** | **string**|  | 
 **apiVersion** | **string**| API Version Header | 
 **state** | **string**|  | [optional] 
 **scope** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="logout"></a>
# **Logout**
> LogoutResponse Logout (string apiVersion)

Logout

Logout

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class LogoutExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new LoginApi();
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Logout
                LogoutResponse result = apiInstance.Logout(apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LoginApi.Logout: " + e.Message );
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

[**LogoutResponse**](LogoutResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="token"></a>
# **Token**
> TokenResponse Token (string apiVersion, string code = null, string clientId = null, string clientSecret = null, string redirectUri = null, string grantType = null)

Get token API

This API provides the functionality to obtain opaque token from authorization_code exchange and also provides the user’s profile in the same response.

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class TokenExample
    {
        public void main()
        {
            var apiInstance = new LoginApi();
            var apiVersion = apiVersion_example;  // string | API Version Header
            var code = code_example;  // string |  (optional) 
            var clientId = clientId_example;  // string |  (optional) 
            var clientSecret = clientSecret_example;  // string |  (optional) 
            var redirectUri = redirectUri_example;  // string |  (optional) 
            var grantType = grantType_example;  // string |  (optional) 

            try
            {
                // Get token API
                TokenResponse result = apiInstance.Token(apiVersion, code, clientId, clientSecret, redirectUri, grantType);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling LoginApi.Token: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **apiVersion** | **string**| API Version Header | 
 **code** | **string**|  | [optional] 
 **clientId** | **string**|  | [optional] 
 **clientSecret** | **string**|  | [optional] 
 **redirectUri** | **string**|  | [optional] 
 **grantType** | **string**|  | [optional] 

### Return type

[**TokenResponse**](TokenResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
