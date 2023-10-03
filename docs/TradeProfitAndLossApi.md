# UpstoxClient.Api.TradeProfitAndLossApi

All URIs are relative to *https://api-v2.upstox.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetProfitAndLossCharges**](TradeProfitAndLossApi.md#getprofitandlosscharges) | **GET** /trade/profit-loss/charges | Get profit and loss on trades
[**GetTradeWiseProfitAndLossData**](TradeProfitAndLossApi.md#gettradewiseprofitandlossdata) | **GET** /trade/profit-loss/data | Get Trade-wise Profit and Loss Report Data
[**GetTradeWiseProfitAndLossMetaData**](TradeProfitAndLossApi.md#gettradewiseprofitandlossmetadata) | **GET** /trade/profit-loss/metadata | Get profit and loss meta data on trades

<a name="getprofitandlosscharges"></a>
# **GetProfitAndLossCharges**
> GetProfitAndLossChargesResponse GetProfitAndLossCharges (string segment, string financialYear, string apiVersion, string fromDate = null, string toDate = null)

Get profit and loss on trades

This API gives the charges incurred by users for their trades

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetProfitAndLossChargesExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TradeProfitAndLossApi();
            var segment = segment_example;  // string | Segment for which data is requested can be from the following options EQ - Equity,   FO - Futures and Options,   COM  - Commodity,   CD - Currency Derivatives
            var financialYear = financialYear_example;  // string | Financial year for which data has been requested. Concatenation of last 2 digits of from year and to year Sample:for 2021-2022, financial_year will be 2122
            var apiVersion = apiVersion_example;  // string | API Version Header
            var fromDate = fromDate_example;  // string | Date from which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format (optional) 
            var toDate = toDate_example;  // string | Date till which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format (optional) 

            try
            {
                // Get profit and loss on trades
                GetProfitAndLossChargesResponse result = apiInstance.GetProfitAndLossCharges(segment, financialYear, apiVersion, fromDate, toDate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TradeProfitAndLossApi.GetProfitAndLossCharges: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **segment** | **string**| Segment for which data is requested can be from the following options EQ - Equity,   FO - Futures and Options,   COM  - Commodity,   CD - Currency Derivatives | 
 **financialYear** | **string**| Financial year for which data has been requested. Concatenation of last 2 digits of from year and to year Sample:for 2021-2022, financial_year will be 2122 | 
 **apiVersion** | **string**| API Version Header | 
 **fromDate** | **string**| Date from which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format | [optional] 
 **toDate** | **string**| Date till which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format | [optional] 

### Return type

[**GetProfitAndLossChargesResponse**](GetProfitAndLossChargesResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettradewiseprofitandlossdata"></a>
# **GetTradeWiseProfitAndLossData**
> GetTradeWiseProfitAndLossDataResponse GetTradeWiseProfitAndLossData (string segment, string financialYear, int? pageNumber, int? pageSize, string apiVersion, string fromDate = null, string toDate = null)

Get Trade-wise Profit and Loss Report Data

This API gives the data of the realised Profit and Loss report requested by a user

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetTradeWiseProfitAndLossDataExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TradeProfitAndLossApi();
            var segment = segment_example;  // string | Segment for which data is requested can be from the following options EQ - Equity,   FO - Futures and Options,   COM  - Commodity,   CD - Currency Derivatives
            var financialYear = financialYear_example;  // string | Financial year for which data has been requested. Concatenation of last 2 digits of from year and to year Sample:for 2021-2022, financial_year will be 2122
            var pageNumber = 56;  // int? | Page Number, the pages are starting from 1
            var pageSize = 56;  // int? | Page size for pagination. The maximum page size value is obtained from P and L report metadata API.
            var apiVersion = apiVersion_example;  // string | API Version Header
            var fromDate = fromDate_example;  // string | Date from which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format (optional) 
            var toDate = toDate_example;  // string | Date till which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format (optional) 

            try
            {
                // Get Trade-wise Profit and Loss Report Data
                GetTradeWiseProfitAndLossDataResponse result = apiInstance.GetTradeWiseProfitAndLossData(segment, financialYear, pageNumber, pageSize, apiVersion, fromDate, toDate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TradeProfitAndLossApi.GetTradeWiseProfitAndLossData: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **segment** | **string**| Segment for which data is requested can be from the following options EQ - Equity,   FO - Futures and Options,   COM  - Commodity,   CD - Currency Derivatives | 
 **financialYear** | **string**| Financial year for which data has been requested. Concatenation of last 2 digits of from year and to year Sample:for 2021-2022, financial_year will be 2122 | 
 **pageNumber** | **int?**| Page Number, the pages are starting from 1 | 
 **pageSize** | **int?**| Page size for pagination. The maximum page size value is obtained from P and L report metadata API. | 
 **apiVersion** | **string**| API Version Header | 
 **fromDate** | **string**| Date from which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format | [optional] 
 **toDate** | **string**| Date till which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format | [optional] 

### Return type

[**GetTradeWiseProfitAndLossDataResponse**](GetTradeWiseProfitAndLossDataResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettradewiseprofitandlossmetadata"></a>
# **GetTradeWiseProfitAndLossMetaData**
> GetTradeWiseProfitAndLossMetaDataResponse GetTradeWiseProfitAndLossMetaData (string segment, string financialYear, string apiVersion, string fromDate = null, string toDate = null)

Get profit and loss meta data on trades

This API gives the data of the realised Profit and Loss report requested by a user

### Example
```csharp
using System;
using System.Diagnostics;
using UpstoxClient.Api;
using UpstoxClient.Client;
using UpstoxClient.Model;

namespace Example
{
    public class GetTradeWiseProfitAndLossMetaDataExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: OAUTH2
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TradeProfitAndLossApi();
            var segment = segment_example;  // string | Segment for which data is requested can be from the following options EQ - Equity,   FO - Futures and Options,   COM  - Commodity,   CD - Currency Derivatives
            var financialYear = financialYear_example;  // string | Financial year for which data has been requested. Concatenation of last 2 digits of from year and to year Sample:for 2021-2022, financial_year will be 2122
            var apiVersion = apiVersion_example;  // string | API Version Header
            var fromDate = fromDate_example;  // string | Date from which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format (optional) 
            var toDate = toDate_example;  // string | Date till which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format (optional) 

            try
            {
                // Get profit and loss meta data on trades
                GetTradeWiseProfitAndLossMetaDataResponse result = apiInstance.GetTradeWiseProfitAndLossMetaData(segment, financialYear, apiVersion, fromDate, toDate);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TradeProfitAndLossApi.GetTradeWiseProfitAndLossMetaData: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **segment** | **string**| Segment for which data is requested can be from the following options EQ - Equity,   FO - Futures and Options,   COM  - Commodity,   CD - Currency Derivatives | 
 **financialYear** | **string**| Financial year for which data has been requested. Concatenation of last 2 digits of from year and to year Sample:for 2021-2022, financial_year will be 2122 | 
 **apiVersion** | **string**| API Version Header | 
 **fromDate** | **string**| Date from which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format | [optional] 
 **toDate** | **string**| Date till which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format | [optional] 

### Return type

[**GetTradeWiseProfitAndLossMetaDataResponse**](GetTradeWiseProfitAndLossMetaDataResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
