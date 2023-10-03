# UpstoxClient.Api.OrderApi

All URIs are relative to *https://api-v2.upstox.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CancelOrder**](OrderApi.md#cancelorder) | **DELETE** /order/cancel | Cancel order
[**GetOrderBook**](OrderApi.md#getorderbook) | **GET** /order/retrieve-all | Get order book
[**GetOrderDetails**](OrderApi.md#getorderdetails) | **GET** /order/history | Get order history
[**GetTradeHistory**](OrderApi.md#gettradehistory) | **GET** /order/trades/get-trades-for-day | Get trades
[**GetTradesByOrder**](OrderApi.md#gettradesbyorder) | **GET** /order/trades | Get trades for order
[**ModifyOrder**](OrderApi.md#modifyorder) | **PUT** /order/modify | Modify order
[**PlaceOrder**](OrderApi.md#placeorder) | **POST** /order/place | Place order

<a name="cancelorder"></a>
# **CancelOrder**
> CancelOrderResponse CancelOrder (string orderId, string apiVersion)

Cancel order

Cancel order API can be used for two purposes: Cancelling an open order which could be an AMO or a normal order It is also used to EXIT a CO or OCO(bracket order)

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class CancelOrderExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrderApi();
            var orderId = orderId_example;  // string | The order ID for which the order must be cancelled
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Cancel order
                CancelOrderResponse result = apiInstance.CancelOrder(orderId, apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OrderApi.CancelOrder: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **orderId** | **string**| The order ID for which the order must be cancelled | 
 **apiVersion** | **string**| API Version Header | 

### Return type

[**CancelOrderResponse**](CancelOrderResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getorderbook"></a>
# **GetOrderBook**
> GetOrderBookResponse GetOrderBook (string apiVersion)

Get order book

This API provides the list of orders placed by the user. The orders placed by the user is transient for a day and is cleared by the end of the trading session. This API returns all states of the orders, namely, open, pending, and filled ones.

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetOrderBookExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrderApi();
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Get order book
                GetOrderBookResponse result = apiInstance.GetOrderBook(apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OrderApi.GetOrderBook: " + e.Message );
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

[**GetOrderBookResponse**](GetOrderBookResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getorderdetails"></a>
# **GetOrderDetails**
> GetOrderResponse GetOrderDetails (string apiVersion, string orderId = null, string tag = null)

Get order history

This API provides the details of the particular order the user has placed. The orders placed by the user is transient for a day and are cleared by the end of the trading session. This API returns all states of the orders, namely, open, pending, and filled ones.  The order history can be requested either using order_id or tag.  If both the options are passed, the history of the order which precisely matches both the order_id and tag will be returned in the response.  If only the tag is passed, the history of all the associated orders which matches the tag will be shared in the response.

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetOrderDetailsExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrderApi();
            var apiVersion = apiVersion_example;  // string | API Version Header
            var orderId = orderId_example;  // string | The order reference ID for which the order history is required (optional) 
            var tag = tag_example;  // string | The unique tag of the order for which the order history is being requested (optional) 

            try
            {
                // Get order history
                GetOrderResponse result = apiInstance.GetOrderDetails(apiVersion, orderId, tag);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OrderApi.GetOrderDetails: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **apiVersion** | **string**| API Version Header | 
 **orderId** | **string**| The order reference ID for which the order history is required | [optional] 
 **tag** | **string**| The unique tag of the order for which the order history is being requested | [optional] 

### Return type

[**GetOrderResponse**](GetOrderResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettradehistory"></a>
# **GetTradeHistory**
> GetTradeResponse GetTradeHistory (string apiVersion)

Get trades

Retrieve the trades executed for the day

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetTradeHistoryExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrderApi();
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Get trades
                GetTradeResponse result = apiInstance.GetTradeHistory(apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OrderApi.GetTradeHistory: " + e.Message );
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

[**GetTradeResponse**](GetTradeResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettradesbyorder"></a>
# **GetTradesByOrder**
> GetTradeResponse GetTradesByOrder (string orderId, string apiVersion)

Get trades for order

Retrieve the trades executed for an order

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetTradesByOrderExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrderApi();
            var orderId = orderId_example;  // string | The order ID for which the order to get order trades
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Get trades for order
                GetTradeResponse result = apiInstance.GetTradesByOrder(orderId, apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OrderApi.GetTradesByOrder: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **orderId** | **string**| The order ID for which the order to get order trades | 
 **apiVersion** | **string**| API Version Header | 

### Return type

[**GetTradeResponse**](GetTradeResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="modifyorder"></a>
# **ModifyOrder**
> ModifyOrderResponse ModifyOrder (ModifyOrderRequest body, string apiVersion)

Modify order

This API allows you to modify an order. For modification orderId is mandatory. With orderId you need to send the optional parameter which needs to be modified. In case the optional parameters aren't sent, the default will be considered from the original order

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class ModifyOrderExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrderApi();
            var body = new ModifyOrderRequest(); // ModifyOrderRequest | 
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Modify order
                ModifyOrderResponse result = apiInstance.ModifyOrder(body, apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OrderApi.ModifyOrder: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**ModifyOrderRequest**](ModifyOrderRequest.md)|  | 
 **apiVersion** | **string**| API Version Header | 

### Return type

[**ModifyOrderResponse**](ModifyOrderResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="placeorder"></a>
# **PlaceOrder**
> PlaceOrderResponse PlaceOrder (PlaceOrderRequest body, string apiVersion)

Place order

This API allows you to place an order to the exchange via Upstox.

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class PlaceOrderExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new OrderApi();
            var body = new PlaceOrderRequest(); // PlaceOrderRequest | 
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Place order
                PlaceOrderResponse result = apiInstance.PlaceOrder(body, apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling OrderApi.PlaceOrder: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**PlaceOrderRequest**](PlaceOrderRequest.md)|  | 
 **apiVersion** | **string**| API Version Header | 

### Return type

[**PlaceOrderResponse**](PlaceOrderResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*, application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
