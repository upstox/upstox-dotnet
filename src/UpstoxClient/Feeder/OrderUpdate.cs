using Newtonsoft.Json;

namespace UpstoxClient.Feeder
{
    public class OrderUpdate
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("exchange")]
        public string Exchange { get; set; }

        [JsonProperty("instrument_token")]
        public string InstrumentToken { get; set; }

        [JsonProperty("instrument_key")]
        public string InstrumentKey { get; set; }

        [JsonProperty("trading_symbol")]
        public string TradingSymbol { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }

        [JsonProperty("order_type")]
        public string OrderType { get; set; }

        [JsonProperty("average_price")]
        public double AveragePrice { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("trigger_price")]
        public double TriggerPrice { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("disclosed_quantity")]
        public int DisclosedQuantity { get; set; }

        [JsonProperty("pending_quantity")]
        public int PendingQuantity { get; set; }

        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }

        [JsonProperty("order_ref_id")]
        public string OrderRefId { get; set; }

        [JsonProperty("exchange_order_id")]
        public string ExchangeOrderId { get; set; }

        [JsonProperty("parent_order_id")]
        public string ParentOrderId { get; set; }

        [JsonProperty("validity")]
        public string Validity { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("is_amo")]
        public bool IsAmo { get; set; }

        [JsonProperty("variety")]
        public string Variety { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("exchange_timestamp")]
        public string ExchangeTimestamp { get; set; }

        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("order_request_id")]
        public string OrderRequestId { get; set; }

        [JsonProperty("order_timestamp")]
        public string OrderTimestamp { get; set; }

        [JsonProperty("filled_quantity")]
        public int FilledQuantity { get; set; }

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("placed_by")]
        public string PlacedBy { get; set; }

        [JsonProperty("status_message_raw")]
        public string StatusMessageRaw { get; set; }

        public override string ToString()
        {
            return "OrderUpdate [UserId=" + UserId + ", Exchange=" + Exchange + ", InstrumentToken=" + InstrumentToken
                    + ", InstrumentKey=" + InstrumentKey + ", TradingSymbol=" + TradingSymbol + ", Product=" + Product
                    + ", OrderType=" + OrderType + ", AveragePrice=" + AveragePrice + ", Price=" + Price + ", TriggerPrice="
                    + TriggerPrice + ", Quantity=" + Quantity + ", DisclosedQuantity=" + DisclosedQuantity
                    + ", PendingQuantity=" + PendingQuantity + ", TransactionType=" + TransactionType + ", OrderRefId="
                    + OrderRefId + ", ExchangeOrderId=" + ExchangeOrderId + ", ParentOrderId=" + ParentOrderId
                    + ", Validity=" + Validity + ", Status=" + Status + ", IsAmo=" + IsAmo + ", Variety=" + Variety
                    + ", Tag=" + Tag + ", ExchangeTimestamp=" + ExchangeTimestamp + ", StatusMessage=" + StatusMessage
                    + ", OrderId=" + OrderId + ", OrderRequestId=" + OrderRequestId + ", OrderTimestamp=" + OrderTimestamp
                    + ", FilledQuantity=" + FilledQuantity + ", Guid=" + Guid + ", PlacedBy=" + PlacedBy
                    + ", StatusMessageRaw=" + StatusMessageRaw + "]";
        }
    }
}
