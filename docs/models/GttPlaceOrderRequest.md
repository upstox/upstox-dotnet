# UpstoxClient.Model.GttPlaceOrderRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Rules** | [**List&lt;GttRule&gt;**](GttRule.md) | List of rules defining the conditions for each leg in the GTT order | 
**Type** | **string** | Type of GTT order. It can be one of the following: SINGLE refers to a single-leg GTT order MULTIPLE refers to a multi-leg GTT order | 
**Quantity** | **int** | Quantity with which the order is to be placed | 
**Product** | **string** | Signifies if the order was either Intraday, Delivery or MTF | 
**InstrumentToken** | **string** | Key of the instrument | 
**TransactionType** | **string** | Indicates whether its a buy or sell order | 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

