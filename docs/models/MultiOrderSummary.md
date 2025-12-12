# UpstoxClient.Model.MultiOrderSummary

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Total** | **int** | The total number of order lines present in the payload. | [optional] [readonly] 
**Success** | **int** | The number of order lines that were successfully placed without any errors. | [optional] [readonly] 
**Error** | **int** | The number of order lines that encountered errors during processing, despite their payloads being valid. | [optional] [readonly] 
**PayloadError** | **int** | The number of order lines with payload errors, indicating formatting or data validity issues.&lt;br/&gt;&lt;br/&gt;&lt;b&gt;Note&lt;/b&gt;: Orders are processed only if the entire batch is free of payload_error, ensuring error-free transactions. | [optional] [readonly] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

