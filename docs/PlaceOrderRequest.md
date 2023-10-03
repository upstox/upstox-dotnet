# UpstoxClient.Model.PlaceOrderRequest
## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Quantity** | **int?** | Quantity with which the order is to be placed | 
**Product** | **string** | Signifies if the order was either Intraday, Delivery, CO or OCO | 
**Validity** | **string** | It can be one of the following - DAY(default), IOC | 
**Price** | **float?** | Price at which the order will be placed | 
**Tag** | **string** | Tag for a particular order | [optional] 
**InstrumentToken** | **string** | Key of the instrument | 
**OrderType** | **string** | Type of order. It can be one of the following MARKET refers to market order LIMIT refers to Limit Order SL refers to Stop Loss Limit SL-M refers to Stop Loss Market | 
**TransactionType** | **string** | Indicates whether its a buy or sell order | 
**DisclosedQuantity** | **int?** | The quantity that should be disclosed in the market depth | 
**TriggerPrice** | **float?** | If the order is a stop loss order then the trigger price to be set is mentioned here | 
**IsAmo** | **bool?** | Signifies if the order is an After Market Order | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

