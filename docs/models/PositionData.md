# UpstoxClient.Model.PositionData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Exchange** | **string** | Exchange to which the order is associated | [optional] [readonly] 
**Multiplier** | **float** | The quantity/lot size multiplier used for calculating P&amp;Ls | [optional] [readonly] 
**Value** | **float** | Net value of the position | [optional] [readonly] 
**Pnl** | **float** | Profit and loss - net returns on the position | [optional] [readonly] 
**Product** | **string** | Shows if the order was either Intraday, Delivery, CO or OCO | [optional] [readonly] 
**InstrumentToken** | **string** | Key issued by Upstox for the instrument | [optional] [readonly] 
**AveragePrice** | **float** | Average price at which the net position quantity was acquired | [optional] [readonly] 
**BuyValue** | **float** | Net value of the bought quantities | [optional] [readonly] 
**OvernightQuantity** | **int** | Quantity held previously and carried forward over night | [optional] [readonly] 
**DayBuyValue** | **float** | Amount at which the quantity is bought during the day | [optional] [readonly] 
**DayBuyPrice** | **float** | Average price at which the day qty was bought. Default is empty string | [optional] [readonly] 
**OvernightBuyAmount** | **float** | Amount at which the quantity was bought in the previous session | [optional] [readonly] 
**OvernightBuyQuantity** | **int** | Quantity bought in the previous session | [optional] [readonly] 
**DayBuyQuantity** | **int** | Quantity bought during the day | [optional] [readonly] 
**DaySellValue** | **float** | Amount at which the quantity is sold during the day | [optional] [readonly] 
**DaySellPrice** | **float** | Average price at which the day quantity was sold | [optional] [readonly] 
**OvernightSellAmount** | **float** | Amount at which the quantity was sold in the previous session | [optional] [readonly] 
**OvernightSellQuantity** | **int** | Quantity sold short in the previous session | [optional] [readonly] 
**DaySellQuantity** | **int** | Quantity sold during the day | [optional] [readonly] 
**Quantity** | **int** | Quantity left after nullifying Day and CF buy quantity towards Day and CF sell quantity | [optional] [readonly] 
**LastPrice** | **float** | Last traded market price of the instrument | [optional] [readonly] 
**Unrealised** | **float** | Day PnL generated against open positions | [optional] [readonly] 
**Realised** | **float** | Day PnL generated against closed positions | [optional] [readonly] 
**SellValue** | **float** | Net value of the sold quantities | [optional] [readonly] 
**TradingSymbol** | **string** | Shows the trading symbol of the instrument | [optional] [readonly] 
**ClosePrice** | **float** | Closing price of the instrument from the last trading day | [optional] [readonly] 
**BuyPrice** | **float** | Average price at which quantities were bought | [optional] [readonly] 
**SellPrice** | **float** | Average price at which quantities were sold | [optional] [readonly] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

