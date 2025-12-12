using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UpstoxClient.Feeder.Model
{
    public class GttUpdate
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("exchange")]
        public string? Exchange { get; set; }

        [JsonPropertyName("instrument_token")]
        public string? InstrumentToken { get; set; }

        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        [JsonPropertyName("product")]
        public string? Product { get; set; }

        [JsonPropertyName("gtt_order_id")]
        public string? GttOrderId { get; set; }

        [JsonPropertyName("expires_at")]
        public long? ExpiresAt { get; set; }

        [JsonPropertyName("created_at")]
        public long? CreatedAt { get; set; }

        [JsonPropertyName("rules")]
        public List<Rule>? Rules { get; set; }

        public class Rule
        {
            [JsonPropertyName("strategy")]
            public string? Strategy { get; set; }

            [JsonPropertyName("trigger_type")]
            public string? TriggerType { get; set; }

            [JsonPropertyName("trigger_price")]
            public double? TriggerPrice { get; set; }

            [JsonPropertyName("transaction_type")]
            public string? TransactionType { get; set; }

            [JsonPropertyName("status")]
            public string? Status { get; set; }

            [JsonPropertyName("order_id")]
            public string? OrderId { get; set; }

            [JsonPropertyName("message")]
            public string? Message { get; set; }

            [JsonPropertyName("trailing_gap")]
            public double? TrailingGap { get; set; }

            public override string ToString()
            {
                return $"Strategy={Strategy}, TriggerType={TriggerType}, TriggerPrice={TriggerPrice}, TransactionType={TransactionType}, Status={Status}, OrderId={OrderId}, Message={Message}, TrailingGap={TrailingGap}";
            }
        }

        public override string ToString()
        {
            var rulesText = Rules == null ? "null" : $"[{string.Join("; ", Rules)}]";
            return $"Type={Type}, Exchange={Exchange}, InstrumentToken={InstrumentToken}, Quantity={Quantity}, Product={Product}, GttOrderId={GttOrderId}, ExpiresAt={ExpiresAt}, CreatedAt={CreatedAt}, Rules={rulesText}";
        }
    }
}
