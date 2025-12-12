# UpstoxClient.Api.OptionsApi

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetOptionContracts**](OptionsApi.md#getoptioncontracts) | **GET** /v2/option/contract | Get option contracts |
| [**GetPutCallOptionChain**](OptionsApi.md#getputcalloptionchain) | **GET** /v2/option/chain | Get option chain |

<a id="getoptioncontracts"></a>
# **GetOptionContracts**
> GetOptionContractResponse GetOptionContracts (string instrumentKey, string expiryDate = null)

Get option contracts

This API provides the functionality to retrieve the option contracts


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instrumentKey** | **string** | Instrument key for an underlying symbol |  |
| **expiryDate** | **string** | Expiry date in format: YYYY-mm-dd | [optional]  |

### Return type

[**GetOptionContractResponse**](GetOptionContractResponse.md)

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

<a id="getputcalloptionchain"></a>
# **GetPutCallOptionChain**
> GetOptionChainResponse GetPutCallOptionChain (string instrumentKey, string expiryDate)

Get option chain

This API provides the functionality to retrieve the option chain


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instrumentKey** | **string** | Instrument key for an underlying symbol |  |
| **expiryDate** | **string** | Expiry date in format: YYYY-mm-dd |  |

### Return type

[**GetOptionChainResponse**](GetOptionChainResponse.md)

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

