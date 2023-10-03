# UpstoxClient.Api.ChargeApi

All URIs are relative to *https://api-v2.upstox.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetBrokerage**](ChargeApi.md#getbrokerage) | **GET** /charges/brokerage | Brokerage details

<a name="getbrokerage"></a>
# **GetBrokerage**
> GetBrokerageResponse GetBrokerage (string instrumentToken, int? quantity, string product, string transactionType, float? price, string apiVersion)

Brokerage details

Compute Brokerage Charges

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetBrokerageExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ChargeApi();
            var instrumentToken = instrumentToken_example;  // string | Key of the instrument
            var quantity = 56;  // int? | Quantity with which the order is to be placed
            var product = product_example;  // string | Product with which the order is to be placed
            var transactionType = transactionType_example;  // string | Indicates whether its a BUY or SELL order
            var price = 3.4;  // float? | Price with which the order is to be placed
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Brokerage details
                GetBrokerageResponse result = apiInstance.GetBrokerage(instrumentToken, quantity, product, transactionType, price, apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChargeApi.GetBrokerage: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **instrumentToken** | **string**| Key of the instrument | 
 **quantity** | **int?**| Quantity with which the order is to be placed | 
 **product** | **string**| Product with which the order is to be placed | 
 **transactionType** | **string**| Indicates whether its a BUY or SELL order | 
 **price** | **float?**| Price with which the order is to be placed | 
 **apiVersion** | **string**| API Version Header | 

### Return type

[**GetBrokerageResponse**](GetBrokerageResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
