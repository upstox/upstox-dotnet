# UpstoxClient.Model.OrderBookData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Exchange** | **string** | Exchange to which the order is associated | [optional] [readonly] 
**Product** | **string** | Shows if the order was either Intraday, Delivery, CoverOrder or OneCancelsOther | [optional] [readonly] 
**Price** | **float** | Price at which the order was placed | [optional] [readonly] 
**Quantity** | **int** | Quantity with which the order was placed | [optional] [readonly] 
**Status** | **string** | Indicates the current status of the order. Valid order status’ are outlined in the table below | [optional] [readonly] 
**Guid** | **string** |  | [optional] [readonly] 
**Tag** | **string** | Tag to uniquely identify an order | [optional] [readonly] 
**InstrumentToken** | **string** | Identifier issued by Upstox used for subscribing to live market quotes | [optional] [readonly] 
**PlacedBy** | **string** | Uniquely identifies the user | [optional] [readonly] 
**TradingSymbol** | **string** | Shows the trading symbol of the instrument | [optional] [readonly] 
**OrderType** | **string** | Type of order. It can be one of the following MARKET refers to market order&lt;br&gt;LIMIT refers to Limit Order&lt;br&gt;SL refers to Stop Loss Limit&lt;br&gt;SL-M refers to Stop loss market | [optional] [readonly] 
**Validity** | **string** | Order validity (DAY- Day and IOC- Immediate or Cancel (IOC) order) | [optional] [readonly] 
**TriggerPrice** | **float** | If the order was a stop loss order then the trigger price set is mentioned here | [optional] [readonly] 
**DisclosedQuantity** | **int** | The quantity that should be disclosed in the market depth | [optional] [readonly] 
**TransactionType** | **string** | Indicates whether the order was a buy or sell order | [optional] [readonly] 
**AveragePrice** | **float** | Average price at which the qty got traded | [optional] [readonly] 
**FilledQuantity** | **int** | The total quantity traded from this particular order | [optional] [readonly] 
**PendingQuantity** | **int** | Pending quantity to be filled | [optional] [readonly] 
**StatusMessage** | **string** | Indicates the reason when any order is rejected, not modified or cancelled | [optional] [readonly] 
**StatusMessageRaw** | **string** | Description of the order&#39;s status as received from RMS | [optional] [readonly] 
**ExchangeOrderId** | **string** | Unique order ID assigned by the exchange for the order placed | [optional] [readonly] 
**ParentOrderId** | **string** | In case the order is part of the second or third leg of a CO or OCO, the parent order ID is indicated here | [optional] [readonly] 
**OrderId** | **string** | Unique order ID assigned internally for the order placed | [optional] [readonly] 
**Variety** | **string** | Order complexity | [optional] [readonly] 
**OrderTimestamp** | **string** | User readable timestamp at which the order was placed | [optional] [readonly] 
**ExchangeTimestamp** | **string** | User readable time at which the order was placed or updated | [optional] [readonly] 
**IsAmo** | **bool** | Signifies if the order is an After Market Order | [optional] [readonly] 
**OrderRequestId** | **string** | Apart from 1st order it shows the count of how many requests were sent | [optional] [readonly] 
**OrderRefId** | **string** | The order reference ID for which the order must be modified | [optional] [readonly] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

