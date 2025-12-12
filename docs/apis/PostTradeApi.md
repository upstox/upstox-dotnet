# UpstoxClient.Api.PostTradeApi

All URIs are relative to *https://api.upstox.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetTradesByDateRange**](PostTradeApi.md#gettradesbydaterange) | **GET** /v2/charges/historical-trades | Get historical trades |

<a id="gettradesbydaterange"></a>
# **GetTradesByDateRange**
> TradeHistoryResponse GetTradesByDateRange (string startDate, string endDate, int pageNumber, int pageSize, string segment = null)

Get historical trades

This API retrieves the trade history for a specified time interval.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **startDate** | **string** | Date from which trade history needs to be fetched. Date in YYYY-mm-dd format |  |
| **endDate** | **string** | Date till which history needs needs to be fetched. Date in YYYY-mm-dd format |  |
| **pageNumber** | **int** | Page number for which you want to fetch trade history  |  |
| **pageSize** | **int** | How many records you want for a page  |  |
| **segment** | **string** | Segment for which data is requested can be from the following options EQ - Equity,   FO - Futures and Options,   COM  - Commodity,   CD - Currency Derivatives MF - Mutual Funds | [optional] [default to &quot;&quot;] |

### Return type

[**TradeHistoryResponse**](TradeHistoryResponse.md)

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

