# UpstoxClient.Model.MarketQuoteSymbol

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Ohlc** | [**Ohlc**](Ohlc.md) |  | [optional] 
**Depth** | [**DepthMap**](DepthMap.md) |  | [optional] 
**Timestamp** | **string** | Time in milliseconds at which the feeds was updated | [optional] [readonly] 
**InstrumentToken** | **string** | Key issued by Upstox for the instrument | [optional] [readonly] 
**Symbol** | **string** | Shows the trading symbol of the instrument | [optional] [readonly] 
**LastPrice** | **double** | The last traded price of symbol | [optional] [readonly] 
**Volume** | **long** | The volume traded today on symbol | [optional] [readonly] 
**AveragePrice** | **double** | Average price | [optional] [readonly] 
**Oi** | **double** | Total number of outstanding contracts held by market participants exchange-wide (only F&amp;O) | [optional] [readonly] 
**NetChange** | **double** | The absolute change from yesterday&#39;s close to last traded price | [optional] [readonly] 
**TotalBuyQuantity** | **double** | The total number of bid quantity available for trading | [optional] [readonly] 
**TotalSellQuantity** | **double** | The total number of ask quantity available for trading | [optional] [readonly] 
**LowerCircuitLimit** | **double** | The lower circuit of symbol | [optional] [readonly] 
**UpperCircuitLimit** | **double** | The upper circuit of symbol | [optional] [readonly] 
**LastTradeTime** | **string** | Time in milliseconds at which last trade happened | [optional] [readonly] 
**OiDayHigh** | **double** |  | [optional] [readonly] 
**OiDayLow** | **double** |  | [optional] [readonly] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

