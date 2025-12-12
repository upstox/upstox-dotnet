# UpstoxClient.Model.HoldingsData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Isin** | **string** | The standard ISIN representing stocks listed on multiple exchanges | [optional] [readonly] 
**CncUsedQuantity** | **int** | Quantity either blocked towards open or completed order | [optional] [readonly] 
**CollateralType** | **string** | Category of collateral assigned by RMS | [optional] [readonly] 
**CompanyName** | **string** | Name of the company | [optional] [readonly] 
**Haircut** | **float** | This is the haircut percentage applied from RMS (applicable incase of collateral) | [optional] [readonly] 
**Product** | **string** | Shows if the order was either Intraday, Delivery, CO or OCO | [optional] [readonly] 
**Quantity** | **int** | The total holding qty | [optional] [readonly] 
**LastPrice** | **float** | The last traded price of the instrument | [optional] [readonly] 
**ClosePrice** | **float** | Closing price of the instrument from the last trading day | [optional] [readonly] 
**Pnl** | **float** | Profit and Loss | [optional] [readonly] 
**DayChange** | **float** | Day&#39;s change in absolute value for the stock | [optional] [readonly] 
**DayChangePercentage** | **float** | Day&#39;s change in percentage for the stock | [optional] [readonly] 
**InstrumentToken** | **string** | Key issued by Upstox for the instrument | [optional] [readonly] 
**AveragePrice** | **float** | Average price at which the net holding quantity was acquired | [optional] [readonly] 
**CollateralQuantity** | **int** | Quantity marked as collateral by RMS on users request | [optional] [readonly] 
**CollateralUpdateQuantity** | **int** |  | [optional] [readonly] 
**TradingSymbol** | **string** | Shows the trading symbol of the instrument | [optional] [readonly] 
**T1Quantity** | **int** | Quantity on T+1 day after order execution | [optional] [readonly] 
**Exchange** | **string** | Exchange of the trading symbol | [optional] [readonly] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

