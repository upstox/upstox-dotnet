# UpstoxClient.Model.TradeData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Exchange** | **string** | Exchange to which the order is associated | [optional] [readonly] 
**Product** | **string** | Shows if the order was either Intraday, Delivery, CO or OCO | [optional] [readonly] 
**TradingSymbol** | **string** | Shows the trading symbol which could be a combination of symbol name, instrument, expiry date etc | [optional] [readonly] 
**InstrumentToken** | **string** | Identifier issued by Upstox used for subscribing to live market quotes | [optional] [readonly] 
**OrderType** | **string** | Type of order. It can be one of the following MARKET refers to market order&lt;br&gt;LIMIT refers to Limit Order&lt;br&gt;SL refers to Stop Loss Limit&lt;br&gt;SL-M refers to Stop loss market | [optional] [readonly] 
**TransactionType** | **string** | Indicates whether the order was a buy or sell order | [optional] [readonly] 
**Quantity** | **int** | The total quantity traded from this particular order | [optional] [readonly] 
**ExchangeOrderId** | **string** | Unique order ID assigned by the exchange for the order placed | [optional] [readonly] 
**OrderId** | **string** | Unique order ID assigned internally for the order placed | [optional] [readonly] 
**ExchangeTimestamp** | **string** | User readable time at when the trade occurred | [optional] [readonly] 
**AveragePrice** | **float** | Price at which the traded quantity is traded | [optional] [readonly] 
**TradeId** | **string** | Trade ID generated from exchange towards traded transaction | [optional] [readonly] 
**OrderRefId** | **string** | The order reference ID for which the order must be modified | [optional] [readonly] 
**OrderTimestamp** | **string** | User readable timestamp at which the order was placed | [optional] [readonly] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

