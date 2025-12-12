# UpstoxClient.Api.TradeProfitAndLossApi

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetProfitAndLossCharges**](TradeProfitAndLossApi.md#getprofitandlosscharges) | **GET** /v2/trade/profit-loss/charges | Get profit and loss on trades |
| [**GetTradeWiseProfitAndLossData**](TradeProfitAndLossApi.md#gettradewiseprofitandlossdata) | **GET** /v2/trade/profit-loss/data | Get Trade-wise Profit and Loss Report Data |
| [**GetTradeWiseProfitAndLossMetaData**](TradeProfitAndLossApi.md#gettradewiseprofitandlossmetadata) | **GET** /v2/trade/profit-loss/metadata | Get profit and loss meta data on trades |

<a id="getprofitandlosscharges"></a>
# **GetProfitAndLossCharges**
> GetProfitAndLossChargesResponse GetProfitAndLossCharges (string segment, string financialYear, string fromDate = null, string toDate = null)

Get profit and loss on trades

This API gives the charges incurred by users for their trades


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **segment** | **string** | Segment for which data is requested can be from the following options EQ - Equity,   FO - Futures and Options,   COM  - Commodity,   CD - Currency Derivatives |  |
| **financialYear** | **string** | Financial year for which data has been requested. Concatenation of last 2 digits of from year and to year Sample:for 2021-2022, financial_year will be 2122 |  |
| **fromDate** | **string** | Date from which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format | [optional]  |
| **toDate** | **string** | Date till which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format | [optional]  |

### Return type

[**GetProfitAndLossChargesResponse**](GetProfitAndLossChargesResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1067 - The &#39;&#39;segment&#39;&#39; is required&lt;br&gt;UDAPI1066 - The &#39;&#39;segment&#39;&#39; is invalid&lt;br&gt;UDAPI1068 - The start_date is required&lt;br&gt;UDAPI1069 - The end_date is required&lt;br&gt;UDAPI1105 - The provided dates do not fall within the specified financial year |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="gettradewiseprofitandlossdata"></a>
# **GetTradeWiseProfitAndLossData**
> GetTradeWiseProfitAndLossDataResponse GetTradeWiseProfitAndLossData (string segment, string financialYear, int pageNumber, int pageSize, string fromDate = null, string toDate = null)

Get Trade-wise Profit and Loss Report Data

This API gives the data of the realised Profit and Loss report requested by a user


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **segment** | **string** | Segment for which data is requested can be from the following options EQ - Equity,   FO - Futures and Options,   COM  - Commodity,   CD - Currency Derivatives |  |
| **financialYear** | **string** | Financial year for which data has been requested. Concatenation of last 2 digits of from year and to year Sample:for 2021-2022, financial_year will be 2122 |  |
| **pageNumber** | **int** | Page Number, the pages are starting from 1 |  |
| **pageSize** | **int** | Page size for pagination. The maximum page size value is obtained from P and L report metadata API. |  |
| **fromDate** | **string** | Date from which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format | [optional]  |
| **toDate** | **string** | Date till which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format | [optional]  |

### Return type

[**GetTradeWiseProfitAndLossDataResponse**](GetTradeWiseProfitAndLossDataResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1070 - The financial_year is required&lt;br&gt;UDAPI1071 - The page_number is required&lt;br&gt;UDAPI1072 - The page_size is required&lt;br&gt;UDAPI1067 - The &#39;&#39;segment&#39;&#39; is required&lt;br&gt;UDAPI1066 - The &#39;&#39;segment&#39;&#39; is invalid&lt;br&gt;UDAPI1073 - Financial year should have max length of 4&lt;br&gt;UDAPI1106 - The page_size should be greater than or equal to 1&lt;br&gt;UDAPI1107 - The page_size should be less than or equal to 5000&gt;br&gt;UDAPI1105 - The given dates are not in the mentioned financial year |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="gettradewiseprofitandlossmetadata"></a>
# **GetTradeWiseProfitAndLossMetaData**
> GetTradeWiseProfitAndLossMetaDataResponse GetTradeWiseProfitAndLossMetaData (string segment, string financialYear, string fromDate = null, string toDate = null)

Get profit and loss meta data on trades

This API gives the data of the realised Profit and Loss report requested by a user


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **segment** | **string** | Segment for which data is requested can be from the following options EQ - Equity,   FO - Futures and Options,   COM  - Commodity,   CD - Currency Derivatives |  |
| **financialYear** | **string** | Financial year for which data has been requested. Concatenation of last 2 digits of from year and to year Sample:for 2021-2022, financial_year will be 2122 |  |
| **fromDate** | **string** | Date from which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format | [optional]  |
| **toDate** | **string** | Date till which data needs to be fetched. from_date and to_date should fall under the same financial year as mentioned in financial_year attribute. Date in dd-mm-yyyy format | [optional]  |

### Return type

[**GetTradeWiseProfitAndLossMetaDataResponse**](GetTradeWiseProfitAndLossMetaDataResponse.md)

### Authorization

[OAUTH2](../README.md#OAUTH2)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **405** | Method Not Allowed |  -  |
| **400** | UDAPI1070 - The financial_year is required&lt;br&gt;UDAPI1067 - The &#39;&#39;segment&#39;&#39; is required&lt;br&gt;UDAPI1066 - The &#39;&#39;segment&#39;&#39; is invalid&lt;br&gt;UDAPI1073 - Financial year should have max length of 4&lt;br&gt;UDAPI1068 - The start_date is required&lt;br&gt;UDAPI1069 - The end_date is required&lt;br&gt;UDAPI1105 - The provided dates do not fall within the specified financial year |  -  |
| **500** | Internal Server Error |  -  |
| **429** | Too Many Requests |  -  |
| **423** | Locked |  -  |
| **422** | Unprocessable Entity |  -  |
| **200** | Successful |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

