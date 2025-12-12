# UpstoxClient.Api.OrderApi

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CancelMultiOrder**](OrderApi.md#cancelmultiorder) | **DELETE** /v2/order/multi/cancel | Cancel multi order |
| [**ExitPositions**](OrderApi.md#exitpositions) | **POST** /v2/order/positions/exit | Exit all positions |
| [**GetOrderBook**](OrderApi.md#getorderbook) | **GET** /v2/order/retrieve-all | Get order book |
| [**GetOrderDetails**](OrderApi.md#getorderdetails) | **GET** /v2/order/history | Get order history |
| [**GetOrderStatus**](OrderApi.md#getorderstatus) | **GET** /v2/order/details | Get order details |
| [**GetTradeHistory**](OrderApi.md#gettradehistory) | **GET** /v2/order/trades/get-trades-for-day | Get trades |
| [**GetTradesByOrder**](OrderApi.md#gettradesbyorder) | **GET** /v2/order/trades | Get trades for order |
| [**PlaceMultiOrder**](OrderApi.md#placemultiorder) | **POST** /v2/order/multi/place | Place multi order |

<a id="cancelmultiorder"></a>
# **CancelMultiOrder**
> CancelOrExitMultiOrderResponse CancelMultiOrder (string tag = null, string segment = null)

Cancel multi order

API to cancel all the open or pending orders which can be applied to both AMO and regular orders.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **tag** | **string** | The tag associated with the orders for which the orders must be cancelled | [optional]  |
| **segment** | **string** | The segment for which the orders must be cancelled | [optional]  |

### Return type

[**CancelOrExitMultiOrderResponse**](CancelOrExitMultiOrderResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1105 - Invalid segment&lt;br&gt;UDAPI1108 - No open or pending order available&lt;br&gt;UDAPI1109 - Available open or pending orders should not be more than limit |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)










<a id="exitpositions"></a>
# **ExitPositions**
> CancelOrExitMultiOrderResponse ExitPositions (string tag = null, string segment = null)

Exit all positions

This API provides the functionality to exit all the positions 


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **tag** | **string** | The tag associated with the positions for which the positions must be exit | [optional]  |
| **segment** | **string** | The segment for which the positions must be exit | [optional]  |

### Return type

[**CancelOrExitMultiOrderResponse**](CancelOrExitMultiOrderResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1105 - Invalid segment. &lt;br&gt;UDAPI1108 - No open position available to exit.&lt;br&gt;UDAPI1109 - Available open positions should not be more than limit. |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getorderbook"></a>
# **GetOrderBook**
> GetOrderBookResponse GetOrderBook ()

Get order book

This API provides the list of orders placed by the user. The orders placed by the user is transient for a day and is cleared by the end of the trading session. This API returns all states of the orders, namely, open, pending, and filled ones.


### Parameters
This endpoint does not need any parameter.
### Return type

[**GetOrderBookResponse**](GetOrderBookResponse.md)

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

<a id="getorderdetails"></a>
# **GetOrderDetails**
> GetOrderResponse GetOrderDetails (string orderId = null, string tag = null)

Get order history

This API provides the details of the particular order the user has placed. The orders placed by the user is transient for a day and are cleared by the end of the trading session. This API returns all states of the orders, namely, open, pending, and filled ones.  The order history can be requested either using order_id or tag.  If both the options are passed, the history of the order which precisely matches both the order_id and tag will be returned in the response.  If only the tag is passed, the history of all the associated orders which matches the tag will be shared in the response.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **orderId** | **string** | The order reference ID for which the order history is required | [optional]  |
| **tag** | **string** | The unique tag of the order for which the order history is being requested | [optional]  |

### Return type

[**GetOrderResponse**](GetOrderResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1010 - Order id accepts only alphanumeric characters and &#39;-&#39;&lt;br&gt;UDAPI1023 - Order id is required&lt;br&gt;UDAPI100010 - Unknown order id | order request rejected |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getorderstatus"></a>
# **GetOrderStatus**
> GetOrderDetailsResponse GetOrderStatus (string orderId = null)

Get order details

This API provides the recent detail of the particular order the user has placed. The orders placed by the user is transient for a day and are cleared by the end of the trading session.\\n\\nThe order details can be requested using order_id.  


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **orderId** | **string** | The order reference ID for which the order details is required | [optional]  |

### Return type

[**GetOrderDetailsResponse**](GetOrderDetailsResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1010 - Order id accepts only alphanumeric characters and &#39;-&#39;&lt;br&gt;UDAPI1023 - Order id is required&lt;br&gt;UDAPI100010 - Unknown order id | order request rejected |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="gettradehistory"></a>
# **GetTradeHistory**
> GetTradeResponse GetTradeHistory ()

Get trades

Retrieve the trades executed for the day


### Parameters
This endpoint does not need any parameter.
### Return type

[**GetTradeResponse**](GetTradeResponse.md)

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

<a id="gettradesbyorder"></a>
# **GetTradesByOrder**
> GetTradeResponse GetTradesByOrder (string orderId)

Get trades for order

Retrieve the trades executed for an order


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **orderId** | **string** | The order ID for which the order to get order trades |  |

### Return type

[**GetTradeResponse**](GetTradeResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1010 - Order id accepts only alphanumeric characters and &#39;-&#39;.&lt;br&gt;UDAPI1023 - Order id is required&lt;br&gt;UDAPI100010 - Unknown order id | order request rejected |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

> MultiOrderResponse PlaceMultiOrder (List<MultiOrderRequest> multiOrderRequest, string origin = null)

Place multi order

This API allows you to place multiple orders to the exchange via Upstox.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **multiOrderRequest** | [**List&lt;MultiOrderRequest&gt;**](MultiOrderRequest.md) |  |  |
| **origin** | **string** |  | [optional]  |

### Return type

[**MultiOrderResponse**](MultiOrderResponse.md)

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

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="placeorder1"></a>

