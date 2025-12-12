# UpstoxClient.Api.ChargeApi

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetBrokerage**](ChargeApi.md#getbrokerage) | **GET** /v2/charges/brokerage | Brokerage details |
| [**PostMargin**](ChargeApi.md#postmargin) | **POST** /v2/charges/margin | Calculate Margin |

<a id="getbrokerage"></a>
# **GetBrokerage**
> GetBrokerageResponse GetBrokerage (string instrumentToken, int quantity, string product, string transactionType, float price)

Brokerage details

Compute Brokerage Charges


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **instrumentToken** | **string** | Key of the instrument |  |
| **quantity** | **int** | Quantity with which the order is to be placed |  |
| **product** | **string** | Product with which the order is to be placed |  |
| **transactionType** | **string** | Indicates whether its a BUY or SELL order |  |
| **price** | **float** | Price with which the order is to be placed |  |

### Return type

[**GetBrokerageResponse**](GetBrokerageResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1060 - The quantity is required&lt;br&gt;UDAPI1061 - The price is required&lt;br&gt;UDAPI1062 - The transaction_type is required&lt;br&gt; UDAPI1063 - The product is required&lt;br&gt; UDAPI1064 - The quantity cannot be zero&lt;br&gt;UDAPI1065 - The price cannot be zero&lt;br&gt;UDAPI1059 - The instrument_token is of invalid format |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="postmargin"></a>
# **PostMargin**
> PostMarginResponse PostMargin (MarginRequest marginRequest)

Calculate Margin

Compute Margin


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **marginRequest** | [**MarginRequest**](MarginRequest.md) |  |  |

### Return type

[**PostMarginResponse**](PostMarginResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1095 - The price must be greater than zero&lt;br&gt;UDAPI1096 - Quantity cannot be less than or equal to zero&lt;br&gt;UDAPI1097 - The quantity is required&lt;br&gt;UDAPI1098 - The instrument_token is of invalid format&lt;br&gt;UDAPI1099 - The instrument key is required&lt;br&gt;UDAPI1100 - The product is required&lt;br&gt;UDAPI1101 - The transaction_type is required&lt;br&gt;UDAPI1102 - The instrument limit has been exceeded&lt;br&gt;UDAPI1103 - Instrument key cannot be duplicated&lt;br&gt;UDAPI1104 - Quantity should be multiple of lot size |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

