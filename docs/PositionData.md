# UpstoxClient.Model.PositionData
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Exchange** | **string** | Exchange to which the order is associated | [optional] 
**Multiplier** | **float?** | The quantity/lot size multiplier used for calculating P&amp;Ls | [optional] 
**Value** | **float?** | Net value of the position | [optional] 
**Pnl** | **float?** | Profit and loss - net returns on the position | [optional] 
**Product** | **string** | Shows if the order was either Intraday, Delivery, CO or OCO | [optional] 
**InstrumentToken** | **string** | Key issued by Upstox for the instrument | [optional] 
**AveragePrice** | **float?** | Average price at which the net position quantity was acquired | [optional] 
**BuyValue** | **float?** | Net value of the bought quantities | [optional] 
**OvernightQuantity** | **int?** | Quantity held previously and carried forward over night | [optional] 
**DayBuyValue** | **float?** | Amount at which the quantity is bought during the day | [optional] 
**DayBuyPrice** | **float?** | Average price at which the day qty was bought. Default is empty string | [optional] 
**OvernightBuyAmount** | **float?** | Amount at which the quantity was bought in the previous session | [optional] 
**OvernightBuyQuantity** | **int?** | Quantity bought in the previous session | [optional] 
**DayBuyQuantity** | **int?** | Quantity bought during the day | [optional] 
**DaySellValue** | **float?** | Amount at which the quantity is sold during the day | [optional] 
**DaySellPrice** | **float?** | Average price at which the day quantity was sold | [optional] 
**OvernightSellAmount** | **float?** | Amount at which the quantity was sold in the previous session | [optional] 
**OvernightSellQuantity** | **int?** | Quantity sold short in the previous session | [optional] 
**DaySellQuantity** | **int?** | Quantity sold during the day | [optional] 
**Quantity** | **int?** | Quantity left after nullifying Day and CF buy quantity towards Day and CF sell quantity | [optional] 
**LastPrice** | **float?** | Last traded market price of the instrument | [optional] 
**Unrealised** | **float?** | Day PnL generated against open positions | [optional] 
**Realised** | **float?** | Day PnL generated against closed positions | [optional] 
**SellValue** | **float?** | Net value of the sold quantities | [optional] 
**Tradingsymbol** | **string** | Shows the trading symbol of the instrument | [optional] 
**ClosePrice** | **float?** | Closing price of the instrument from the last trading day | [optional] 
**BuyPrice** | **float?** | Average price at which quantities were bought | [optional] 
**SellPrice** | **float?** | Average price at which quantities were sold | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

