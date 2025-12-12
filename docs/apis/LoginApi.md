# UpstoxClient.Api.LoginApi

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**Authorize**](LoginApi.md#authorize) | **GET** /v2/login/authorization/dialog | Authorize API |
| [**InitTokenRequestForIndieUser**](LoginApi.md#inittokenrequestforindieuser) | **POST** /v3/login/auth/token/request/{client_id} | Init token API |
| [**Logout**](LoginApi.md#logout) | **DELETE** /v2/logout | Logout |
| [**Token**](LoginApi.md#token) | **POST** /v2/login/authorization/token | Get token API |

<a id="authorize"></a>
# **Authorize**
> void Authorize (string clientId, string redirectUri, string state = null, string scope = null)

Authorize API

This provides details on the login endpoint.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **clientId** | **string** |  |  |
| **redirectUri** | **string** |  |  |
| **state** | **string** |  | [optional]  |
| **scope** | **string** |  | [optional]  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1018 - Redirect URI is required |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **302** | Successful Operation |  -  |
| **401** | Unauthorized |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="inittokenrequestforindieuser"></a>
# **InitTokenRequestForIndieUser**
> IndieUserInitTokenResponse InitTokenRequestForIndieUser (IndieUserTokenRequest indieUserTokenRequest, string clientId)

Init token API

This API provides the initialize the generate token and it's expiry for an indie user


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **indieUserTokenRequest** | [**IndieUserTokenRequest**](IndieUserTokenRequest.md) |  |  |
| **clientId** | **string** |  |  |

### Return type

[**IndieUserInitTokenResponse**](IndieUserInitTokenResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1017 - API Key is required &lt;br/&gt;UDAPI1024 - App Secret is required &lt;br/&gt; |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |
| **401** | Unauthorized |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="logout"></a>
# **Logout**
> LogoutResponse Logout ()

Logout

Logout


### Parameters
This endpoint does not need any parameter.
### Return type

[**LogoutResponse**](LogoutResponse.md)

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

<a id="token"></a>
# **Token**
> TokenResponse Token (string code, string clientId, string clientSecret, string redirectUri, string grantType)

Get token API

This API provides the functionality to obtain opaque token from authorization_code exchange and also provides the user’s profile in the same response.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **code** | **string** |  |  |
| **clientId** | **string** | OAuth API key that is a public identifier for app |  |
| **clientSecret** | **string** | OAuth client secret that is a private secret known only to app and authorization server |  |
| **redirectUri** | **string** | Authorization server will redirect the user back to the application via redirect url |  |
| **grantType** | **string** | Type of grant used to get an access token |  |

### Return type

[**TokenResponse**](TokenResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1017 - API Key is required &lt;br/&gt;UDAPI1018 - Redirect URI is required &lt;br/&gt;UDAPI1022 - Code is required &lt;br/&gt;UDAPI1023 - Grant type is required &lt;br/&gt;UDAPI1024 - App Secret is required &lt;br/&gt; |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |
| **401** | Unauthorized |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

