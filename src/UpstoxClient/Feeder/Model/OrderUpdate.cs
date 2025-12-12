using System.Text.Json.Serialization;

namespace UpstoxClient.Feeder.Model
{
    public class OrderUpdate
    {
        [JsonPropertyName("user_id")]
        public string? UserId { get; set; }

        [JsonPropertyName("exchange")]
        public string? Exchange { get; set; }

        [JsonPropertyName("instrument_token")]
        public string? InstrumentToken { get; set; }

        [JsonPropertyName("instrument_key")]
        public string? InstrumentKey { get; set; }

        [JsonPropertyName("trading_symbol")]
        public string? TradingSymbol { get; set; }

        [JsonPropertyName("product")]
        public string? Product { get; set; }

        [JsonPropertyName("order_type")]
        public string? OrderType { get; set; }

        [JsonPropertyName("average_price")]
        public double? AveragePrice { get; set; }

        [JsonPropertyName("price")]
        public double? Price { get; set; }

        [JsonPropertyName("trigger_price")]
        public double? TriggerPrice { get; set; }

        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        [JsonPropertyName("disclosed_quantity")]
        public int? DisclosedQuantity { get; set; }

        [JsonPropertyName("pending_quantity")]
        public int? PendingQuantity { get; set; }

        [JsonPropertyName("transaction_type")]
        public string? TransactionType { get; set; }

        [JsonPropertyName("order_ref_id")]
        public string? OrderRefId { get; set; }

        [JsonPropertyName("exchange_order_id")]
        public string? ExchangeOrderId { get; set; }

        [JsonPropertyName("parent_order_id")]
        public string? ParentOrderId { get; set; }

        [JsonPropertyName("validity")]
        public string? Validity { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("is_amo")]
        public bool? IsAmo { get; set; }

        [JsonPropertyName("variety")]
        public string? Variety { get; set; }

        [JsonPropertyName("tag")]
        public string? Tag { get; set; }

        [JsonPropertyName("exchange_timestamp")]
        public string? ExchangeTimestamp { get; set; }

        [JsonPropertyName("status_message")]
        public string? StatusMessage { get; set; }

        [JsonPropertyName("order_id")]
        public string? OrderId { get; set; }

        [JsonPropertyName("order_request_id")]
        public string? OrderRequestId { get; set; }

        [JsonPropertyName("order_timestamp")]
        public string? OrderTimestamp { get; set; }

        [JsonPropertyName("filled_quantity")]
        public int? FilledQuantity { get; set; }

        [JsonPropertyName("guid")]
        public string? Guid { get; set; }

        [JsonPropertyName("placed_by")]
        public string? PlacedBy { get; set; }

        [JsonPropertyName("status_message_raw")]
        public string? StatusMessageRaw { get; set; }

        public override string ToString()
        {
            return $"UserId={UserId}, Exchange={Exchange}, InstrumentToken={InstrumentToken}, InstrumentKey={InstrumentKey}, TradingSymbol={TradingSymbol}, Product={Product}, OrderType={OrderType}, AveragePrice={AveragePrice}, Price={Price}, TriggerPrice={TriggerPrice}, Quantity={Quantity}, DisclosedQuantity={DisclosedQuantity}, PendingQuantity={PendingQuantity}, TransactionType={TransactionType}, OrderRefId={OrderRefId}, ExchangeOrderId={ExchangeOrderId}, ParentOrderId={ParentOrderId}, Validity={Validity}, Status={Status}, IsAmo={IsAmo}, Variety={Variety}, Tag={Tag}, ExchangeTimestamp={ExchangeTimestamp}, StatusMessage={StatusMessage}, OrderId={OrderId}, OrderRequestId={OrderRequestId}, OrderTimestamp={OrderTimestamp}, FilledQuantity={FilledQuantity}, Guid={Guid}, PlacedBy={PlacedBy}, StatusMessageRaw={StatusMessageRaw}";
        }
    }
}
