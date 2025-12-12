# UpstoxClient.Api.OrderV3Api

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CancelGTTOrder**](OrderV3Api.md#cancelgttorder) | **DELETE** /v3/order/gtt/cancel | Cancel GTT order |
| [**CancelOrder**](OrderV3Api.md#cancelorder) | **DELETE** /v3/order/cancel |  |
| [**GetGttOrderDetails**](OrderV3Api.md#getgttorderdetails) | **GET** /v3/order/gtt | Get GTT order details |
| [**ModifyGTTOrder**](OrderV3Api.md#modifygttorder) | **PUT** /v3/order/gtt/modify | Modify GTT order |
| [**ModifyOrder**](OrderV3Api.md#modifyorder) | **PUT** /v3/order/modify |  |
| [**PlaceGTTOrder**](OrderV3Api.md#placegttorder) | **POST** /v3/order/gtt/place | Place GTT order |
| [**PlaceOrder**](OrderV3Api.md#placeorder) | **POST** /v3/order/place |  |

<a id="cancelgttorder"></a>
# **CancelGTTOrder**
> GttTriggerOrderResponse CancelGTTOrder (GttCancelOrderRequest gttCancelOrderRequest, string origin = null)

Cancel GTT order

This API allows you to cancel GTT orders.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **gttCancelOrderRequest** | [**GttCancelOrderRequest**](GttCancelOrderRequest.md) |  |  |
| **origin** | **string** |  | [optional]  |

### Return type

[**GttTriggerOrderResponse**](GttTriggerOrderResponse.md)

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

<a id="cancelorder"></a>
# **CancelOrder**
> CancelOrderV3Response CancelOrder (string orderId)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **orderId** | **string** |  |  |

### Return type

[**CancelOrderV3Response**](CancelOrderV3Response.md)

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
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getgttorderdetails"></a>
# **GetGttOrderDetails**
> GetGttOrderResponse GetGttOrderDetails (string gttOrderId = null)

Get GTT order details

GTT_ORDER_DESCRIPTION


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **gttOrderId** | **string** | Unique identifier of the GTT order for which the order history is required | [optional]  |

### Return type

[**GetGttOrderResponse**](GetGttOrderResponse.md)

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

<a id="modifygttorder"></a>
# **ModifyGTTOrder**
> GttTriggerOrderResponse ModifyGTTOrder (GttModifyOrderRequest gttModifyOrderRequest, string origin = null)

Modify GTT order

This API allows you to modify GTT orders.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **gttModifyOrderRequest** | [**GttModifyOrderRequest**](GttModifyOrderRequest.md) |  |  |
| **origin** | **string** |  | [optional]  |

### Return type

[**GttTriggerOrderResponse**](GttTriggerOrderResponse.md)

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

<a id="modifyorder"></a>
# **ModifyOrder**
> ModifyOrderV3Response ModifyOrder (ModifyOrderRequest modifyOrderRequest)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **modifyOrderRequest** | [**ModifyOrderRequest**](ModifyOrderRequest.md) |  |  |

### Return type

[**ModifyOrderV3Response**](ModifyOrderV3Response.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: application/json
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

<a id="placegttorder"></a>
# **PlaceGTTOrder**
> GttTriggerOrderResponse PlaceGTTOrder (GttPlaceOrderRequest gttPlaceOrderRequest, string origin = null)

Place GTT order

This API allows you to place GTT orders.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **gttPlaceOrderRequest** | [**GttPlaceOrderRequest**](GttPlaceOrderRequest.md) |  |  |
| **origin** | **string** |  | [optional]  |

### Return type

[**GttTriggerOrderResponse**](GttTriggerOrderResponse.md)

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

<a id="placeorder"></a>
# **PlaceOrder**
> PlaceOrderV3Response PlaceOrder (PlaceOrderV3Request placeOrderV3Request)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **placeOrderV3Request** | [**PlaceOrderV3Request**](PlaceOrderV3Request.md) |  |  |

### Return type

[**PlaceOrderV3Response**](PlaceOrderV3Response.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: application/json
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

