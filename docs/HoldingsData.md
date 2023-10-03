# UpstoxClient.Model.HoldingsData
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Isin** | **string** | The standard ISIN representing stocks listed on multiple exchanges | [optional] 
**CncUsedQuantity** | **int?** | Quantity either blocked towards open or completed order | [optional] 
**CollateralType** | **string** | Category of collateral assigned by RMS | [optional] 
**CompanyName** | **string** | Name of the company | [optional] 
**Haircut** | **float?** | This is the haircut percentage applied from RMS (applicable incase of collateral) | [optional] 
**Product** | **string** | Shows if the order was either Intraday, Delivery, CO or OCO | [optional] 
**Quantity** | **int?** | The total holding qty | [optional] 
**Tradingsymbol** | **string** | Shows the trading symbol of the instrument | [optional] 
**LastPrice** | **float?** | The last traded price of the instrument | [optional] 
**ClosePrice** | **float?** | Closing price of the instrument from the last trading day | [optional] 
**Pnl** | **float?** | Profit and Loss | [optional] 
**DayChange** | **float?** | Day&#x27;s change in absolute value for the stock | [optional] 
**DayChangePercentage** | **float?** | Day&#x27;s change in percentage for the stock | [optional] 
**InstrumentToken** | **string** | Key issued by Upstox for the instrument | [optional] 
**AveragePrice** | **float?** | Average price at which the net holding quantity was acquired | [optional] 
**CollateralQuantity** | **int?** | Quantity marked as collateral by RMS on users request | [optional] 
**CollateralUpdateQuantity** | **int?** |  | [optional] 
**T1Quantity** | **int?** | Quantity on T+1 day after order execution | [optional] 
**Exchange** | **string** | Exchange of the trading symbol | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

