# UpstoxClient.Model.ProfileData

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Email** | **string** | E-mail address of the user | [optional] [readonly] 
**Exchanges** | **List&lt;ProfileData.ExchangesEnum&gt;** | Lists the exchanges to which the user has access | [optional] 
**Products** | **List&lt;ProfileData.ProductsEnum&gt;** | Lists the products types to which the user has access | [optional] 
**Broker** | **string** | The broker ID | [optional] [readonly] 
**UserId** | **string** | Uniquely identifies the user | [optional] [readonly] 
**UserName** | **string** | Name of the user | [optional] [readonly] 
**OrderTypes** | **List&lt;ProfileData.OrderTypesEnum&gt;** | Order types enabled for the user | [optional] 
**UserType** | **string** |   Identifies the user&#39;s registered role at the broker. This will be individual for all retail users | [optional] [readonly] 
**Poa** | **bool** |   To depict if the user has given power of attorney for transactions | [optional] [readonly] 
**Ddpi** | **bool** |   Indicates if DDPI is enabled for trading | [optional] [readonly] 
**IsActive** | **bool** |   Whether the status of account is active or not | [optional] [readonly] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

