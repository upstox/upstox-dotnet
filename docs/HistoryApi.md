# UpstoxClient.Api.HistoryApi

All URIs are relative to *https://api-v2.upstox.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetHistoricalCandleData**](HistoryApi.md#gethistoricalcandledata) | **GET** /historical-candle/{instrumentKey}/{interval}/{to_date} | Historical candle data
[**GetHistoricalCandleData1**](HistoryApi.md#gethistoricalcandledata1) | **GET** /historical-candle/{instrumentKey}/{interval}/{to_date}/{from_date} | Historical candle data
[**GetIntraDayCandleData**](HistoryApi.md#getintradaycandledata) | **GET** /historical-candle/intraday/{instrumentKey}/{interval} | Intra day candle data

<a name="gethistoricalcandledata"></a>
# **GetHistoricalCandleData**
> GetHistoricalCandleResponse GetHistoricalCandleData (string instrumentKey, string interval, string toDate, string apiVersion)

Historical candle data

Get OHLC values for all instruments across various timeframes. Historical data can be fetched for the following durations. 1minute: last 1 month candles till endDate 30minute: last 1 year candles till endDate day: last 1 year candles till endDate week: last 10 year candles till endDate month: last 10 year candles till endDate

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetHistoricalCandleDataExample
    {
        public void main()
        {
            var apiInstance = new HistoryApi();
            var instrumentKey = instrumentKey_example;  // string | 
            var interval = interval_example;  // string | 
            var toDate = toDate_example;  // string | 
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Historical candle data
                GetHistoricalCandleResponse result = apiInstance.GetHistoricalCandleData(instrumentKey, interval, toDate, apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling HistoryApi.GetHistoricalCandleData: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **instrumentKey** | **string**|  | 
 **interval** | **string**|  | 
 **toDate** | **string**|  | 
 **apiVersion** | **string**| API Version Header | 

### Return type

[**GetHistoricalCandleResponse**](GetHistoricalCandleResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gethistoricalcandledata1"></a>
# **GetHistoricalCandleData1**
> GetHistoricalCandleResponse GetHistoricalCandleData1 (string instrumentKey, string interval, string toDate, string fromDate, string apiVersion)

Historical candle data

Get OHLC values for all instruments across various timeframes. Historical data can be fetched for the following durations. 1minute: last 1 month candles till endDate 30minute: last 1 year candles till endDate day: last 1 year candles till endDate week: last 10 year candles till endDate month: last 10 year candles till endDate

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetHistoricalCandleData1Example
    {
        public void main()
        {
            var apiInstance = new HistoryApi();
            var instrumentKey = instrumentKey_example;  // string | 
            var interval = interval_example;  // string | 
            var toDate = toDate_example;  // string | 
            var fromDate = fromDate_example;  // string | 
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Historical candle data
                GetHistoricalCandleResponse result = apiInstance.GetHistoricalCandleData1(instrumentKey, interval, toDate, fromDate, apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling HistoryApi.GetHistoricalCandleData1: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **instrumentKey** | **string**|  | 
 **interval** | **string**|  | 
 **toDate** | **string**|  | 
 **fromDate** | **string**|  | 
 **apiVersion** | **string**| API Version Header | 

### Return type

[**GetHistoricalCandleResponse**](GetHistoricalCandleResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getintradaycandledata"></a>
# **GetIntraDayCandleData**
> GetIntraDayCandleResponse GetIntraDayCandleData (string instrumentKey, string interval, string apiVersion)

Intra day candle data

Get OHLC values for all instruments for the present trading day

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetIntraDayCandleDataExample
    {
        public void main()
        {
            var apiInstance = new HistoryApi();
            var instrumentKey = instrumentKey_example;  // string | 
            var interval = interval_example;  // string | 
            var apiVersion = apiVersion_example;  // string | API Version Header

            try
            {
                // Intra day candle data
                GetIntraDayCandleResponse result = apiInstance.GetIntraDayCandleData(instrumentKey, interval, apiVersion);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling HistoryApi.GetIntraDayCandleData: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **instrumentKey** | **string**|  | 
 **interval** | **string**|  | 
 **apiVersion** | **string**| API Version Header | 

### Return type

[**GetIntraDayCandleResponse**](GetIntraDayCandleResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
