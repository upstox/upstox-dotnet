# UpstoxClient.Api.UserApi

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetProfile**](UserApi.md#getprofile) | **GET** /v2/user/profile | Get profile |
| [**GetUserFundMargin**](UserApi.md#getuserfundmargin) | **GET** /v2/user/get-funds-and-margin | Get User Fund And Margin |

<a id="getprofile"></a>
# **GetProfile**
> GetProfileResponse GetProfile ()

Get profile

This API allows to fetch the complete information of the user who is logged in including the products, order types and exchanges enabled for the user


### Parameters
This endpoint does not need any parameter.
### Return type

[**GetProfileResponse**](GetProfileResponse.md)

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

<a id="getuserfundmargin"></a>
# **GetUserFundMargin**
> GetUserFundMarginResponse GetUserFundMargin (string segment = null)

Get User Fund And Margin

Shows the balance of the user in equity and commodity market.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **segment** | **string** |  | [optional]  |

### Return type

[**GetUserFundMarginResponse**](GetUserFundMarginResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1019 - segment is invalid |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

